using MyNoteBook.Common.Models;
using MyNoteBook.Extenstions;
using Prism.Commands;
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
    public class SettingViewModel : BindableBase
    {
        public readonly IRegionManager regionManager;
        public SettingViewModel(IRegionManager regionManager)
        {
            MenuBases = new ObservableCollection<MenuBar>();
            this.regionManager = regionManager;

            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            CreateMenuBar();
        }

        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.NameSpace)) return;
            regionManager.Regions[PrsimManager.SettingViewRegionName].RequestNavigate(obj.NameSpace);
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; set; }
        private ObservableCollection<MenuBar> menuBases;

        public ObservableCollection<MenuBar> MenuBases
        {
            get { return menuBases; }
            set { menuBases = value; RaisePropertyChanged(); }
        }
        void CreateMenuBar()
        {
            MenuBases.Add(new MenuBar() { Icon = "Home", Title = "个性化", NameSpace = "SkinView" });
            MenuBases.Add(new MenuBar() { Icon = "Cog", Title = "系统设置", NameSpace = "" });
            MenuBases.Add(new MenuBar() { Icon = "Information", Title = "关于更多", NameSpace = "AboutView" });
        }
    }
}
