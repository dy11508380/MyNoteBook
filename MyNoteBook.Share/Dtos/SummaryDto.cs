using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.Share.Dtos
{
    public class SummaryDto:BaseDtos
    {
        private int sum;
        private int completedCount;
        private int memoCount;
        private string completedRadio;

        private ObservableCollection<NoteBookDto> todoList;
        private ObservableCollection<MemoDto> memoList;

        public ObservableCollection<NoteBookDto> TodoList { get => todoList; set { todoList = value; OnPropertyChanged(); } }
        public ObservableCollection<MemoDto> MemoList { get => memoList; set { memoList = value; OnPropertyChanged(); } }

        public int Sum { get => sum; set { sum = value; OnPropertyChanged(); } }
        public int CompletedCount { get => completedCount; set { completedCount = value; OnPropertyChanged(); } }
        public int MemoCount { get => memoCount; set { memoCount = value; OnPropertyChanged(); } }
        public string CompletedRadio { get => completedRadio; set { completedRadio = value; OnPropertyChanged(); } }
    }
}
