using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Share.Dtos
{
    public class UserDto : BaseDtos
    {
        private string? userName;
        private string? account;
        private string? password;

        public string? UserName { get => userName; set { userName = value; OnPropertyChanged(); } }

        public string? Account { get => account; set { account = value; OnPropertyChanged(); } }

        public string? Password { get => password; set { password = value; OnPropertyChanged(); } }
    }
}
