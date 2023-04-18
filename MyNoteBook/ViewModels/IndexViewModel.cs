using MyNoteBook.Common;
using MyNoteBook.Common.Models;
using MyNoteBook.Extenstions;
using MyNoteBook.Service;
using MyNoteBook.Share.Dtos;
using Prism.Commands;
using Prism.Common;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.ViewModels
{
    public class IndexViewModel: NavigationViewModel
    {
        private readonly INoteBookService noteService;
        private readonly IMemoService memoService;
        public readonly IRegionManager regionManager;
        public IndexViewModel(IContainerProvider provider, IDialogHostService dialog):base(provider)
        {
            Title = $"你好,{AppSession.UserName} {DateTime.Now.GetDateTimeFormats('D')[1].ToString()}";

            CreateBar();
            //CreateTestData();
            ExecutedCommand = new DelegateCommand<string>(Executed);
            regionManager= provider.Resolve<IRegionManager>();

            this.noteService= provider.Resolve<INoteBookService>();
            this.memoService = provider.Resolve<IMemoService>();
            this.dialog = dialog;

            EditToDoCommand = new DelegateCommand<NoteBookDto>(AddTodo);
            EditMemoCommand = new DelegateCommand<MemoDto>(AddMemo);
            ToDoCompletedCommand = new DelegateCommand<NoteBookDto>(Completed);
            NavigateCommand = new DelegateCommand<TaskBar>(Navigate);
        }

        private void Navigate(TaskBar obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Target)) return;
            NavigationParameters param = new NavigationParameters();

            if (obj.Title.Equals("已完成"))
            {
                param.Add("Value", 2);
            }

            regionManager.Regions[PrsimManager.MainViewRegionName].RequestNavigate(obj.Target, param);
        }

        private async void Completed(NoteBookDto obj)
        {
            try
            {
                UpdateLoading(true);
                var complete = await noteService.UpdateAsync(obj);

                if (complete.Status)
                {
                    var todo = SummaryDto.TodoList.FirstOrDefault(p => p.Id.Equals(obj.Id));

                    if (todo != null)
                    {
                        SummaryDto.TodoList.Remove(todo);
                        SummaryDto.CompletedCount += 1;
                        SummaryDto.CompletedRadio = (SummaryDto.CompletedCount / (double)SummaryDto.Sum).ToString("0%");
                        this.Reflush();
                    }
                }
                aggregator.SendMessage("已完成！");

            }
            finally
            {
                UpdateLoading(false);
            }

        }

        private void Executed(string obj)
        {
             switch (obj)
            {
                case "新增待办": AddTodo(null); break;
                case "新增备忘录": AddMemo(null); break;
            }
        }

        public DelegateCommand<NoteBookDto> ToDoCompletedCommand { get; private set; }
        public DelegateCommand<NoteBookDto> EditToDoCommand { get; private set; }
        public DelegateCommand<MemoDto> EditMemoCommand { get; private set; }

        public DelegateCommand<TaskBar> NavigateCommand { get; private set; }

        public DelegateCommand<string> ExecutedCommand { get; set; }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }


        private ObservableCollection<TaskBar> taskBars;

        public ObservableCollection<TaskBar>  TaskBars
        {
            get { return taskBars; }
            set { taskBars = value;RaisePropertyChanged(); }
        }



 
        private readonly IDialogHostService dialog;


        private SummaryDto summaryDto;

        public SummaryDto SummaryDto
        {
            get { return summaryDto; }
            set { summaryDto = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 添加待办
        /// </summary>
        async  void AddTodo(NoteBookDto model)
        {
            DialogParameters param = new DialogParameters();

            if (model!=null)
            {
                param.Add("Value", model);
            }

           var dialogResult=await dialog.ShowDialog("AddToDoView", param);
            if (dialogResult.Result==ButtonResult.OK)
            {
                try
                {
                    UpdateLoading(true);
                    var todo = dialogResult.Parameters.GetValue<NoteBookDto>("Value");

                    if (todo.Id > 0)
                    {
                        var updateResult = await noteService.UpdateAsync(todo);

                        if (updateResult.Status)
                        {
                            var todoModel = SummaryDto.TodoList.FirstOrDefault(p => p.Id.Equals(model.Id));
                            if (todoModel != null)
                            {
                                todoModel.Title = todo.Title;
                                todoModel.Content = todo.Content;
                            }
                        }
                    }
                    else
                    {
                        var addResult = await noteService.AddAsync(todo);
                        if (addResult.Status)
                        {
                            SummaryDto.Sum += 1;
                            SummaryDto.TodoList.Add(addResult.Result);
                            SummaryDto.CompletedRadio = (SummaryDto.CompletedCount / (double)SummaryDto.Sum).ToString("0%");
                            this.Reflush();
                        }
                    }
                }
                finally
                {
                    UpdateLoading(false);
                }
             
            }
        }

        /// <summary>
        /// 添加备忘录
        /// </summary>
        async void AddMemo(MemoDto model)
        {
            DialogParameters param = new DialogParameters();

            if (model != null)
            {
                param.Add("Value", model);
            }

            var dialogResult = await dialog.ShowDialog("AddMemoView", param);

            if (dialogResult.Result == ButtonResult.OK)
            {
                try
                {
                    UpdateLoading(true);
                    var todo = dialogResult.Parameters.GetValue<MemoDto>("Value");

                    if (todo.Id > 0)
                    {
                        var updateResult = await memoService.UpdateAsync(todo);

                        if (updateResult.Status)
                        {
                            var todoModel = SummaryDto.MemoList.FirstOrDefault(p => p.Id.Equals(model.Id));
                            if (todoModel != null)
                            {
                                todoModel.Title = todo.Title;
                                todoModel.Content = todo.Content;
                            }
                        }
                    }
                    else
                    {
                        var addResult = await memoService.AddAsync(todo);
                        if (addResult.Status)
                        {
                            SummaryDto.MemoList.Add(addResult.Result);
                        }
                    }
                }
                finally
                {
                    UpdateLoading(false);
                }

            
            }
        }


        public void CreateBar()
        {
            TaskBars = new ObservableCollection<TaskBar>();
            taskBars.Add(new TaskBar { Icon= "ClockFast", Title="汇总", Color="#FF0CA0FF",Target= "ToDoView" });
            taskBars.Add(new TaskBar { Icon = "ClockCheckOutline", Title = "已完成",  Color = "#FF1ECA3A", Target = "ToDoView" });
            taskBars.Add(new TaskBar { Icon = "ChartLineVariant", Title = "完成率",  Color = "#FF02C6DC", Target = "" });
            taskBars.Add(new TaskBar { Icon = "PlaylistStar", Title = "备忘录",Color = "#FFFFA000", Target = "MemoView" });
        }


        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var summary = await noteService.SummaryAsync();
            if (summary.Status)
            {
                SummaryDto = summary.Result;
                Reflush();
            }

            base.OnNavigatedTo(navigationContext);
        }

        public void Reflush()
        {
            TaskBars[0].Content = SummaryDto.Sum.ToString();
            TaskBars[1].Content = SummaryDto.CompletedCount.ToString();
            TaskBars[2].Content = SummaryDto.CompletedRadio;
            TaskBars[3].Content = SummaryDto.MemoCount.ToString();
        }
    }
}
