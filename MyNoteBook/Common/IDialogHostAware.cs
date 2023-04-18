using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Common
{
    public interface IDialogHostAware 
    {
        string DialogHostName { set;get; }

        /// <summary>
        /// 打开过程中执行
        /// </summary>
        /// <param name="parameters"></param>
        void OnDialogOpend(IDialogParameters parameters);

        DelegateCommand SaveCommand { get; set; }

        DelegateCommand CancelCommand { get; set; }
    }
}
