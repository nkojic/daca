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
            UpdateButtonStates();
        }

        private void LoadArtikli()
        {
            try
            {
                DataTable dt = DatabaseHelper.ReaderTabela(konekcija,
                    "SELECT IdArtikal, Naziv FROM Artikli WHERE aktivan = 1 ORDER BY Naziv");

                listaArtikala = new ObservableCollection<ArtikalES>();
                foreach (DataRow row in dt.Rows)
                {
                    listaArtikala.Add(new ArtikalES
                    {
                        IdArtikla = Convert.ToInt32(row["IdArtikal"]),
                        ImeArtikla = row["Naziv"].ToString(),
                        IdArtiklaES = "",
                        ImeArtiklaES = ""
                    });
                }
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
            listaES = new ObservableCollection<EsProizvod>
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
            dgEnergyStar.ItemsSource = listaES;
        }

        private void dgArtikli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonStates();
        }

        private void dgEnergyStar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtonStates();
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
                listaES.Add(new EsProizvod { IdArtiklaES = selLevo.IdArtiklaES, ImeArtiklaES = selLevo.ImeArtiklaES });
            }

            // Upiši podatke iz desne tabele u 3. i 4. kolonu leve
            selLevo.IdArtiklaES = selDesno.IdArtiklaES;
            selLevo.ImeArtiklaES = selDesno.ImeArtiklaES;

            // Skloni artikl iz desne tabele
            listaES.Remove(selDesno);

            dgArtikli.Items.Refresh();
            dgEnergyStar.SelectedItem = null;
            UpdateButtonStates();
        }

        private void btnRaspari_Click(object sender, RoutedEventArgs e)
        {
            var selLevo = dgArtikli.SelectedItem as ArtikalES;

            if (selLevo == null || string.IsNullOrEmpty(selLevo.IdArtiklaES)) return;

            // Vrati artikl u desnu tabelu
            listaES.Add(new EsProizvod { IdArtiklaES = selLevo.IdArtiklaES, ImeArtiklaES = selLevo.ImeArtiklaES });

            // Obriši 3. i 4. kolonu
            selLevo.IdArtiklaES = "";
            selLevo.ImeArtiklaES = "";

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
    }

    public class EsProizvod
    {
        public string IdArtiklaES { get; set; }
        public string ImeArtiklaES { get; set; }
    }
}
