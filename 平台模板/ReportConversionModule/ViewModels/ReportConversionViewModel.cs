using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReportConversionModule.ViewModels
{
    public class ReportConversionViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ReportConversionViewModel()
        {
            Message = "View A from your Prism Module";
             
        }
    }
}
