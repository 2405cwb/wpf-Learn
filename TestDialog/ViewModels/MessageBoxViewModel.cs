using Example;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using TestDialog.Entitys;
using TestDialog.Events;

namespace TestDialog.ViewModels
{
    public class MessageBoxViewModel : BindableBase, Prism.Services.Dialogs.IDialogAware
    {
        private readonly IEventAggregator _eventAggregator;
        public MessageBoxViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<CloseEvente>().Subscribe(CloseDialog);
        }

        private void CloseDialog(string obj)
        {
            _commCloseDialog?.Execute();
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
            if (RequestClose == null) return; // 防御性编程
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
