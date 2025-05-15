using Prism.Ioc;
using Prism.Regions;
using Prism选项卡导航.Views;
using System;
using System.Windows;
using System.Windows.Media;

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
        // 在 App.xaml.cs 中修改为以下格式
        protected override void OnStartup(StartupEventArgs e)
        {
            // 使用正确的 URI 格式
            var fontUri = new Uri("pack://application:,,,/;component/fonts/fontawesome-webfont.ttf", UriKind.Absolute);

            // 创建字体资源
            var fontFamily = new FontFamily(fontUri, "./#FontAwesome"); // 注意这里的"./"前缀

            // 添加到资源字典
            Resources.Add("FontAwesome", fontFamily);

            base.OnStartup(e);
        }
    }
}
