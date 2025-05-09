using Example;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using TestDialog.Entitys;

namespace TestDialog.ViewModels
{
    public class MessageBoxViewModel : BindableBase, Prism.Services.Dialogs.IDialogAware
    {
        public MessageBoxViewModel()
        {

        }

        public string Title => "提示框";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            
        }

        private MessageBase _data;

        public MessageBase Data
        {
            get { return _data; }
            set { SetProperty(ref _data, value); }
        }

        private DelegateCommand _commCloseDialog;
        public DelegateCommand CommCloseDialogand =>
            _commCloseDialog ?? (_commCloseDialog = new DelegateCommand(ExecuteCommCloseDialog));

        void ExecuteCommCloseDialog()
        {
            MessageBase reData = new MessageBase();
            reData.Title = "返回信息";
            reData.Content = "cwb";
            DialogParameters data = new DialogParameters();
            data.Add("reback", reData);
            RequestClose.Invoke(new DialogResult(ButtonResult.OK, data));
        }
        
        

        public void OnDialogOpened(IDialogParameters parameters)
        { 
            Data =  parameters.GetValue<MessageBase>("message");
            
        }
    }
}
