using System.Windows;
using Prism.Ioc;
using TestDialog.ViewModels;
using TestDialog.Views;

namespace TestDialog
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
            containerRegistry.RegisterDialogWindow<MessageBoxBase>();
            containerRegistry.RegisterDialog<Views.MessageBox, MessageBoxViewModel>();
        }
    }
}
