using System;
using System.Windows;
using System.Windows.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Rellotge
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string FileName = @"..\..\SavedAlarm.bin";
        private Alarma alarm;

        public MainWindow()
        {
            alarm = new Alarma();
            alarm.horaAlarma = "11:11";
            alarm.alarmaActiva = false;

            InitializeComponent();

            lblTime.Content = DateTime.Now.ToLongTimeString();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            comboBox.SelectedIndex = 0;
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToLongTimeString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(FileName))
            {
                Stream TestFileStream = File.OpenRead(FileName);
                BinaryFormatter deserializer = new BinaryFormatter();
                alarm = (Alarma)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
            }

            TBAlarma.Text = alarm.horaAlarma;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Stream TestFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(TestFileStream, alarm);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Rellotge digital de DAM2","Rellotge");
        }

        private void tbAlarma_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            alarm.horaAlarma = TBAlarma.Text;
        }
    }
}
