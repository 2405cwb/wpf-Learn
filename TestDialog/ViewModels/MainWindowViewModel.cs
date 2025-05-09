using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Threading.Tasks;
using System.Windows;
using TestDialog.Entitys;
using TestDialog.Events;

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
        private readonly IEventAggregator eventAggregator;

        public  MainWindowViewModel(IDialogService service, IEventAggregator eventAggregator)
        {

            _dialogService = service;
            this.eventAggregator = eventAggregator;

         
        }

        private DelegateCommand _fieldName;
        public DelegateCommand CommandName =>
            _fieldName ?? (_fieldName = new DelegateCommand(ExecuteCommandName));

        async void ExecuteCommandName()
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("message", new MessageBase() { Title = "提示", Content = "测试" });
            _dialogService.Show("MessageBox", parameters, r =>
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
            await Task.Delay(5000);
            eventAggregator.GetEvent<CloseEvente>().Publish("自动关闭窗体");
        }

        private DelegateCommand _EventeSend;
        public DelegateCommand EventeSend =>
            _EventeSend ?? (_EventeSend = new DelegateCommand(ExecuteEventeSend));

        void ExecuteEventeSend()
        {
            eventAggregator.GetEvent<CloseEvente>().Publish("手动关闭窗体");
        }
    }
}
