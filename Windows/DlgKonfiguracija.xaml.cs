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

            // Tema
            foreach (string tema in ThemeManager.ThemeNames)
                cmbTema.Items.Add(tema);
            cmbTema.SelectedItem = ThemeManager.CurrentTheme;
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            bool koristiKartice = chkKoristiKartice.IsChecked == true;
            string tema = cmbTema.SelectedItem?.ToString() ?? "Light Minimalist";

            try
            {
                using (SqlConnection con = new SqlConnection(konekcija))
                {
                    con.Open();

                    // Kartice
                    SaveConfig(con, "KoristiKartice", koristiKartice ? "1" : "0");

                    // Tema
                    SaveConfig(con, "Tema", tema);
                }

                Window2.KoristiKartice = koristiKartice;
                ThemeManager.CurrentTheme = tema;

                System.Windows.Forms.MessageBox.Show(
                    "Konfiguracija je sačuvana.\nPromenjena tema se primenjuje nakon ponovnog pokretanja.",
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

        private void SaveConfig(SqlConnection con, string kljuc, string vrednost)
        {
            SqlCommand cmd = new SqlCommand(
                "IF EXISTS (SELECT 1 FROM dbo.Konfiguracija WHERE Kljuc = @k) " +
                "UPDATE dbo.Konfiguracija SET Vrednost = @v WHERE Kljuc = @k " +
                "ELSE INSERT INTO dbo.Konfiguracija (Kljuc, Vrednost) VALUES (@k, @v)",
                con);
            cmd.Parameters.AddWithValue("@k", kljuc);
            cmd.Parameters.AddWithValue("@v", vrednost);
            cmd.ExecuteNonQuery();
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
