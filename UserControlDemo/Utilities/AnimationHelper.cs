using System.Windows;
using System;
using System.Windows.Controls;
using UserControlDemo.ViewModels;

namespace UserControlDemo.Utilities
{
    public static class AnimationHelper
    {
        public static readonly DependencyProperty AnimatedValueProperty =
            DependencyProperty.RegisterAttached(
                "AnimatedValue",
                typeof(double),
                typeof(AnimationHelper),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    AnimatedValueChanged));

        public static double GetAnimatedValue(DependencyObject obj)
        {
            return (double)obj.GetValue(AnimatedValueProperty);
        }

        public static void SetAnimatedValue(DependencyObject obj, double value)
        {
            obj.SetValue(AnimatedValueProperty, value);
        }

        private static void AnimatedValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Slider slider && slider.DataContext is MainWindowViewModel vm)
            {
                vm.CorValue = (double)e.NewValue;
            }
            // 调试用：确认值变化
            Console.WriteLine($"AnimatedValue changed to: {e.NewValue}");
        }
    }
}