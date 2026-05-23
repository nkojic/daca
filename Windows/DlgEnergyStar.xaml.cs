using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.Sqlite;

namespace WpfAmsterdam
{
    public partial class DlgEnergyStar : Window
    {
        private string konekcija = Window2.konekcija;
        private List<ArtikalES> sviArtikli;
        private List<EsProizvod> sviES;
        private ObservableCollection<ArtikalES> listaArtikala;
        private ObservableCollection<EsProizvod> listaES;

        public DlgEnergyStar()
        {
            InitializeComponent();

            double screenWidth = SystemParameters.PrimaryScreenWidth;
            this.Width = screenWidth * 0.8;
            this.Height = SystemParameters.PrimaryScreenHeight * 0.75;

            LoadArtikli();
            LoadEnergyStarKatalog();
            UkloniVecUpareneIzDesne();
            UpdateButtonStates();
        }

        private void LoadArtikli()
        {
            try
            {
                DataTable dt = DatabaseHelper.ReaderTabela(konekcija,
                    "SELECT IdArtikal, Naziv, EsIdArtikla, EsNazivArtikla FROM Artikli WHERE aktivan = 1 ORDER BY Naziv");

                sviArtikli = new List<ArtikalES>();
                foreach (DataRow row in dt.Rows)
                {
                    sviArtikli.Add(new ArtikalES
                    {
                        IdArtikla = Convert.ToInt32(row["IdArtikal"]),
                        ImeArtikla = row["Naziv"].ToString(),
                        IdArtiklaES = row["EsIdArtikla"]?.ToString() ?? "",
                        ImeArtiklaES = row["EsNazivArtikla"]?.ToString() ?? ""
                    });
                }
                listaArtikala = new ObservableCollection<ArtikalES>(sviArtikli);
                dgArtikli.ItemsSource = listaArtikala;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Greška pri učitavanju artikala: " + ex.Message);
            }
        }

        private void LoadEnergyStarKatalog()
        {
            // Fake podaci - kasnije će dolaziti iz eksterne baze
            sviES = new List<EsProizvod>
            {
                new EsProizvod { IdArtiklaES = "ES-1001", ImeArtiklaES = "Dom Perignon 75cl" },
                new EsProizvod { IdArtiklaES = "ES-1002", ImeArtiklaES = "Dom Perignon Rose 75cl" },
                new EsProizvod { IdArtiklaES = "ES-1003", ImeArtiklaES = "Moet Chandon Brut 75cl" },
                new EsProizvod { IdArtiklaES = "ES-1004", ImeArtiklaES = "Moet Chandon Rose 75cl" },
                new EsProizvod { IdArtiklaES = "ES-1005", ImeArtiklaES = "Veuve Clicquot Brut 75cl" },
                new EsProizvod { IdArtiklaES = "ES-1006", ImeArtiklaES = "Veuve Clicquot Rose 75cl" },
                new EsProizvod { IdArtiklaES = "ES-1007", ImeArtiklaES = "Krug Grande Cuvee 75cl" },
                new EsProizvod { IdArtiklaES = "ES-1008", ImeArtiklaES = "Hennessy VS 70cl" },
                new EsProizvod { IdArtiklaES = "ES-1009", ImeArtiklaES = "Hennessy VSOP 70cl" },
                new EsProizvod { IdArtiklaES = "ES-1010", ImeArtiklaES = "Hennessy XO 70cl" },
                new EsProizvod { IdArtiklaES = "ES-1011", ImeArtiklaES = "Belvedere Vodka 70cl" },
                new EsProizvod { IdArtiklaES = "ES-1012", ImeArtiklaES = "Belvedere Vodka 1.75L" },
                new EsProizvod { IdArtiklaES = "ES-1013", ImeArtiklaES = "Glenmorangie Original 70cl" },
                new EsProizvod { IdArtiklaES = "ES-1014", ImeArtiklaES = "Ardbeg 10YO 70cl" },
                new EsProizvod { IdArtiklaES = "ES-1015", ImeArtiklaES = "Chandon Garden Spritz 75cl" },
            };
            listaES = new ObservableCollection<EsProizvod>(sviES);
            dgEnergyStar.ItemsSource = listaES;
        }

        /// <summary>
        /// Ukloni iz desne tabele artikle koji su već upareni u levoj
        /// </summary>
        private void UkloniVecUpareneIzDesne()
        {
            var upareniIds = sviArtikli
                .Where(a => !string.IsNullOrEmpty(a.IdArtiklaES))
                .Select(a => a.IdArtiklaES)
                .ToHashSet();

            var zaUklanjanje = listaES.Where(es => upareniIds.Contains(es.IdArtiklaES)).ToList();
            foreach (var es in zaUklanjanje)
                listaES.Remove(es);

            // Ažuriraj i sviES listu
            sviES.RemoveAll(es => upareniIds.Contains(es.IdArtiklaES));
        }

