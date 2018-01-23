using System;
using System.Windows;
using System.Windows.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace Rellotge
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const string FileName = @"..\..\SavedAlarm.bin";
        private Alarma AlarmaRellotge;
        private ObservableCollection<Pais> Paisos;

        public MainWindow()
        {
            InitializeComponent();

            lblTime.Content = DateTime.Now.ToLongTimeString();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();

            this.Paisos = new ObservableCollection<Pais>();

            // El combo box mostra les dades de la ObservableList de paísos
            CBPaisos.ItemsSource = this.Paisos;
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
            else
                AlarmaRellotge = new Alarma();


            // Fixem el DataContext dels elements on volem fer el Data Binding
            // AlarmaRellotge serà el source (font) de les dades
            CBActiva.DataContext = AlarmaRellotge;
            TBAlarma.DataContext = AlarmaRellotge;
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

        // Quan canvia el text del TextBox de l'hora de l'alarma
        private void tbAlarma_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Només actualitzem l'hora de l'alarma si és una hora vàlida
            if (Regex.IsMatch(TBAlarma.Text, "^[012][0-9]:[0-5][0-9]$"))
            {
                // Actualitzem explícitament el Data Binding
                BindingExpression binding = TBAlarma.GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }

        // Afegir un nou país
        private void MINouPais_Click(object sender, RoutedEventArgs e)
        {
            DlgNomPais nouDlg = new DlgNomPais();
            if (nouDlg.ShowDialog() == true)
            {
                Pais nou = new Pais(nouDlg.Resposta.Trim());
                Paisos.Add(nou);
            }
        }

        private void MICheck_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Alarma object: " + this.AlarmaRellotge.HoraAlarma + " - " + this.AlarmaRellotge.AlarmaActiva);
        }
    }
}
