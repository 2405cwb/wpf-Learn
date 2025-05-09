using Prism.Commands;
using Prism.Events;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using UserControlDemo.Events;
using UserControlDemo.Utilities;
using UserControlDemo.ViewModels;

namespace UserControlDemo.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IEventAggregator _eventAggregator;

        public MainWindow(IEventAggregator eventAggregator)
        {
            InitializeComponent();
            _eventAggregator = eventAggregator;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 订阅动画事件
            _eventAggregator.GetEvent<StartSliderAnimationEvent>().Subscribe(StartSliderAnimation);
        }
        private void StartSliderAnimation()
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                From = autoSlider.Minimum,
                To = autoSlider.Maximum,
                Duration = TimeSpan.FromSeconds(4),
                RepeatBehavior = RepeatBehavior.Forever
            };
            autoSlider.BeginAnimation(AnimationHelper.AnimatedValueProperty, animation);
        }

       
    }
}
