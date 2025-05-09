using SimpleDataManager001.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SimpleDataManager001.Views
{
    /// <summary>
    /// UserChangeForm.xaml 的交互逻辑
    /// </summary>
    public partial class UserChangeForm : Window
    {
        public UserChangeForm(User user)
        {
            InitializeComponent();
           
            this.DataContext = new
            {
                Model = user,
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult  = true;
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
