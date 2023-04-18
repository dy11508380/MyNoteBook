using MyNoteBook.Common;
using MyNoteBook.Common.Models;
using MyNoteBook.Extenstions;
using Prism.Commands;
using Prism.Common;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace MyNoteBook.ViewModels
{
    public class MainViewModel : BindableBase, IConfigureService
    {
        public MainViewModel(IContainerProvider container,IRegionManager regionManager)
        {


            //CreateMenu();

            this.regionManager = regionManager;

            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoBack)
                    journal.GoBack();
            });

            GoForwardCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoForward)
                    journal.GoForward();
            });

            LoginOutCommand = new DelegateCommand(() =>
            {
                App.LoginOut(container);
            });
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value;RaisePropertyChanged(); }
        }

        public DelegateCommand LoginOutCommand { get; private set; }
        private void Navigate(MenuBar obj)
        {
            if (obj == null||string.IsNullOrEmpty(obj.NameSpace)) return;
            regionManager.Regions[PrsimManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back =>
            {
                journal = back.Context.NavigationService.Journal;
            });

        }


        public DelegateCommand GoForwardCommand { get; set; }
        public DelegateCommand GoBackCommand { get; set; }
        public DelegateCommand<MenuBar> NavigateCommand { get; set; }
        public  IRegionNavigationJournal journal;
        public readonly IRegionManager regionManager;

        private ObservableCollection<MenuBar> menuBases;

        public ObservableCollection<MenuBar> MenuBases
        {
            get { return menuBases; }
            set { menuBases = value;RaisePropertyChanged(); }
        }



        void CreateMenu()
        {
            MenuBases = new ObservableCollection<MenuBar>();
            MenuBases.Add(new MenuBar() { Icon = "Home", Title = "首页", NameSpace = "IndexView" });
            MenuBases.Add(new MenuBar() { Icon = "NotebookOutline", Title = "待办事项", NameSpace = "ToDoView" });
            MenuBases.Add(new MenuBar() { Icon = "NotebookPlus", Title = "备忘录", NameSpace = "MemoView" });
            MenuBases.Add(new MenuBar() { Icon = "Cog", Title = "设置", NameSpace = "SettingView" });
        }

        public void Configure()
        {
            UserName = AppSession.UserName;
            CreateMenu();
            regionManager.Regions[PrsimManager.MainViewRegionName].RequestNavigate("IndexView");
        }
    }
}
