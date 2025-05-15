using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigMoudel.ViewModels
{
    public class SettingViewModel : BindableBase
    {
     
        private readonly IRegionManager regionManager;
         
        public SettingViewModel(IRegionManager regionManager)
        {
             
            this.regionManager = regionManager;
        }

        private DelegateCommand<string> _fieldCommand;
        public DelegateCommand<string> Command =>
            _fieldCommand ?? (_fieldCommand = new DelegateCommand<string>(ExecuteCommand));

        private void ExecuteCommand(string obj)
        {
             regionManager.RequestNavigate(Core.RegionNames.SettingsViewRegionName, obj);
        }

         
    }
}
