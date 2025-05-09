using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Windows;
using TestDialog.Entitys;

namespace TestDialog.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private readonly IDialogService _dialogService;
        public MainWindowViewModel(IDialogService service)
        {

            _dialogService = service;
        }

        private DelegateCommand _fieldName;
        public DelegateCommand CommandName =>
            _fieldName ?? (_fieldName = new DelegateCommand(ExecuteCommandName));

        void ExecuteCommandName()
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("message", new MessageBase() { Title = "提示", Content = "测试" });
            _dialogService.ShowDialog("MessageBox", parameters, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    MessageBase reData = r.Parameters.GetValue<MessageBase>("reback");
                    MessageBox.Show(reData.Content, reData.Title);
                }
                else if (r.Result == ButtonResult.Cancel)
                {
                    // 处理取消按钮点击事件
                }
            });
        }

         
    }
}
