using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Share.Dtos
{
    public class MemoDto : BaseDtos
    {
        private string title;
        private string content;


        public string Title { get => title; set { title = value; OnPropertyChanged(); } }

        public string Content { get => content; set { content = value; OnPropertyChanged(); } }


    }
}
