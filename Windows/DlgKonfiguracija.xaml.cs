using System;
using System.Collections.Generic;
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
            var lookups = new Dictionary<string, (string sql, string valueMember, string displayMember)>
            {
                { "IdKat", ("SELECT IdKat, Kategorija FROM Kategorija ORDER BY Kategorija", "IdKat", "Kategorija") }
            };
            DlgCrudEditor dlg = new DlgCrudEditor("Kategorija1",
                "SELECT IdKat1, IdKat, PodKat, aktivna FROM Kategorija1",
                new string[] { "IdKat1", "IdKat", "PodKat", "aktivna" },
                "IdKat1", "aktivna", lookups: lookups);
            dlg.ShowDialog();
        }

        private void btnArtikli_Click(object sender, RoutedEventArgs e)
        {
            var lookups = new Dictionary<string, (string sql, string valueMember, string displayMember)>
            {
                { "IdKat1", ("SELECT IdKat1, PodKat FROM Kategorija1 ORDER BY PodKat", "IdKat1", "PodKat") }
            };
            DlgCrudEditor dlg = new DlgCrudEditor("Artikli",
                "SELECT IdArtikal, IdKat1, broj, Naziv, NazivKasa, Tip, ProdajnaJedMere, Price, Cost, aktivan, daliProdaja FROM Artikli",
                new string[] { "IdArtikal", "IdKat1", "broj", "Naziv", "NazivKasa", "Tip", "ProdajnaJedMere", "Price", "Cost", "aktivan", "daliProdaja" },
                "IdArtikal", "aktivan", lookups: lookups);
            dlg.ShowDialog();
        }

        private void btnKonobari_Click(object sender, RoutedEventArgs e)
        {
            DlgCrudEditor dlg = new DlgCrudEditor("Konobari",
                "SELECT IdKonobar, Ime, Kod, aktivan FROM Konobari",
                new string[] { "IdKonobar", "Ime", "Kod", "aktivan" },
                "IdKonobar", "aktivan",
                (dataTable, con, txn) =>
                {
                    // Sinhronizuj KonobariKodoviKartica sa Kod kolonom
                    foreach (System.Data.DataRow row in dataTable.Rows)
                    {
                        if (row.RowState == System.Data.DataRowState.Deleted) continue;
                        int id = Convert.ToInt32(row["IdKonobar"]);
                        string kod = row["Kod"].ToString();

                        // Ažuriraj BrojKartice u Konobari da pokazuje na IdKonobar
                        using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(
                            "UPDATE Konobari SET BrojKartice = @id WHERE IdKonobar = @id", con, txn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // Upsert u KonobariKodoviKartica
                        using (var cmd = new Microsoft.Data.Sqlite.SqliteCommand(
                            "INSERT OR REPLACE INTO KonobariKodoviKartica (IdKod, Kod) VALUES (@id, @kod)", con, txn))
                        {
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.Parameters.AddWithValue("@kod", kod);
                            cmd.ExecuteNonQuery();
                        }
                    }
                });
            dlg.ShowDialog();
        }

        private void btnEnergyStar_Click(object sender, RoutedEventArgs e)
        {
            DlgEnergyStar dlg = new DlgEnergyStar();
            dlg.ShowDialog();
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
