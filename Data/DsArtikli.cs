using System;
using System.Data;
using System.ComponentModel;
using Microsoft.Data.Sqlite;

namespace WpfAmsterdam
{
    public class DsArtikli : DataSet
    {
        private DataTable tableKategorija;
        private DataTable tableKategorija1;
        private DataTable tableArtikli;

        public DsArtikli()
        {
            DataSetName = "dsArtikli";
            InitClass();
        }

        public DataTable Kategorija => tableKategorija;
        public DataTable Kategorija1 => tableKategorija1;
        public DataTable Artikli => tableArtikli;

        private void InitClass()
        {
            // Kategorija tabela
            tableKategorija = new DataTable("Kategorija");
            DataColumn colIdKat = new DataColumn("IdKat", typeof(int));
            colIdKat.AutoIncrement = true;
            colIdKat.AutoIncrementSeed = -1;
            colIdKat.AutoIncrementStep = -1;
            colIdKat.ReadOnly = true;
            tableKategorija.Columns.Add(colIdKat);
            tableKategorija.Columns.Add("Kategorija", typeof(string));
            tableKategorija.Columns.Add("aktivna", typeof(bool));
            tableKategorija.PrimaryKey = new DataColumn[] { colIdKat };
            Tables.Add(tableKategorija);

            // Kategorija1 tabela
            tableKategorija1 = new DataTable("Kategorija1");
            DataColumn colIdKat1 = new DataColumn("IdKat1", typeof(int));
            colIdKat1.AutoIncrement = true;
            colIdKat1.AutoIncrementSeed = -1;
            colIdKat1.AutoIncrementStep = -1;
            colIdKat1.ReadOnly = true;
            tableKategorija1.Columns.Add(colIdKat1);
            tableKategorija1.Columns.Add("IdKat", typeof(int));
            tableKategorija1.Columns.Add("PodKat", typeof(string));
            tableKategorija1.Columns.Add("aktivna", typeof(bool));
            tableKategorija1.PrimaryKey = new DataColumn[] { colIdKat1 };
            Tables.Add(tableKategorija1);

            // Artikli tabela
            tableArtikli = new DataTable("Artikli");
            DataColumn colIdArtikal = new DataColumn("IdArtikal", typeof(int));
            colIdArtikal.AutoIncrement = true;
            colIdArtikal.AutoIncrementSeed = -1;
            colIdArtikal.AutoIncrementStep = -1;
            colIdArtikal.ReadOnly = true;
            tableArtikli.Columns.Add(colIdArtikal);
            tableArtikli.Columns.Add("IdKat1", typeof(int));
            tableArtikli.Columns.Add("broj", typeof(int));
            tableArtikli.Columns.Add("Naziv", typeof(string));
            tableArtikli.Columns.Add("Tip", typeof(string));
            tableArtikli.Columns.Add("ProdajnaJedMere", typeof(string));
            tableArtikli.Columns.Add("Price", typeof(double));
            tableArtikli.Columns.Add("NazivKasa", typeof(string));
            tableArtikli.Columns.Add("Cost", typeof(double));
            tableArtikli.PrimaryKey = new DataColumn[] { colIdArtikal };
            Tables.Add(tableArtikli);

            // Relacije
            Relations.Add("Kategorija_Kategorija1",
                tableKategorija.Columns["IdKat"],
                tableKategorija1.Columns["IdKat"],
                false);

            Relations.Add("Kategorija1_Artikli",
                tableKategorija1.Columns["IdKat1"],
                tableArtikli.Columns["IdKat1"],
                false);
        }
    }

    public class KategorijaTableAdapter
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public void Fill(DataTable dataTable)
        {
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();
                using (SqliteCommand cmd = new SqliteCommand(
                    "SELECT IdKat, Kategorija, aktivna FROM Kategorija WHERE aktivna = 1", con))
                {
                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        dataTable.Load(rdr);
                    }
                }
            }
        }
    }

    public class Kategorija1TableAdapter
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public void Fill(DataTable dataTable)
        {
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();
                using (SqliteCommand cmd = new SqliteCommand(
                    "SELECT IdKat1, IdKat, PodKat, aktivna FROM Kategorija1 WHERE aktivna = 1", con))
                {
                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        dataTable.Load(rdr);
                    }
                }
            }
        }
    }

    public class ArtikliTableAdapter
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public void Fill(DataTable dataTable)
        {
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();
                using (SqliteCommand cmd = new SqliteCommand(
                    "SELECT IdArtikal, IdKat1, broj, Naziv, Tip, ProdajnaJedMere, Price, NazivKasa, Cost " +
                    "FROM Artikli WHERE aktivan = 1 AND daliProdaja = 1 ORDER BY broj", con))
                {
                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        dataTable.Load(rdr);
                    }
                }
            }
        }
    }
}