        private void SacuvajUparivanje(int idArtikla, string esId, string esNaziv)
        {
            try
            {
                using (var con = new SqliteConnection(konekcija))
                {
                    con.Open();
                    using (var cmd = new SqliteCommand(
                        "UPDATE Artikli SET EsIdArtikla = @esId, EsNazivArtikla = @esNaziv WHERE IdArtikal = @id", con))
                    {
                        cmd.Parameters.AddWithValue("@esId", esId);
                        cmd.Parameters.AddWithValue("@esNaziv", esNaziv);
                        cmd.Parameters.AddWithValue("@id", idArtikla);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Greška pri čuvanju uparivanja: " + ex.Message);
            }
        }

        private void txtPretragaLevo_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = txtPretragaLevo.Text.Trim().ToLower();
            listaArtikala.Clear();
            foreach (var a in sviArtikli)
            {
                if (string.IsNullOrEmpty(filter) ||
                    a.IdArtikla.ToString().Contains(filter) ||
                    a.ImeArtikla.ToLower().Contains(filter) ||
                    a.IdArtiklaES.ToLower().Contains(filter) ||
                    a.ImeArtiklaES.ToLower().Contains(filter))
                {
                    listaArtikala.Add(a);
                }
            }
            UpdateButtonStates();
        }

        private void txtPretragaDesno_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filter = txtPretragaDesno.Text.Trim().ToLower();
            listaES.Clear();
            foreach (var es in sviES)
            {
                if (string.IsNullOrEmpty(filter) ||
                    es.IdArtiklaES.ToLower().Contains(filter) ||
                    es.ImeArtiklaES.ToLower().Contains(filter))
                {
                    listaES.Add(es);
                }
            }
            UpdateButtonStates();
        }

        private void dgArtikli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonStates();
        }

        private void dgEnergyStar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonStates();
        }

        private object lastSelectedLevo = null;
        private object lastSelectedDesno = null;

        private void dgArtikli_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var row = FindParent<DataGridRow>(e.OriginalSource as DependencyObject);
            if (row != null && row.DataContext == lastSelectedLevo)
            {
                dgArtikli.SelectedItem = null;
                lastSelectedLevo = null;
                e.Handled = true;
                return;
            }
            lastSelectedLevo = row?.DataContext;
        }

        private void dgEnergyStar_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var row = FindParent<DataGridRow>(e.OriginalSource as DependencyObject);
            if (row != null && row.DataContext == lastSelectedDesno)
            {
                dgEnergyStar.SelectedItem = null;
                lastSelectedDesno = null;
                e.Handled = true;
                return;
            }
            lastSelectedDesno = row?.DataContext;
        }

        private static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            while (child != null)
            {
                if (child is T parent) return parent;
                child = System.Windows.Media.VisualTreeHelper.GetParent(child);
            }
            return null;
        }

        private void UpdateButtonStates()
        {
            var selLevo = dgArtikli.SelectedItem as ArtikalES;
            var selDesno = dgEnergyStar.SelectedItem as EsProizvod;

            bool imaLevo = selLevo != null;
            bool imaDesno = selDesno != null;
            bool leviUparen = imaLevo && !string.IsNullOrEmpty(selLevo.IdArtiklaES);

            btnUpari.IsEnabled = imaLevo && imaDesno;
            btnRaspari.IsEnabled = imaLevo && !imaDesno && leviUparen;
        }

        private void btnUpari_Click(object sender, RoutedEventArgs e)
        {
            var selLevo = dgArtikli.SelectedItem as ArtikalES;
            var selDesno = dgEnergyStar.SelectedItem as EsProizvod;

            if (selLevo == null || selDesno == null) return;

            // Ako levi red već ima uparivanje, vrati stari artikl u desnu tabelu
            if (!string.IsNullOrEmpty(selLevo.IdArtiklaES))
            {
                var stari = new EsProizvod { IdArtiklaES = selLevo.IdArtiklaES, ImeArtiklaES = selLevo.ImeArtiklaES };
                sviES.Add(stari);
                listaES.Add(stari);
            }

            // Upiši podatke iz desne tabele u 3. i 4. kolonu leve
            selLevo.IdArtiklaES = selDesno.IdArtiklaES;
            selLevo.ImeArtiklaES = selDesno.ImeArtiklaES;

            // Skloni artikl iz desne tabele
            listaES.Remove(selDesno);
            sviES.Remove(selDesno);

            // Sačuvaj u bazu
            SacuvajUparivanje(selLevo.IdArtikla, selLevo.IdArtiklaES, selLevo.ImeArtiklaES);

            dgArtikli.Items.Refresh();
            dgEnergyStar.SelectedItem = null;
            UpdateButtonStates();
        }

        private void btnRaspari_Click(object sender, RoutedEventArgs e)
        {
            var selLevo = dgArtikli.SelectedItem as ArtikalES;

            if (selLevo == null || string.IsNullOrEmpty(selLevo.IdArtiklaES)) return;

            // Vrati artikl u desnu tabelu samo ako postoji u ES katalogu
            // (ako ne postoji više, samo brišemo uparivanje)
            var stari = new EsProizvod { IdArtiklaES = selLevo.IdArtiklaES, ImeArtiklaES = selLevo.ImeArtiklaES };
            sviES.Add(stari);
            listaES.Add(stari);

            // Obriši 3. i 4. kolonu
            selLevo.IdArtiklaES = "";
            selLevo.ImeArtiklaES = "";

            // Sačuvaj u bazu (prazne vrednosti)
            SacuvajUparivanje(selLevo.IdArtikla, "", "");

            dgArtikli.Items.Refresh();
            UpdateButtonStates();
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class ArtikalES
    {
        public int IdArtikla { get; set; }
        public string ImeArtikla { get; set; }
        public string IdArtiklaES { get; set; }
        public string ImeArtiklaES { get; set; }
        public string Upareno => string.IsNullOrEmpty(IdArtiklaES) ? "" : "Da";
    }

    public class EsProizvod
    {
        public string IdArtiklaES { get; set; }
        public string ImeArtiklaES { get; set; }
    }
}
