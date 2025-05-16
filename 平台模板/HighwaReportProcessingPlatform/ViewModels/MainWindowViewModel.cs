using HighwaReportProcessingPlatform.Configuration; 
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Windows.Documents;
using Core;
using Serilog;
using System.Reflection.Emit;
using Common.Attributes;
namespace HighwaReportProcessingPlatform.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IRegionManager regionManager, IModuleManager moduleManager,ILogger logger)
        {
            _regionManager = regionManager;
            _moduleManager = moduleManager;
            _logger = logger;
            _logger.Information( nameof(MainWindowViewModel)+" 已初始化"); 
        }
        private readonly ILogger _logger;

        private readonly IRegionManager _regionManager;
        private readonly IModuleManager _moduleManager = null;


        private string _UserName = Core.StaticConstString.InitUserName  ;
        public string UserName
        {
            get { return _UserName  ; }
            set { SetProperty(ref _UserName  , value); }
        }

       
        private string _title =Core.StaticConstString.Title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        

        private ObservableCollection<EnumItemNameMapper> _ModelsItems = new ObservableCollection<EnumItemNameMapper>();
        public ObservableCollection<EnumItemNameMapper> ModelsItems
        {
            get { return _ModelsItems; }
            set { SetProperty(ref _ModelsItems, value); }
        }


        private DelegateCommand<EnumItemNameMapper> _ModuleCommand;
        public DelegateCommand<EnumItemNameMapper> ModuleCommand =>
           _ModuleCommand ?? (_ModuleCommand = new DelegateCommand<EnumItemNameMapper>(ExecuteCommandName));

        private void ExecuteCommandName(EnumItemNameMapper item)
        {
           
            _regionManager.RequestNavigate(Core.RegionNames.ContentRegion, item.ModelName, navigationResult =>
            {
                if (navigationResult.Result.HasValue)
                {
                    System.Diagnostics.Debug.WriteLine($"导航结果: {navigationResult.Result.Value}");
                    journal = navigationResult.Context.NavigationService.Journal;
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"导航失败: {navigationResult.Error}");
                }
            });
        }


        private DelegateCommand _LoadMoudlesCommand;
        public DelegateCommand LoadMoudlesCommand =>
            _LoadMoudlesCommand ?? (_LoadMoudlesCommand = new DelegateCommand(ExecuteLoadMoudlesCommand));

        void ExecuteLoadMoudlesCommand()
        {
         
            ModelsItems.Clear();
            var sortedModules = _moduleManager.Modules
                  .OrderBy(m =>
                  {
                      var type = Type.GetType(m.ModuleType);
                      var priorityAttr = type?.GetCustomAttribute<ModulePriorityAttribute>();
                      return priorityAttr?.Priority ?? 0; // 默认优先级为 0
                  });
            foreach (var module in sortedModules)
            {
                var type = Type.GetType(module.ModuleType);
                var priorityAttr = type?.GetCustomAttribute<ModulePriorityAttribute>();

            

                string result = priorityAttr.ModelName ;
                if (!string.IsNullOrEmpty(result))
                {
                    EnumItemNameMapper item = new EnumItemNameMapper();
                    item.Icon = priorityAttr.Icon;
                    item.DisPlayName = priorityAttr.DisplayName;
                    item.ModelName = module.ModuleName;
                    item.Description = priorityAttr.Description; 
                    ModelsItems.Add(item);
                    _moduleManager.LoadModule(module.ModuleName);
                }  
            }
            
        }

        private IRegionNavigationJournal journal;
        private DelegateCommand _GoBackCommad;
        public DelegateCommand GoBackCommad =>
            _GoBackCommad ?? (_GoBackCommad = new DelegateCommand(ExecuteGoBackCommad));

        void ExecuteGoBackCommad()
        {
            if (journal != null && journal.CanGoBack)
                journal.GoBack();
        }
        private DelegateCommand _GoForwardCommad;
        public DelegateCommand GoForwardCommand =>
            _GoForwardCommad ?? (_GoForwardCommad = new DelegateCommand(GoForward));

        private void GoForward()
        {
            if (journal != null && journal.CanGoForward)
                journal.GoForward();
        }

    }
}
