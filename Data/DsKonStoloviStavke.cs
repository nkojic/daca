using System;
using System.Data;
using System.ComponentModel;
using Microsoft.Data.SqlClient;

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
            DataColumn colVreme = new DataColumn("vreme", typeof(TimeSpan));

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
        private SqlDataAdapter adapter;
        private string connectionString;

        public KonobStoloviStavkeTableAdapter()
        {
        }

        public string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        private void InitAdapter()
        {
            adapter = new SqlDataAdapter();

            // SelectCommand
            adapter.SelectCommand = new SqlCommand(
                "SELECT IdKonobar, BrojStola, Id, IdArtikal, DeoPorcije, Komada, JedMere, Cena, " +
                "Komentar, Odneto, ImeArtikal, Tip, vreme FROM KonobStoloviStavke " +
                "WHERE (BrojStola = @BrojStola) AND (IdKonobar = @IdKonobar)");
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@BrojStola", SqlDbType.NVarChar, 15));
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@IdKonobar", SqlDbType.Int));

            // InsertCommand
            adapter.InsertCommand = new SqlCommand(
                "INSERT INTO [KonobStoloviStavke] ([IdKonobar], [BrojStola], [Id], [IdArtikal], " +
                "[DeoPorcije], [Komada], [JedMere], [Cena], [Komentar], [Odneto], [ImeArtikal], " +
                "[Tip], [vreme]) VALUES (@IdKonobar, @BrojStola, @Id, @IdArtikal, @DeoPorcije, " +
                "@Komada, @JedMere, @Cena, @Komentar, @Odneto, @ImeArtikal, @Tip, @vreme)");
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdKonobar", SqlDbType.Int) { SourceColumn = "IdKonobar" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@BrojStola", SqlDbType.NVarChar, 15) { SourceColumn = "BrojStola" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { SourceColumn = "Id" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@IdArtikal", SqlDbType.Int) { SourceColumn = "IdArtikal" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@DeoPorcije", SqlDbType.Float) { SourceColumn = "DeoPorcije" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Komada", SqlDbType.Float) { SourceColumn = "Komada" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@JedMere", SqlDbType.NVarChar, 5) { SourceColumn = "JedMere" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Cena", SqlDbType.Float) { SourceColumn = "Cena" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Komentar", SqlDbType.NVarChar, 255) { SourceColumn = "Komentar" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Odneto", SqlDbType.Bit) { SourceColumn = "Odneto" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@ImeArtikal", SqlDbType.NVarChar, 255) { SourceColumn = "ImeArtikal" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Tip", SqlDbType.NVarChar, 50) { SourceColumn = "Tip" });
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@vreme", SqlDbType.Time) { SourceColumn = "vreme" });

            // DeleteCommand
            adapter.DeleteCommand = new SqlCommand(
                "DELETE FROM [KonobStoloviStavke] WHERE ([IdKonobar] = @Original_IdKonobar) " +
                "AND ([BrojStola] = @Original_BrojStola) AND ([Id] = @Original_Id)");
            adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_IdKonobar", SqlDbType.Int) { SourceColumn = "IdKonobar", SourceVersion = DataRowVersion.Original });
            adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_BrojStola", SqlDbType.NVarChar, 15) { SourceColumn = "BrojStola", SourceVersion = DataRowVersion.Original });
            adapter.DeleteCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.Int) { SourceColumn = "Id", SourceVersion = DataRowVersion.Original });

            // UpdateCommand
            adapter.UpdateCommand = new SqlCommand(
                "UPDATE [KonobStoloviStavke] SET [IdKonobar] = @IdKonobar, [BrojStola] = @BrojStola, " +
                "[Id] = @Id, [IdArtikal] = @IdArtikal, [DeoPorcije] = @DeoPorcije, [Komada] = @Komada, " +
                "[JedMere] = @JedMere, [Cena] = @Cena, [Komentar] = @Komentar, [Odneto] = @Odneto, " +
                "[ImeArtikal] = @ImeArtikal, [Tip] = @Tip, [vreme] = @vreme " +
                "WHERE ([IdKonobar] = @Original_IdKonobar) AND ([BrojStola] = @Original_BrojStola) " +
                "AND ([Id] = @Original_Id)");
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdKonobar", SqlDbType.Int) { SourceColumn = "IdKonobar" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@BrojStola", SqlDbType.NVarChar, 15) { SourceColumn = "BrojStola" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { SourceColumn = "Id" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@IdArtikal", SqlDbType.Int) { SourceColumn = "IdArtikal" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@DeoPorcije", SqlDbType.Float) { SourceColumn = "DeoPorcije" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Komada", SqlDbType.Float) { SourceColumn = "Komada" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@JedMere", SqlDbType.NVarChar, 5) { SourceColumn = "JedMere" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Cena", SqlDbType.Float) { SourceColumn = "Cena" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Komentar", SqlDbType.NVarChar, 255) { SourceColumn = "Komentar" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Odneto", SqlDbType.Bit) { SourceColumn = "Odneto" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@ImeArtikal", SqlDbType.NVarChar, 255) { SourceColumn = "ImeArtikal" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Tip", SqlDbType.NVarChar, 50) { SourceColumn = "Tip" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@vreme", SqlDbType.Time) { SourceColumn = "vreme" });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_IdKonobar", SqlDbType.Int) { SourceColumn = "IdKonobar", SourceVersion = DataRowVersion.Original });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_BrojStola", SqlDbType.NVarChar, 15) { SourceColumn = "BrojStola", SourceVersion = DataRowVersion.Original });
            adapter.UpdateCommand.Parameters.Add(new SqlParameter("@Original_Id", SqlDbType.Int) { SourceColumn = "Id", SourceVersion = DataRowVersion.Original });
        }

        private SqlDataAdapter GetAdapter(string connStr)
        {
            if (adapter == null)
                InitAdapter();
            adapter.SelectCommand.Connection = new SqlConnection(connStr);
            adapter.InsertCommand.Connection = adapter.SelectCommand.Connection;
            adapter.DeleteCommand.Connection = adapter.SelectCommand.Connection;
            adapter.UpdateCommand.Connection = adapter.SelectCommand.Connection;
            return adapter;
        }

        public void Fill(DataTable dataTable, string brojStola, int idKonobar)
        {
            SqlDataAdapter da = GetAdapter(connectionString);
            da.SelectCommand.Parameters["@BrojStola"].Value = brojStola;
            da.SelectCommand.Parameters["@IdKonobar"].Value = idKonobar;
            da.Fill(dataTable);
        }

        public void FillBy(DataTable dataTable, int idKonobar)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT IdKonobar, BrojStola, Id, IdArtikal, DeoPorcije, Komada, JedMere, Cena, " +
                "Komentar, Odneto, ImeArtikal, Tip, vreme FROM KonobStoloviStavke " +
                "WHERE (IdKonobar = @IdKonobar)",
                connectionString);
            da.SelectCommand.Parameters.AddWithValue("@IdKonobar", idKonobar);
            da.Fill(dataTable);
        }

        public int Update(DataTable dataTable)
        {
            SqlDataAdapter da = GetAdapter(connectionString);
            return da.Update(dataTable);
        }
    }
}
