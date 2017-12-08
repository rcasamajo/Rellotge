using System;
using System.Windows;
using System.Windows.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Controls;

namespace Rellotge
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string FileName = @"..\..\SavedAlarm.bin";
        private Alarma AlarmaRellotge;

        public MainWindow()
        {
            AlarmaRellotge = new Alarma();
            AlarmaRellotge.HoraAlarma = "11:11";
            AlarmaRellotge.AlarmaActiva = false;

            InitializeComponent();

            lblTime.Content = DateTime.Now.ToLongTimeString();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
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
                AlarmaRellotge = (Alarma)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
            }

            TBAlarma.Text = AlarmaRellotge.HoraAlarma;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Stream TestFileStream = File.Create(FileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(TestFileStream, AlarmaRellotge);
        }

        private void MISortir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MIAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Rellotge digital de DAM2","Rellotge");
        }

        private void tbAlarma_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            AlarmaRellotge.HoraAlarma = TBAlarma.Text;
        }

        private void MINouPais_Click(object sender, RoutedEventArgs e)
        {
            DlgNomPais nouDlg = new DlgNomPais();
            if (nouDlg.ShowDialog() == true)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = nouDlg.Resposta.Trim();
                CBPaisos.Items.Add(item);
            }
        }
    }
}
