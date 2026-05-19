using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace WpfAmsterdam
{
    public partial class DlgLogin : Window
    {
        public bool LoginUspeo { get; private set; } = false;
        public bool Izlaz { get; private set; } = false;

        public DlgLogin()
        {
            InitializeComponent();
            this.Loaded += (s, e) => txtSifra.Focus();
        }

        private void txtSifra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Proveri();
            }
            else if (e.Key == Key.Escape)
            {
                Izlaz = true;
                this.Close();
            }
        }

        private void btnPrijava_Click(object sender, RoutedEventArgs e)
        {
            Proveri();
        }

        private void btnIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Izlaz = true;
            this.Close();
        }

        private void Proveri()
        {
            string vrednost = txtSifra.Text.Trim();

            if (string.IsNullOrEmpty(vrednost))
                return;

            // Admin šifra
            if (vrednost == "Daca")
            {
                Window2.daliAdmin = true;
                Window2.KonobarIme = "Admin";
                LoginUspeo = true;
                this.Close();
                return;
            }

            // Provera kartice konobara
            DataRow[] redovi = Window2.tblKonobari.Select("kod = '" + vrednost + "'");
            if (redovi.Length == 1)
            {
                Window2.KonobarId = Convert.ToInt32(redovi[0]["IdKonobar"]);
                Window2.KonobarIme = redovi[0]["Ime"].ToString();
                LoginUspeo = true;
                this.Close();
                return;
            }

            // Neuspešno
            txtPoruka.Text = "Neispravna šifra. Pokušajte ponovo.";
            txtPoruka.Foreground = new System.Windows.Media.SolidColorBrush(
                System.Windows.Media.Color.FromRgb(214, 48, 49));
            txtSifra.Text = "";
            txtSifra.Focus();
        }
    }
}
