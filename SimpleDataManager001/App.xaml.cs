using System.Windows;
using System.Windows.Controls;
using Prism.Ioc;
using Prism.Regions;
using SimpleDataManager001.Db.MyEntitys;
using SimpleDataManager001.Db.MyInterface;
using SimpleDataManager001.Views;

namespace SimpleDataManager001
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
       
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // 注册 ViewA 和 ViewB 以便导航
            containerRegistry.RegisterForNavigation<ViewA>("ViewA");

            containerRegistry.Register<DataInterface, MyDb>();
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();
            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RequestNavigate("ContentRegion", "ViewA");
        }
    }
}
