using System;
using System.Data;
using System.ComponentModel;
using Microsoft.Data.Sqlite;

namespace WpfAmsterdam
{
    public class DsKonStoloviStavke : DataSet
    {
        private DataTable tableKonobStoloviStavke;

        public DsKonStoloviStavke()
        {
            DataSetName = "dsKonStoloviStavke";
            InitClass();
        }

        public DataTable KonobStoloviStavke => tableKonobStoloviStavke;

        private void InitClass()
        {
            tableKonobStoloviStavke = new DataTable("KonobStoloviStavke");

            DataColumn colIdKonobar = new DataColumn("IdKonobar", typeof(int));
            DataColumn colBrojStola = new DataColumn("BrojStola", typeof(string));
            colBrojStola.MaxLength = 15;
            DataColumn colId = new DataColumn("Id", typeof(int));
            DataColumn colIdArtikal = new DataColumn("IdArtikal", typeof(int));
            DataColumn colDeoPorcije = new DataColumn("DeoPorcije", typeof(double));
            DataColumn colKomada = new DataColumn("Komada", typeof(double));
            DataColumn colJedMere = new DataColumn("JedMere", typeof(string));
            colJedMere.MaxLength = 5;
            DataColumn colCena = new DataColumn("Cena", typeof(double));
            DataColumn colKomentar = new DataColumn("Komentar", typeof(string));
            colKomentar.MaxLength = 255;
            DataColumn colOdneto = new DataColumn("Odneto", typeof(bool));
            DataColumn colImeArtikal = new DataColumn("ImeArtikal", typeof(string));
            colImeArtikal.MaxLength = 255;
            DataColumn colUkupno = new DataColumn("Ukupno", typeof(double));
            colUkupno.ReadOnly = true;
            colUkupno.Expression = "Komada * DeoPorcije * Cena";
            DataColumn colTip = new DataColumn("Tip", typeof(string));
            colTip.MaxLength = 50;
            DataColumn colVreme = new DataColumn("vreme", typeof(string));

            tableKonobStoloviStavke.Columns.Add(colIdKonobar);
            tableKonobStoloviStavke.Columns.Add(colBrojStola);
            tableKonobStoloviStavke.Columns.Add(colId);
            tableKonobStoloviStavke.Columns.Add(colIdArtikal);
            tableKonobStoloviStavke.Columns.Add(colDeoPorcije);
            tableKonobStoloviStavke.Columns.Add(colKomada);
            tableKonobStoloviStavke.Columns.Add(colJedMere);
            tableKonobStoloviStavke.Columns.Add(colCena);
            tableKonobStoloviStavke.Columns.Add(colKomentar);
            tableKonobStoloviStavke.Columns.Add(colOdneto);
            tableKonobStoloviStavke.Columns.Add(colImeArtikal);
            tableKonobStoloviStavke.Columns.Add(colUkupno);
            tableKonobStoloviStavke.Columns.Add(colTip);
            tableKonobStoloviStavke.Columns.Add(colVreme);

            tableKonobStoloviStavke.PrimaryKey = new DataColumn[] { colIdKonobar, colBrojStola, colId };

            Tables.Add(tableKonobStoloviStavke);
        }
    }

