using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Share.Dtos
{
    public class NoteBookDto : BaseDtos
    {
        private string? title;
        private string? content;
        private int status;

        public string? Title { get => title; set  { title = value; OnPropertyChanged(); } }

        public string? Content { get => content; set { content = value; OnPropertyChanged(); } }

        public int Status { get => status; set { status = value; OnPropertyChanged(); } }
    }
}
