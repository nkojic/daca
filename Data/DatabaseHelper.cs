using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WpfAmsterdam
{
    public static class DatabaseHelper
    {
        public static DataTable ReaderTabela(string kon, string tekstKomande)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = kon;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = tekstKomande;
            DataTable tabela = new DataTable();
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                tabela.Load(rdr, LoadOption.Upsert);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tabela;
        }

        private static void PorukaGlavna(object sender, SqlInfoMessageEventArgs e)
        {
            if (!e.Message.StartsWith("Warning"))
            {
                MessageBox.Show(e.Message, "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void ProcBrisanjeStola(string kon, string brojStola)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = kon;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "BrisanjeStola";
            SqlParameter param = new SqlParameter("@BrojStola", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);
            cmd.Parameters["@BrojStola"].Value = brojStola;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "brisanje");
            }
        }

        public static void ProcZamenaStolova(string kon, string string1, string string2)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = kon;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ZamenaStolova";
            SqlParameter param = new SqlParameter("@BrojStola1", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@BrojStola2", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            param.DbType = DbType.String;
            cmd.Parameters.Add(param);
            cmd.Parameters["@BrojStola1"].Value = string1;
            cmd.Parameters["@BrojStola2"].Value = string2;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ProcZamenaKonobara(string kon, int string1, int string2)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = kon;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ZamenaKonobara";
            SqlParameter param = new SqlParameter("@KonobarPreuzima", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@KonobarOdlazi", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            cmd.Parameters["@KonobarPreuzima"].Value = string1;
            cmd.Parameters["@KonobarOdlazi"].Value = string2;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ProcDict(string kon, List<SqlParameter> dictPar, string procedura)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = kon;
            con.InfoMessage += new SqlInfoMessageEventHandler(PorukaGlavna);

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedura;
            if (dictPar != null)
            {
                foreach (SqlParameter parm in dictPar)
                {
                    cmd.Parameters.Add(parm);
                }
            }
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static int ProcInsertNarucenoZ(string kon, double iznos, string komentar,
                                               bool belo, string fiskalTekst,
                                               string sto, string konobar)
        {
            int rdr = 0;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = kon;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "NovoZaglavlje";
            SqlParameter param = new SqlParameter("@Iznos", SqlDbType.Float);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@komentar", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@kuhinja", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@FiskalTekst", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Sto", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Konobar", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            cmd.Parameters["@Iznos"].Value = iznos;
            cmd.Parameters["@komentar"].Value = komentar;
            cmd.Parameters["@kuhinja"].Value = belo;
            cmd.Parameters["@FiskalTekst"].Value = fiskalTekst;
            cmd.Parameters["@Sto"].Value = sto;
            cmd.Parameters["@Konobar"].Value = konobar;
            try
            {
                con.Open();
                rdr = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rdr;
        }

        public static void ProcZatvoriSto(string kon, int id, bool belo)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = kon;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ZatvoriSto";
            SqlParameter param = new SqlParameter("@IdZaglavlje", SqlDbType.Float);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@kuhinja", SqlDbType.Bit);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            cmd.Parameters["@IdZaglavlje"].Value = id;
            cmd.Parameters["@kuhinja"].Value = belo;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                // MsgBox(ex.Message)
            }
        }

        public static DataTable FProcDict(string kon, List<SqlParameter> dictPar, string procedura)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = kon;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedura;
            if (dictPar != null)
            {
                foreach (SqlParameter parm in dictPar)
                {
                    cmd.Parameters.Add(parm);
                }
            }
            DataTable tabela = new DataTable();
            try
            {
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                tabela.Load(rdr, LoadOption.Upsert);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return tabela;
        }

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