    public class KonobStoloviStavkeTableAdapter
    {
        private string connectionString;

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public void Fill(DataTable dataTable, string brojStola, int idKonobar)
        {
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();
                using (SqliteCommand cmd = new SqliteCommand(
                    "SELECT IdKonobar, BrojStola, Id, IdArtikal, DeoPorcije, Komada, JedMere, Cena, " +
                    "Komentar, Odneto, ImeArtikal, Tip, vreme FROM KonobStoloviStavke " +
                    "WHERE BrojStola = @BrojStola AND IdKonobar = @IdKonobar", con))
                {
                    cmd.Parameters.AddWithValue("@BrojStola", brojStola);
                    cmd.Parameters.AddWithValue("@IdKonobar", idKonobar);
                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        dataTable.Load(rdr);
                    }
                }
            }
        }

        public void FillBy(DataTable dataTable, int idKonobar)
        {
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();
                using (SqliteCommand cmd = new SqliteCommand(
                    "SELECT IdKonobar, BrojStola, Id, IdArtikal, DeoPorcije, Komada, JedMere, Cena, " +
                    "Komentar, Odneto, ImeArtikal, Tip, vreme FROM KonobStoloviStavke " +
                    "WHERE IdKonobar = @IdKonobar", con))
                {
                    cmd.Parameters.AddWithValue("@IdKonobar", idKonobar);
                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        dataTable.Load(rdr);
                    }
                }
            }
        }

        public int Update(DataTable dataTable)
        {
            int affected = 0;
            using (SqliteConnection con = new SqliteConnection(connectionString))
            {
                con.Open();
                using (SqliteTransaction txn = con.BeginTransaction())
                {
                    try
                    {
                        DataTable deleted = dataTable.GetChanges(DataRowState.Deleted);
                        if (deleted != null)
                        foreach (DataRow row in deleted.Rows)
                        {
                            using (SqliteCommand cmd = new SqliteCommand(
                                "DELETE FROM KonobStoloviStavke WHERE IdKonobar = @IdKonobar " +
                                "AND BrojStola = @BrojStola AND Id = @Id", con, txn))
                            {
                                cmd.Parameters.AddWithValue("@IdKonobar", row["IdKonobar", DataRowVersion.Original]);
                                cmd.Parameters.AddWithValue("@BrojStola", row["BrojStola", DataRowVersion.Original]);
                                cmd.Parameters.AddWithValue("@Id", row["Id", DataRowVersion.Original]);
                                affected += cmd.ExecuteNonQuery();
                            }
                        }

                        DataTable added = dataTable.GetChanges(DataRowState.Added);
                        if (added != null)
                        {
                            foreach (DataRow row in added.Rows)
                            {
                                using (SqliteCommand cmd = new SqliteCommand(
                                    "INSERT INTO KonobStoloviStavke (IdKonobar, BrojStola, Id, IdArtikal, " +
                                    "DeoPorcije, Komada, JedMere, Cena, Komentar, Odneto, ImeArtikal, Tip, vreme) " +
                                    "VALUES (@IdKonobar, @BrojStola, @Id, @IdArtikal, @DeoPorcije, @Komada, " +
                                    "@JedMere, @Cena, @Komentar, @Odneto, @ImeArtikal, @Tip, @vreme)", con, txn))
                                {
                                    cmd.Parameters.AddWithValue("@IdKonobar", row["IdKonobar"]);
                                    cmd.Parameters.AddWithValue("@BrojStola", row["BrojStola"]);
                                    cmd.Parameters.AddWithValue("@Id", row["Id"]);
                                    cmd.Parameters.AddWithValue("@IdArtikal", row["IdArtikal"]);
                                    cmd.Parameters.AddWithValue("@DeoPorcije", row["DeoPorcije"]);
                                    cmd.Parameters.AddWithValue("@Komada", row["Komada"]);
                                    cmd.Parameters.AddWithValue("@JedMere", row["JedMere"] ?? "");
                                    cmd.Parameters.AddWithValue("@Cena", row["Cena"]);
                                    cmd.Parameters.AddWithValue("@Komentar", row["Komentar"] ?? "");
                                    cmd.Parameters.AddWithValue("@Odneto", Convert.ToInt32(row["Odneto"]));
                                    cmd.Parameters.AddWithValue("@ImeArtikal", row["ImeArtikal"] ?? "");
                                    cmd.Parameters.AddWithValue("@Tip", row["Tip"] ?? "");
                                    cmd.Parameters.AddWithValue("@vreme", row["vreme"] ?? "");
                                    affected += cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        DataTable modified = dataTable.GetChanges(DataRowState.Modified);
                        if (modified != null)
                        {
                            foreach (DataRow row in modified.Rows)
                            {
                                using (SqliteCommand cmd = new SqliteCommand(
                                    "UPDATE KonobStoloviStavke SET IdKonobar = @IdKonobar, BrojStola = @BrojStola, " +
                                    "Id = @Id, IdArtikal = @IdArtikal, DeoPorcije = @DeoPorcije, Komada = @Komada, " +
                                    "JedMere = @JedMere, Cena = @Cena, Komentar = @Komentar, Odneto = @Odneto, " +
                                    "ImeArtikal = @ImeArtikal, Tip = @Tip, vreme = @vreme " +
                                    "WHERE IdKonobar = @OrigIdKonobar AND BrojStola = @OrigBrojStola AND Id = @OrigId",
                                    con, txn))
                                {
                                    cmd.Parameters.AddWithValue("@IdKonobar", row["IdKonobar"]);
                                    cmd.Parameters.AddWithValue("@BrojStola", row["BrojStola"]);
                                    cmd.Parameters.AddWithValue("@Id", row["Id"]);
                                    cmd.Parameters.AddWithValue("@IdArtikal", row["IdArtikal"]);
                                    cmd.Parameters.AddWithValue("@DeoPorcije", row["DeoPorcije"]);
                                    cmd.Parameters.AddWithValue("@Komada", row["Komada"]);
                                    cmd.Parameters.AddWithValue("@JedMere", row["JedMere"] ?? "");
                                    cmd.Parameters.AddWithValue("@Cena", row["Cena"]);
                                    cmd.Parameters.AddWithValue("@Komentar", row["Komentar"] ?? "");
                                    cmd.Parameters.AddWithValue("@Odneto", Convert.ToInt32(row["Odneto"]));
                                    cmd.Parameters.AddWithValue("@ImeArtikal", row["ImeArtikal"] ?? "");
                                    cmd.Parameters.AddWithValue("@Tip", row["Tip"] ?? "");
                                    cmd.Parameters.AddWithValue("@vreme", row["vreme"] ?? "");
                                    cmd.Parameters.AddWithValue("@OrigIdKonobar", row["IdKonobar", DataRowVersion.Original]);
                                    cmd.Parameters.AddWithValue("@OrigBrojStola", row["BrojStola", DataRowVersion.Original]);
                                    cmd.Parameters.AddWithValue("@OrigId", row["Id", DataRowVersion.Original]);
                                    affected += cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        txn.Commit();
                        dataTable.AcceptChanges();
                    }
                    catch
                    {
                        txn.Rollback();
                        throw;
                    }
                }
            }
            return affected;
        }
    }
}
