using Microsoft.Win32;
using MyNoteBook.Common;
using MyNoteBook.Extenstions;
using MyNoteBook.Service;
using MyNoteBook.Share.Dtos;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        private readonly ILoginService loginService;

        private readonly IEventAggregator aggregator;
        public LoginViewModel(ILoginService loginService, IEventAggregator aggregator)
        {
            UserDto = new RegisterUserDto();
            this.loginService = loginService;
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.aggregator = aggregator;
        }

        private int selectIndex;

        public int SelectedIndex
        {
            get { return selectIndex; }
            set { selectIndex = value;RaisePropertyChanged(); }
        }


        private void Execute(string obj)
        {
            switch (obj)
            {
                case "Login":Login(); break;
                case "loginOut": LoginOut(); break;
                case "Go": SelectedIndex=1; break;
                case "Register": Register(); break;
                case "Return": SelectedIndex = 0; break;
                default:
                    break;
            }
        }


        private async void Register()
        {
            if (string.IsNullOrWhiteSpace(UserDto.Account) ||string.IsNullOrWhiteSpace(UserDto.Password)
                || string.IsNullOrWhiteSpace(UserDto.NewPassword)
                || string.IsNullOrWhiteSpace(UserDto.UserName))
            {
                return;
            }

            if (UserDto.NewPassword!= UserDto.Password)
            {
                aggregator.SendMessage("两次输入的密码不一致，请检查", "Login");
                return;
            }

            var regResult=  await loginService.RegisterAsync(new Share.Dtos.UserDto()
            {
                Account=UserDto.Account,
                UserName=UserDto.UserName,
                Password=UserDto.Password,
            });

            if (regResult!=null&&regResult.Status)
            {
                aggregator.SendMessage("注册成功", "Login");
                SelectedIndex = 0;
                return;
            }

            aggregator.SendMessage(regResult.Message, "Login");
        }

        private void LoginOut()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        private async void Login()
        {
            if (string.IsNullOrWhiteSpace(account)||
                string.IsNullOrWhiteSpace(Password))
            {
                return;
            }

            var logresult = await loginService.LoginAsync(new Share.Dtos.UserDto()
            {
                Account = account,
                Password = password
            });

            if (logresult.Status)
            {
                AppSession.UserName = logresult.Result.UserName;
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
                return;
            }

            aggregator.SendMessage(logresult.Message, "Login");
        }

        public string Title { get; set; } = "NoteBook";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            LoginOut();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
           
        }

        public DelegateCommand<string> ExecuteCommand { get; private set; }

        private string account;

        public string Account
        {
            get { return account; }
            set { account = value;RaisePropertyChanged(); }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private RegisterUserDto userDto;

        public RegisterUserDto UserDto
        {
            get { return userDto; }
            set { userDto = value; RaisePropertyChanged(); }
        }


    }
}
