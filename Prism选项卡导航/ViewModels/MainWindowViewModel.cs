using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace Prism选项卡导航.ViewModels
{
    public class MainWindowViewModel : BindableBase 
    {
        private string _title = "Prism Application";

       

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        } 
        public MainWindowViewModel(IRegionManager _regionManager)
        {
            regionManager = _regionManager;
        }

        private DelegateCommand<string> _GoCommad;
        private readonly IRegionManager regionManager;

        public DelegateCommand<string> GoCommad =>
            _GoCommad ?? (_GoCommad = new DelegateCommand<string>(GoCommadCommand));

        private void GoCommadCommand(string uri)
        {
            
            regionManager.RequestNavigate("ContentRegion", new Uri(uri, UriKind.Relative));
        }


        private DelegateCommand<object> _DeleteTabCommand;
        public DelegateCommand<object> DeleteTabCommand =>
            _DeleteTabCommand ?? (_DeleteTabCommand = new DelegateCommand<object>(ExecuteDeleteTabCommand));

        void ExecuteDeleteTabCommand(object content)
        {
            regionManager.Regions["ContentRegion"].Remove(content);
        }
        
    }
}
