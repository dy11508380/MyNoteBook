﻿using MyNoteBook.Extenstions;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNoteBook.ViewModels
{
    public class NavigationViewModel : BindableBase, INavigationAware
    {
        private readonly IContainerProvider containerProvider;
        protected readonly IEventAggregator aggregator;

        public NavigationViewModel(IContainerProvider containerProvider) 
        {
            this.containerProvider = containerProvider;
            aggregator= this.containerProvider.Resolve<IEventAggregator>();
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
             
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public void UpdateLoading(bool isOpen)
        {
            aggregator.UpdateLoading(new Common.Events.UpdateModel() { 
            IsOpen = isOpen
            });
        }
    }
}
