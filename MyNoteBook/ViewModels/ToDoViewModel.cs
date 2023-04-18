using DryIoc;
using MaterialDesignThemes.Wpf;
using MyNoteBook.Common;
using MyNoteBook.Common.Models;
using MyNoteBook.Extenstions;
using MyNoteBook.Service;
using MyNoteBook.Share.Dtos;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.ViewModels
{
    public class ToDoViewModel : NavigationViewModel
    {

        private readonly IDialogHostService dialogHost;
        public ToDoViewModel(INoteBookService service, IContainerProvider provider) : base(provider)
        {
            ToDoDtos = new ObservableCollection<NoteBookDto>();

            ExecuteCommand = new DelegateCommand<string>(obj =>
            {

                switch (obj)
                {
                    case "新增":Add();break;
                    case "查询":Query();break;
                    case "保存": Save(); break;
                }
            });

            SelectedCommand = new DelegateCommand<NoteBookDto>(async obj =>
            {
                try
                {
                    UpdateLoading(true);
                    var result = await service.GetFirstOfDefaultAsync(obj.Id);

                    if (result.Status)
                    {
                        CurrentDto = result.Result;
                        IsRightDrawerOpen = true;

                    }
            
                }
                catch (Exception ex)
                {

                }
                finally
                { 
                    UpdateLoading(false); 
                }

            });


            DeleteCommand = new DelegateCommand<NoteBookDto>(Delete);
            this.service = service;
            dialogHost= provider.Resolve<IDialogHostService>();
            //CreateDto();
        }

        private bool isRightDrawerOpen;

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        private string search;

        /// <summary>
        /// 搜索条件
        /// </summary>
        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }



        public DelegateCommand<string> ExecuteCommand { get; private set; }

        public DelegateCommand<NoteBookDto> SelectedCommand { get; set; }
        public DelegateCommand<NoteBookDto> DeleteCommand { get; set; }

        private int selectedIndex;

        /// <summary>
        /// 下拉列表选中状态时
        /// </summary>
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<NoteBookDto> toDoDtos;
        private NoteBookDto currentDto;
        private readonly INoteBookService service;

        public ObservableCollection<NoteBookDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        public NoteBookDto CurrentDto { get => currentDto; set { currentDto = value; RaisePropertyChanged(); } }

        public async void GetDataDtoSync()
        {
            UpdateLoading(true);

            int? status = SelectedIndex == 0 ? null : SelectedIndex == 1 ? 0 : 1;

            var notes = await service.GetAllAsync(new Share.Parameters.NoteBookParameter()
            {
                PageIndex = 0,
                PageSize = 10,
                Search = Search,
                Status = status,
            });

            if (notes.Status)
            {
                ToDoDtos.Clear();
                foreach (var note in notes.Result.Items)
                {
                    ToDoDtos.Add(note);
                }
            }
            UpdateLoading(false);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            if (navigationContext.Parameters.ContainsKey("Value"))
            {
                SelectedIndex = navigationContext.Parameters.GetValue<int>("Value");
            }
            else
            {
                SelectedIndex = 0;
            }
            GetDataDtoSync();
        }

        private void Add()
        {
            CurrentDto=new NoteBookDto();
            IsRightDrawerOpen = true;
        }

        private void Query()
        {
            GetDataDtoSync();
        }

        private async void Save()
        {
            if (string.IsNullOrWhiteSpace(CurrentDto.Title) ||
                string.IsNullOrWhiteSpace(CurrentDto.Content))
                return;
            UpdateLoading(true);

            try
            {
                if (CurrentDto.Id > 0)
                {
                    var updateresult = await service.UpdateAsync(CurrentDto);
                    if (updateresult.Status)
                    {
                        var todo = ToDoDtos.FirstOrDefault(t => t.Id == CurrentDto.Id);
                        if (todo != null)
                        {
                            todo.Title = CurrentDto.Title;
                            todo.Content = CurrentDto.Content;
                            todo.Status = CurrentDto.Status;
                        }

                    }

                    IsRightDrawerOpen = false;
                }
                else
                {
                    var addResult = await service.AddAsync(CurrentDto);
                    if (addResult.Status)
                    {
                        ToDoDtos.Add(addResult.Result);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally 
            {
                UpdateLoading(false);
            }
        }

        public async void Delete(NoteBookDto obj)
        {
            try
            {
                var dialogResult= await dialogHost.Question("温馨提示", $"确认删除待办事项:{obj.Title}?");

                if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;
                
                UpdateLoading(true);

                var updateresult = await service.DeleteAsync(obj.Id);
                if (updateresult.Status)
                {
                    var todo = ToDoDtos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (todo != null)
                    {
                        ToDoDtos.Remove(todo);
                    }

                }
            }
            finally
            {
                UpdateLoading(false);
            }

        }

    }
}
