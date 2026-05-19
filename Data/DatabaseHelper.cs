using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WpfAmsterdam
{
    public static class DatabaseHelper
    {
        private static string _dbPath;

        public static string GetConnectionString()
        {
            if (_dbPath == null)
            {
                _dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "amsterdam.db");
            }
            return "Data Source=" + _dbPath;
        }

        public static void InitializeDatabase()
        {
            string connStr = GetConnectionString();
            bool novaDb = !File.Exists(_dbPath);

            using (SqliteConnection con = new SqliteConnection(connStr))
            {
                con.Open();

                if (novaDb)
                {
                    // Kreiraj šemu
                    string sqlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "create_sqlite_db.sql");
                    if (File.Exists(sqlPath))
                    {
                        string sql = File.ReadAllText(sqlPath);
                        using (SqliteCommand cmd = new SqliteCommand(sql, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Importuj podatke
                    string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "import_sqlite_data.sql");
                    if (File.Exists(dataPath))
                    {
                        string dataSql = File.ReadAllText(dataPath);
                        // SQLite ne može da izvrši hiljade INSERT-a odjednom bez transakcije
                        using (SqliteTransaction txn = con.BeginTransaction())
                        {
                            foreach (string line in dataSql.Split('\n'))
                            {
                                string trimmed = line.Trim();
                                if (trimmed.StartsWith("INSERT"))
                                {
                                    using (SqliteCommand cmd = new SqliteCommand(trimmed, con, txn))
                                    {
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                            txn.Commit();
                        }
                    }
                }
                else
                {
                    // Osiguraj da nove tabele postoje (za postojeće baze)
                    string[] ensureTables = new string[]
                    {
                        "CREATE TABLE IF NOT EXISTS PasivniElementi (Id INTEGER PRIMARY KEY AUTOINCREMENT, Tip TEXT NOT NULL, Naziv TEXT NOT NULL DEFAULT '', PosX REAL NOT NULL DEFAULT 0, PosY REAL NOT NULL DEFAULT 0, Sirina REAL NOT NULL DEFAULT 0, Visina REAL NOT NULL DEFAULT 0, Boja TEXT NOT NULL DEFAULT '#E8F4FD')",
                        "CREATE TABLE IF NOT EXISTS Konfiguracija (Kljuc TEXT PRIMARY KEY, Vrednost TEXT NOT NULL)",
                        "INSERT OR IGNORE INTO Konfiguracija (Kljuc, Vrednost) VALUES ('KoristiKartice', '1')"
                    };
                    foreach (string sql in ensureTables)
                    {
                        using (SqliteCommand cmd = new SqliteCommand(sql, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public static DataTable ReaderTabela(string kon, string tekstKomande)
        {
            DataTable tabela = new DataTable();
            try
            {
                using (SqliteConnection con = new SqliteConnection(kon))
                {
                    con.Open();
                    using (SqliteCommand cmd = new SqliteCommand(tekstKomande, con))
                    {
                        using (SqliteDataReader rdr = cmd.ExecuteReader())
                        {
                            tabela.Load(rdr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tabela;
        }

        // BrisanjeStola - ranije stored procedura
        public static void ProcBrisanjeStola(string kon, string brojStola)
        {
            try
            {
                using (SqliteConnection con = new SqliteConnection(kon))
                {
                    con.Open();
                    using (SqliteCommand cmd = new SqliteCommand(
                        "DELETE FROM KonobariStolovi WHERE BrojStola = @BrojStola", con))
                    {
                        cmd.Parameters.AddWithValue("@BrojStola", brojStola);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqliteCommand cmd = new SqliteCommand(
                        "DELETE FROM KonobStoloviStavke WHERE BrojStola = @BrojStola", con))
                    {
                        cmd.Parameters.AddWithValue("@BrojStola", brojStola);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "brisanje");
            }
        }

        // ZamenaStolova - ranije stored procedura
        public static void ProcZamenaStolova(string kon, string string1, string string2)
        {
            try
            {
                using (SqliteConnection con = new SqliteConnection(kon))
                {
                    con.Open();
                    using (SqliteCommand cmd = new SqliteCommand(
                        "UPDATE KonobariStolovi SET BrojStola = @Sto2 WHERE BrojStola = @Sto1", con))
                    {
                        cmd.Parameters.AddWithValue("@Sto1", string1);
                        cmd.Parameters.AddWithValue("@Sto2", string2);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqliteCommand cmd = new SqliteCommand(
                        "UPDATE KonobStoloviStavke SET BrojStola = @Sto2 WHERE BrojStola = @Sto1", con))
                    {
                        cmd.Parameters.AddWithValue("@Sto1", string1);
                        cmd.Parameters.AddWithValue("@Sto2", string2);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ZamenaKonobara - ranije stored procedura
        public static void ProcZamenaKonobara(string kon, int konobarPreuzima, int konobarOdlazi)
        {
            try
            {
                using (SqliteConnection con = new SqliteConnection(kon))
                {
                    con.Open();
                    // Dobavi ime konobara koji preuzima
                    string ime = "";
                    using (SqliteCommand cmd = new SqliteCommand(
                        "SELECT Ime FROM Konobari WHERE IdKonobar = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", konobarPreuzima);
                        object result = cmd.ExecuteScalar();
                        if (result != null) ime = result.ToString();
                    }
                    using (SqliteCommand cmd = new SqliteCommand(
                        "UPDATE KonobariStolovi SET IdKonobar = @Preuzima, Ime = @Ime WHERE IdKonobar = @Odlazi", con))
                    {
                        cmd.Parameters.AddWithValue("@Preuzima", konobarPreuzima);
                        cmd.Parameters.AddWithValue("@Ime", ime);
                        cmd.Parameters.AddWithValue("@Odlazi", konobarOdlazi);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqliteCommand cmd = new SqliteCommand(
                        "UPDATE KonobStoloviStavke SET IdKonobar = @Preuzima WHERE IdKonobar = @Odlazi", con))
                    {
                        cmd.Parameters.AddWithValue("@Preuzima", konobarPreuzima);
                        cmd.Parameters.AddWithValue("@Odlazi", konobarOdlazi);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // NovoZaglavlje - ranije stored procedura
        public static int ProcInsertNarucenoZ(string kon, double iznos, string komentar,
                                               bool belo, string fiskalTekst,
                                               string sto, string konobar)
        {
            int id = 0;
            try
            {
                using (SqliteConnection con = new SqliteConnection(kon))
                {
                    con.Open();
                    string tabela = belo ? "NarucenoZaglavlje" : "KuhinjaZaglavlje";
                    string sql = "INSERT INTO " + tabela +
                        " (vremePlacanja, Iznos, komentar, FiskalTekst, Sto, Konobar) " +
                        "VALUES (datetime('now','localtime'), @Iznos, @komentar, @FiskalTekst, @Sto, @Konobar); " +
                        "SELECT last_insert_rowid();";
                    using (SqliteCommand cmd = new SqliteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Iznos", iznos);
                        cmd.Parameters.AddWithValue("@komentar", komentar);
                        cmd.Parameters.AddWithValue("@FiskalTekst", fiskalTekst);
                        cmd.Parameters.AddWithValue("@Sto", sto);
                        cmd.Parameters.AddWithValue("@Konobar", konobar);
                        id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return id;
        }

        // ZatvoriSto - ranije stored procedura
        public static void ProcZatvoriSto(string kon, int idZaglavlje, bool belo)
        {
            try
            {
                using (SqliteConnection con = new SqliteConnection(kon))
                {
                    con.Open();

                    string tblZag = belo ? "NarucenoZaglavlje" : "KuhinjaZaglavlje";
                    string tblStavke = belo ? "NarucenoStavke" : "KuhinjaStavke";

                    // Update zaglavlje sa podacima iz KonobariStolovi
                    using (SqliteCommand cmd = new SqliteCommand(
                        "UPDATE " + tblZag + " SET Datum = K.vreme, Popust = K.popust, IdPromo = K.IdPromo " +
                        "FROM KonobariStolovi AS K " +
                        "WHERE " + tblZag + ".Sto = K.BrojStola AND " + tblZag + ".IdZaglavlje = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", idZaglavlje);
                        cmd.ExecuteNonQuery();
                    }

                    // Dobavi broj stola
                    string brSto = "";
                    using (SqliteCommand cmd = new SqliteCommand(
                        "SELECT Sto FROM " + tblZag + " WHERE IdZaglavlje = @Id", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", idZaglavlje);
                        object result = cmd.ExecuteScalar();
                        if (result != null) brSto = result.ToString();
                    }

                    // Kopiraj stavke
                    using (SqliteCommand cmd = new SqliteCommand(
                        "INSERT INTO " + tblStavke + " (IdZaglavlje, Id, IdArtikal, DeoPorcije, Cena, Komada, Komentar) " +
                        "SELECT @Id, Id, IdArtikal, DeoPorcije, Cena, Komada, Komentar " +
                        "FROM KonobStoloviStavke WHERE BrojStola = @BrSto", con))
                    {
                        cmd.Parameters.AddWithValue("@Id", idZaglavlje);
                        cmd.Parameters.AddWithValue("@BrSto", brSto);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Tiho ignorisanje kao u originalu
            }
        }

        // fncPromet - ranije SQL funkcija
        public static DataTable FuncPromet(string kon, string brojStola)
        {
            DataTable tabela = new DataTable();
            try
            {
                using (SqliteConnection con = new SqliteConnection(kon))
                {
                    con.Open();
                    string sql =
                        "SELECT MIN(Id) AS Id, IdArtikal, ImeArtikal, DeoPorcije, " +
                        "SUM(Komada) AS Komada, JedMere, Cena, " +
                        "SUM(ROUND(DeoPorcije * Komada * Cena, 2)) AS Ukupno " +
                        "FROM KonobStoloviStavke " +
                        "WHERE BrojStola = @BrojStola " +
                        "GROUP BY IdKonobar, BrojStola, IdArtikal, ImeArtikal, DeoPorcije, JedMere, Cena " +
                        "HAVING SUM(ROUND(DeoPorcije * Komada * Cena, 2)) <> 0";
                    using (SqliteCommand cmd = new SqliteCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@BrojStola", brojStola);
                        using (SqliteDataReader rdr = cmd.ExecuteReader())
                        {
                            tabela.Load(rdr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tabela;
        }

        // NajnovijeStavke - ranije SQL view
        public static DataTable ViewNajnovijeStavke(string kon)
        {
            DataTable tabela = new DataTable();
            try
            {
                using (SqliteConnection con = new SqliteConnection(kon))
                {
                    con.Open();
                    string sql =
                        "SELECT BrojStola, MIN(protek) AS proteklo FROM (" +
                        "  SELECT BrojStola, " +
                        "    CASE WHEN (strftime('%s','now','localtime') - strftime('%s', '2000-01-01 ' || vreme)) < 0 " +
                        "      THEN 1440 + (strftime('%s','now','localtime') - strftime('%s', '2000-01-01 ' || vreme)) / 60.0 " +
                        "      ELSE (strftime('%s','now','localtime') - strftime('%s', '2000-01-01 ' || vreme)) / 60.0 " +
                        "    END AS protek " +
                        "  FROM KonobStoloviStavke" +
                        ") GROUP BY BrojStola";
                    using (SqliteCommand cmd = new SqliteCommand(sql, con))
                    {
                        using (SqliteDataReader rdr = cmd.ExecuteReader())
                        {
                            tabela.Load(rdr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tabela;
        }

        // ProcDict i FProcDict - zamenjeni inline SQL-om
        // Ove metode se više ne koriste jer su stored procedure zamenjene
        // direktnim SQL upitima u specifičnim metodama iznad

        public static string UbacenvbCrLf(string rec, int duzina)
        {
            string f = string.Empty;
            if (rec.Length > duzina)
            {
                for (int i = 0; i < rec.Length; i += duzina)
                {
                    int len = Math.Min(duzina, rec.Length - i);
                    if ((i + duzina) < rec.Length)
                    {
                        f = f + rec.Substring(i, len) + "\r\n";
                    }
                    else
                    {
                        f = f + rec.Substring(i, len);
                    }
                }
            }
            else
            {
                f = rec;
            }
            return f;
        }
    }
}
