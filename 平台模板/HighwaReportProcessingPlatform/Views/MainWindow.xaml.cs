using System.Windows;

namespace HighwaReportProcessingPlatform.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitEvent();
        }

        
        private void InitEvent()
        {
            this.BtnMax.Click += (s, e) => {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                    this.WindowState = WindowState.Maximized;
            };
            this.BtnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };
            this.BtnClose.Click += (s, e) => {
                this.Close();
            };
            //ColorZone.MouseMove += (s, e) =>
            //{
            //    if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            //    {
            //        this.DragMove();
            //    }
            //};
            //ColorZone.MouseDoubleClick += (s, e) =>
            //{
            //    if (this.WindowState == WindowState.Maximized)
            //    {
            //        this.WindowState = WindowState.Normal;
            //    }
            //    else
            //        this.WindowState = WindowState.Maximized;
            //};
            menuBar.SelectionChanged += (s, e) =>
            {
                drawLeftHost.IsLeftDrawerOpen = false;
                // drawLeftHost.IsRightDrawerOpen = true;
            };
        }
    }
}
