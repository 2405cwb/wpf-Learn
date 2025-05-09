using Prism.Mvvm;
using System.Windows.Input;
using System;
using Prism.Events;
using Prism.Commands;
using UserControlDemo.Events;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows;

namespace UserControlDemo.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private string textValue;

        public string TextValue
        {
            get { return textValue; }
            set {
                SetProperty(ref textValue, value);
                if (string.IsNullOrEmpty(value))
                {

                    IsEnabled = false;
                }
                else
                {
                    IsEnabled = true;
                }
            }
        }


        private bool isEnabled =false;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }


        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand StartAnimationCommand { get; }
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private double corValue= 0 ;

        public double CorValue
        {
            get { return corValue; }
            set {
                if (SetProperty(ref corValue, value))
                {
                    Console.WriteLine($"CorValue changed to: {value}");
                }
            }
        }

       

        public event EventHandler RequestStartAnimation;

        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            StartAnimationCommand = new DelegateCommand(OnStartAnimation);
        }
        
        private void OnStartAnimation()
        {
            // 发布动画启动事件
            _eventAggregator.GetEvent<StartSliderAnimationEvent>().Publish();
        }

        private List<Test> data = new List<Test>() {  new Test() { Name = "Test1" }, new Test() { Name = "Test2" }, new Test() { Name = "Test3" } };

        public List<Test> Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }

        private DelegateCommand<Test> _fieldName;
        public DelegateCommand<Test> CommandName =>
           _fieldName ?? (_fieldName = new DelegateCommand<Test>(ExecuteCommandName).ObservesCanExecute(() => IsEnabled)); 
            //_fieldName ?? (_fieldName = new DelegateCommand<Test>(ExecuteCommandName));

        void ExecuteCommandName(Test parameter)
        {
            MessageBox.Show($"You clicked {parameter.Name}!");
        }

    }

    public class Test 
    {
        public string Name { get; set; }
    }
}
