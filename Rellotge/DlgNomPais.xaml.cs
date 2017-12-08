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

        // Donem el focus al TextBox per escriure directament
        private void DlgNomPais1_Loaded(object sender, RoutedEventArgs e)
        {
            TBNomPais.Focus();
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

        // Habilitem o deshabilitem el botó Ok segons si hi ha text o no al TextBox
        // Trim elimina els espais en blanc al principi i final de la cadena
        private void TBNomPais_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (TBNomPais.Text.Trim().Length > 0)
                BtnOk.IsEnabled = true;
            else
                BtnOk.IsEnabled = false;
        }
    }
}
