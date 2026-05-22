using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using Microsoft.Data.Sqlite;

namespace WpfAmsterdam
{
    public partial class DlgEnergyStar : Window
    {
        private string konekcija = Window2.konekcija;

        public DlgEnergyStar()
        {
            InitializeComponent();

            // Postavi širinu na 80% ekrana
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            this.Width = screenWidth * 0.8;
            this.Height = SystemParameters.PrimaryScreenHeight * 0.75;

            LoadArtikli();
            LoadEnergyStarKatalog();
        }

        private void LoadArtikli()
        {
            try
            {
                DataTable dt = DatabaseHelper.ReaderTabela(konekcija,
                    "SELECT IdArtikal, Naziv FROM Artikli WHERE aktivan = 1 ORDER BY Naziv");

                var lista = new List<ArtikalES>();
                foreach (DataRow row in dt.Rows)
                {
                    lista.Add(new ArtikalES
                    {
                        Sifra = Convert.ToInt32(row["IdArtikal"]),
                        Naziv = row["Naziv"].ToString(),
                        EsSifra = "",
                        EsNaziv = ""
                    });
                }
                dgArtikli.ItemsSource = lista;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Greška pri učitavanju artikala: " + ex.Message);
            }
        }

        private void LoadEnergyStarKatalog()
        {
            // Fake podaci - kasnije će dolaziti iz eksterne baze
            var katalog = new List<EsProizvod>
            {
                new EsProizvod { Sifra = "ES-1001", Naziv = "Dom Perignon 75cl" },
                new EsProizvod { Sifra = "ES-1002", Naziv = "Dom Perignon Rose 75cl" },
                new EsProizvod { Sifra = "ES-1003", Naziv = "Moet Chandon Brut 75cl" },
                new EsProizvod { Sifra = "ES-1004", Naziv = "Moet Chandon Rose 75cl" },
                new EsProizvod { Sifra = "ES-1005", Naziv = "Veuve Clicquot Brut 75cl" },
                new EsProizvod { Sifra = "ES-1006", Naziv = "Veuve Clicquot Rose 75cl" },
                new EsProizvod { Sifra = "ES-1007", Naziv = "Krug Grande Cuvee 75cl" },
                new EsProizvod { Sifra = "ES-1008", Naziv = "Hennessy VS 70cl" },
                new EsProizvod { Sifra = "ES-1009", Naziv = "Hennessy VSOP 70cl" },
                new EsProizvod { Sifra = "ES-1010", Naziv = "Hennessy XO 70cl" },
                new EsProizvod { Sifra = "ES-1011", Naziv = "Belvedere Vodka 70cl" },
                new EsProizvod { Sifra = "ES-1012", Naziv = "Belvedere Vodka 1.75L" },
                new EsProizvod { Sifra = "ES-1013", Naziv = "Glenmorangie Original 70cl" },
                new EsProizvod { Sifra = "ES-1014", Naziv = "Ardbeg 10YO 70cl" },
                new EsProizvod { Sifra = "ES-1015", Naziv = "Chandon Garden Spritz 75cl" },
            };
            dgEnergyStar.ItemsSource = katalog;
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class ArtikalES
    {
        public int Sifra { get; set; }
        public string Naziv { get; set; }
        public string EsSifra { get; set; }
        public string EsNaziv { get; set; }
    }

    public class EsProizvod
    {
        public string Sifra { get; set; }
        public string Naziv { get; set; }
    }
}
