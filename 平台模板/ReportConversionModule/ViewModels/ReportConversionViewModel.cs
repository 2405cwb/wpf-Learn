using Microsoft.VisualBasic;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReportConversionModule.ViewModels
{
    public class ReportConversionViewModel : BindableBase
    {
        public ReportConversionViewModel()
        {
            Message = "View A from your Prism Module";

            for (int i = 0; i < 100; i++)
            {
                filePaths.Add("FilePath is :" + i  + ".1xlsx");
            }

        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }

            
        }

        private ObservableCollection<string> filePaths = new ObservableCollection<string>();
        public ObservableCollection<string> FilePaths
        {
            get { return filePaths; }
            set { SetProperty(ref filePaths, value); }
        }

        private DelegateCommand _fieldName;
        public DelegateCommand CommandName =>
            _fieldName ?? (_fieldName = new DelegateCommand(ExecuteCommandName));

        void ExecuteCommandName()
        {

        }

      
    }
}
