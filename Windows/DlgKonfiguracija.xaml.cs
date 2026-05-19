using System;
using System.Windows;
using Microsoft.Data.SqlClient;

namespace WpfAmsterdam
{
    public partial class DlgKonfiguracija : Window
    {
        private string konekcija = Window2.konekcija;

        public DlgKonfiguracija()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void LoadConfig()
        {
            chkKoristiKartice.IsChecked = Window2.KoristiKartice;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            bool koristiKartice = chkKoristiKartice.IsChecked == true;

            try
            {
                using (SqlConnection con = new SqlConnection(konekcija))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(
                        "IF EXISTS (SELECT 1 FROM dbo.Konfiguracija WHERE Kljuc = 'KoristiKartice') " +
                        "UPDATE dbo.Konfiguracija SET Vrednost = @v WHERE Kljuc = 'KoristiKartice' " +
                        "ELSE INSERT INTO dbo.Konfiguracija (Kljuc, Vrednost) VALUES ('KoristiKartice', @v)",
                        con);
                    cmd.Parameters.AddWithValue("@v", koristiKartice ? "1" : "0");
                    cmd.ExecuteNonQuery();
                }

                Window2.KoristiKartice = koristiKartice;

                System.Windows.Forms.MessageBox.Show(
                    "Konfiguracija je sačuvana.",
                    "Uspeh",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Greška pri snimanju: " + ex.Message,
                    "Greška",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
