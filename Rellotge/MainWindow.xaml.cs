using System;
using System.Windows;
using System.Windows.Threading;

namespace Rellotge
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            lblTime.Content = DateTime.Now.ToLongTimeString();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
