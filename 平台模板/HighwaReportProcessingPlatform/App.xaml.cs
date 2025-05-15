using System;
using System.IO;
using System.Reflection;
using System.Windows;
using HighwaReportProcessingPlatform.ViewModels;
using HighwaReportProcessingPlatform.Views;
using Microsoft.Extensions.Configuration;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Serilog;

namespace HighwaReportProcessingPlatform
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

            var environment = "Release"; // 默认 Release 模式
#if DEBUG
            environment = "Debug";
#endif 
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger(); 

            // 3. 注册 ILogger 到 DryIoc 容器
            containerRegistry.RegisterInstance<ILogger>(Log.Logger);
        }
        protected override void OnInitialized()
        {
            var moduleManager = Container.Resolve<IModuleManager>();
            foreach (var module in moduleManager.Modules)
            {
                System.Diagnostics.Debug.WriteLine($"模块: {module.ModuleName}, 状态: {module.State}");
            } 
            base.OnInitialized();
        }
        protected override IModuleCatalog CreateModuleCatalog()
        {
            var s =   new DirectoryModuleCatalog()
            {
                ModulePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules")
            };
            return s;
        }


        //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        //{
        //    moduleCatalog.AddModule<ReportConversionModule.ReportConversionModule>();
        //}

        ////按需加载
        //protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        //{

        //    Type moduleCType = typeof(ReportConversionModule.ReportConversionModule);
        //    moduleCatalog.AddModule(new ModuleInfo()
        //    {
        //        ModuleName = moduleCType.Name,
        //        ModuleType = moduleCType.AssemblyQualifiedName,
        //    });
        //}
        protected override void OnExit(ExitEventArgs e)
        {
            Log.CloseAndFlush();  // 确保日志写入完成
            base.OnExit(e);
        }
    }
}
