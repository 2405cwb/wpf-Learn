using ConfigMoudel.ViewModels;
using ConfigMoudel.Views;
using ModuleConfiguration;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace ConfigMoudel
{

    [ModulePriority(
        displayName: "设置",
        priority: 100,
        modelName: nameof(ConfigMoudelModule),
        
        Icon = "Cog")] 
    [Module(ModuleName = nameof(ConfigMoudelModule) ,OnDemand =true)]
    public class ConfigMoudelModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Setting>(nameof(ConfigMoudelModule));
            containerRegistry.RegisterForNavigation<ColorManager, ColorManagerViewModel>(nameof(ColorManager));
        }
    }
}