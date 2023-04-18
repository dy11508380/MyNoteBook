using MyNoteBook.Common;
using MyNoteBook.Common.Events;
using Prism.Events;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Extenstions
{
    public static class DialogExtensions
    {
        /// <summary>
        /// 询问窗口
        /// </summary>
        /// <param name="dialogHost"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="dialogHostName"></param>
        /// <returns></returns>
        public static async Task<IDialogResult> Question(this IDialogHostService dialogHost,
            string title,string content,string dialogHostName="Root")
        { 
            DialogParameters dialogParameters = new DialogParameters();
            dialogParameters.Add("Title", title);
            dialogParameters.Add("Content", content);
            dialogParameters.Add("dialogHostName", dialogHostName);

            var dialogResult=await dialogHost.ShowDialog("MsgView", dialogParameters, dialogHostName);
            return dialogResult;
        }

        /// <summary>
        /// 推送等待消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="updateModel"></param>
        public static void UpdateLoading(this IEventAggregator aggregator,UpdateModel updateModel)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Publish(updateModel);
        }

        /// <summary>
        /// 注册等待消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="updateModel"></param>
        public static void Resgiter(this IEventAggregator aggregator, Action<UpdateModel>  updateModel)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(updateModel);
        }

        /// <summary>
        /// 注册提示消息事件
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="action"></param>
        public static void ResgiterMessage(this IEventAggregator aggregator, Action<MessageModel> action,string filterName="Main")
        {
            aggregator.GetEvent<MessageEvent>().Subscribe(action,ThreadOption.PublisherThread,
                true, (m) =>
                {
                    return m.Filter.Equals(filterName);
                });
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="message"></param>
        public static void SendMessage(this IEventAggregator aggregator,string message, string filerName="Main")
        {
            aggregator.GetEvent<MessageEvent>().Publish(new MessageModel()
            {
                Filter = filerName,
                Message = message
            });
        }

    }
}
