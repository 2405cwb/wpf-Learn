using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism选项卡导航.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prism选项卡导航.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        private string _Title = nameof(ViewB);
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
        public ViewBViewModel()
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
             
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
           return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
    }
}
