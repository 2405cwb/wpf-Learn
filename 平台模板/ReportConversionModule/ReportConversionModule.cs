
using Common.Attributes;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ReportConversionModule.ViewModels;
using ReportConversionModule.Views;
using System;
using System.ComponentModel;

namespace ReportConversionModule
{
    [ModulePriority(
        displayName: "报表转换模块",
        priority: 0,
        modelName: nameof(ReportConversionModule),
        description: "用于将各类报表转换为统一格式的模块",
        Icon = "HomeCircleOutline") , 
        ]
    [Module(ModuleName = nameof(ReportConversionModule), OnDemand = true)]
    public class ReportConversionModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ReportConversion>(nameof(ReportConversionModule));
        }
    }
}