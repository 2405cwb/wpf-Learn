using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CwbControls.Controls
{
    public class CwbButton:Button
    {


        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CwbButton), new PropertyMetadata(onCornerRadiusChanged));

        private static void onCornerRadiusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //if (d is CwbButton button)
            //{
            //    button.Content = (CornerRadius)e.NewValue;
            //}
        }
    }
}
