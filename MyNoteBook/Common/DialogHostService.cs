using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyNoteBook.Common
{
    /// <summary>
    /// 对话主机服务
    /// </summary>
    public class DialogHostService : DialogService, IDialogHostService
    {
        private readonly IContainerExtension containerExtension;

        public DialogHostService(IContainerExtension containerExtension) : base(containerExtension)
        {
            this.containerExtension = containerExtension;
        }

        public async Task<IDialogResult> ShowDialog(string name, IDialogParameters paramters, string dialogHostname = "Root")
        {
            if (paramters==null)
            {
                paramters = new DialogParameters();
            }

            //从容器当中弹出窗口实例
            var content = containerExtension.Resolve<object>(name);

            if (!(content is FrameworkElement dialogcontent))
            {
                throw new NullReferenceException("A dialog's content must be a FrameworkElement");
            }
            if (dialogcontent is FrameworkElement view && view.DataContext is null && ViewModelLocator.GetAutoWireViewModel(view) is null)
            {
                ViewModelLocator.SetAutoWireViewModel(view, true);
            }
            if (!(dialogcontent.DataContext is IDialogHostAware viewModel))
            {
                throw new NullReferenceException("A dialog's content must implement the IDialogware interface");
            }

            viewModel.DialogHostName = dialogHostname;

            DialogOpenedEventHandler eventHandler = (sender, args) => {
                if (viewModel is IDialogHostAware aware)
                {
                    aware.OnDialogOpend(paramters);
                }

                args.Session.UpdateContent(content);
            };

            return (IDialogResult)await DialogHost.Show(dialogcontent, viewModel.DialogHostName, eventHandler);
        }
    }
}
