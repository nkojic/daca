using System;
using System.Windows;
using Microsoft.Data.Sqlite;

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
                using (SqliteConnection con = new SqliteConnection(konekcija))
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

        private void SaveConfig(SqliteConnection con, string kljuc, string vrednost)
        {
            using (SqliteCommand cmd = new SqliteCommand(
                "INSERT OR REPLACE INTO Konfiguracija (Kljuc, Vrednost) VALUES (@k, @v)", con))
            {
                cmd.Parameters.AddWithValue("@k", kljuc);
                cmd.Parameters.AddWithValue("@v", vrednost);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnKategorije_Click(object sender, RoutedEventArgs e)
        {
            DlgCrudEditor dlg = new DlgCrudEditor("Kategorija",
                "SELECT IdKat, Kategorija, aktivna FROM Kategorija",
                new string[] { "IdKat", "Kategorija", "aktivna" },
                "IdKat", "aktivna");
            dlg.ShowDialog();
        }

        private void btnKategorije1_Click(object sender, RoutedEventArgs e)
        {
            DlgCrudEditor dlg = new DlgCrudEditor("Kategorija1",
                "SELECT IdKat1, IdKat, PodKat, aktivna FROM Kategorija1",
                new string[] { "IdKat1", "IdKat", "PodKat", "aktivna" },
                "IdKat1", "aktivna");
            dlg.ShowDialog();
        }

        private void btnArtikli_Click(object sender, RoutedEventArgs e)
        {
            DlgCrudEditor dlg = new DlgCrudEditor("Artikli",
                "SELECT IdArtikal, IdKat1, broj, Naziv, NazivKasa, Tip, ProdajnaJedMere, Price, Cost, aktivan, daliProdaja FROM Artikli",
                new string[] { "IdArtikal", "IdKat1", "broj", "Naziv", "NazivKasa", "Tip", "ProdajnaJedMere", "Price", "Cost", "aktivan", "daliProdaja" },
                "IdArtikal", "aktivan");
            dlg.ShowDialog();
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
