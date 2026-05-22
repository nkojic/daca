using System.Windows;

namespace WpfAmsterdam
{
    public partial class DlgEnergyStar : Window
    {
        public DlgEnergyStar()
        {
            InitializeComponent();
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
