using MaterialDesignThemes.Wpf;
using MyNoteBook.Common;
using MyNoteBook.Extenstions;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyNoteBook.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        private readonly IDialogHostService dialogHost;
        public MainView(IEventAggregator aggregator, IDialogHostService dialogHost)
        {
            InitializeComponent();
            menuBar.SelectionChanged += MenuBar_SelectionChanged;
            this.dialogHost=dialogHost;

            //注册提示消息
            aggregator.ResgiterMessage(arg =>
            {
                snackbar.MessageQueue.Enqueue(arg.Message);
            });

            //注册等待消息窗口
            aggregator.Resgiter(arg => { 
            DialogHost.IsOpen = arg.IsOpen;

                if (DialogHost.IsOpen)
                {
                    DialogHost.DialogContent = new ProgressView();

                }
            });

            btnMin.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };


            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }

            };

            btnClose.Click += async (s, e) =>
            {
                var dialogResult = await dialogHost.Question("温馨提示", $"确认退出系统？");

                if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;
                this.Close();
            };

            ColorZone.MouseLeftButtonDown += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };
        }

        private void MenuBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            drawHost.IsLeftDrawerOpen = false;
        }

    }
}
