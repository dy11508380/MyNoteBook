﻿using MaterialDesignThemes.Wpf;
using MyNoteBook.Common;
using MyNoteBook.Share.Dtos;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.ViewModels.Dialogs
{
    public class AddToDoViewModel : BindableBase, IDialogHostAware
    {
        public AddToDoViewModel()
        {
            SaveCommand = new DelegateCommand(Save);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private NoteBookDto model;

        public NoteBookDto Model
        {
            get { return model; }
            set { model = value;RaisePropertyChanged(); }
        }



        private void Cancel()
        {
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.No));
            }
    
        }

        private void Save()
        {
            if (string.IsNullOrWhiteSpace(model.Title)|| string.IsNullOrWhiteSpace(model.Content))
            {
                return;
            }
            if (DialogHost.IsDialogOpen(DialogHostName))
            {
                DialogParameters param = new DialogParameters();
                param.Add("Value", Model);
                DialogHost.Close(DialogHostName, new DialogResult(ButtonResult.OK, param));
            }

        }

        public string DialogHostName { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }


        public void OnDialogOpend(IDialogParameters parameters)
        {
            if (parameters.ContainsKey("Value"))
            {
                Model = parameters.GetValue<NoteBookDto>("Value");
            }
            else
            {
                Model=new NoteBookDto();
            }
           
        }




    }
}
