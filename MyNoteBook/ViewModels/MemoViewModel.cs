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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.ViewModels
{
    public class MemoViewModel : NavigationViewModel
    {
        private readonly IDialogHostService dialogHost;
        public MemoViewModel(IMemoService memoService, IContainerProvider provider) : base(provider)
        {
            MemoDtos = new ObservableCollection<MemoDto>();

            AddCommand = new DelegateCommand(() => {
                IsRightDrawerOpen = true;
            });

            ExecuteCommand = new DelegateCommand<string>(obj =>
            {

                switch (obj)
                {
                    case "新增": Add(); break;
                    case "查询": Query(); break;
                    case "保存": Save(); break;
                }
            });

            SelectedCommand = new DelegateCommand<MemoDto>(async obj =>
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


            DeleteCommand = new DelegateCommand<MemoDto>(Delete);
            dialogHost = provider.Resolve<IDialogHostService>();
            this.service = memoService;
            CreateDto();
        }

        private bool isRightDrawerOpen;

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }


        public DelegateCommand AddCommand { get; private set; }


        private ObservableCollection<MemoDto> memoDtos;
        private readonly IMemoService service;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; }
        }



        public async void CreateDto()
        {
            var notes = await service.GetAllAsync(new Share.Parameters.QueryParameter()
            {
                PageIndex = 0,
                PageSize = 10
            });

            if (notes.Status)
            {
                memoDtos.Clear();
                foreach (var note in notes.Result.Items)
                {
                    memoDtos.Add(note);
                }
            }
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

        public DelegateCommand<MemoDto> SelectedCommand { get; set; }
        public DelegateCommand<MemoDto> DeleteCommand { get; set; }

        private int selectedIndex;

        /// <summary>
        /// 下拉列表选中状态时
        /// </summary>
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }

        private MemoDto currentDto;

        public MemoDto CurrentDto { get => currentDto; set { currentDto = value; RaisePropertyChanged(); } }

        public async void GetDataDtoSync()
        {
            UpdateLoading(true);

            //int? status = SelectedIndex == 0 ? null : SelectedIndex == 1 ? 0 : 1;

            var notes = await service.GetAllAsync(new Share.Parameters.QueryParameter()
            {
                PageIndex = 0,
                PageSize = 10,
                Search = Search
            });

            if (notes!=null&&notes.Status)
            {
                MemoDtos.Clear();
                foreach (var note in notes.Result.Items)
                {
                    MemoDtos.Add(note);
                }
            }
            UpdateLoading(false);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            GetDataDtoSync();
        }

        private void Add()
        {
            CurrentDto = new MemoDto();
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
                        var todo = MemoDtos.FirstOrDefault(t => t.Id == CurrentDto.Id);
                        if (todo != null)
                        {
                            todo.Title = CurrentDto.Title;
                            todo.Content = CurrentDto.Content;
                        }

                    }

                    IsRightDrawerOpen = false;
                }
                else
                {
                    var addResult = await service.AddAsync(CurrentDto);
                    if (addResult.Status)
                    {
                        MemoDtos.Add(addResult.Result);
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

        public async void Delete(MemoDto obj)
        {
            try
            {
                var dialogResult = await dialogHost.Question("温馨提示", $"确认删除备忘录:{obj.Title}?");

                if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;

                UpdateLoading(true);
                var updateresult = await service.DeleteAsync(obj.Id);
                if (updateresult.Status)
                {
                    var todo = MemoDtos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (todo != null)
                    {
                        MemoDtos.Remove(todo);
                    }

                }
            }
            finally {
                UpdateLoading(false);
            }

        }
    }
}
