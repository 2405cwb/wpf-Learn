using Prism.Ioc;
using Prism.Regions;
using Prism选项卡导航.Views;
using System.Windows;

namespace Prism选项卡导航
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
            containerRegistry.RegisterForNavigation<ViewA, ViewModels.ViewAViewModel>(nameof(ViewA));
            containerRegistry.RegisterForNavigation<ViewB, ViewModels.ViewBViewModel>(nameof(ViewB));
        }
    }
}
