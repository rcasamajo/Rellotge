using System.Windows;
using System.Windows.Input;

namespace Rellotge
{
    /// <summary>
    /// Lógica de interacción para DlgNomPais.xaml
    /// </summary>
    public partial class DlgNomPais : Window
    {
        public DlgNomPais()
        {
            InitializeComponent();
        }

        // La propietat DialogResult és la que es retorna al cridar ShowDialog() per mostrar la finestra
        // No tenim equivalent pel cas de Cancel perquè hem marcat el botó Cancel amb la propietat IsCancel que ho fa auromàticament
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        // Propietat per accedir al text del TextBox des de fora de la classe, al retornar del diàleg
        public string Resposta
        {
            get { return TBNomPais.Text; }
        }

        private void TBNomPais_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (TBNomPais.Text.Length > 0)
                BtnOk.IsEnabled = true;
            else
                BtnOk.IsEnabled = false;
        }
    }
}
