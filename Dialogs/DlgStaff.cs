using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WpfAmsterdam
{
    public partial class DlgStaff : Form
    {
        private DataTable tblZaposleni;
        private int daliTekDugme = 0;
        private DataTable tblPodela = null;
        private BindingSource bsZaposleni = null;
        private int idZaposl = 0;
        private string TextToBePrinted = string.Empty;
        private int margina = 10;
        private Dictionary<int, double> dictCene;
        private double suma = 0;

        public DlgStaff()
        {
            InitializeComponent();
        }

        private void dlgPlacanje_Load(object sender, EventArgs e)
        {
            tblZaposleni = DatabaseHelper.ReaderTabela(Window2.konekcija, "SELECT * FROM Ime WHERE IdPotpis BETWEEN 14 AND 20");
            DataTable tblPotpisi = DatabaseHelper.ReaderTabela(Window2.konekcija, "SELECT * FROM tblPotpis WHERE IdPotpis BETWEEN 14 AND 20");
            DataTable tblArtikli = DatabaseHelper.ReaderTabela(Window2.konekcija, "SELECT IdArtikal, Naziv, Cena FROM ArtikliZaZaposlene");

            dictCene = new Dictionary<int, double>();
            foreach (DataRow red in tblArtikli.Rows)
            {
                dictCene.Add(Convert.ToInt32(red["IdArtikal"]), Convert.ToDouble(red["Cena"]));
            }

            foreach (DataRow red in tblPotpisi.Rows)
            {
                Button btn = Dugme(red["Ime"].ToString(), red["IdPotpis"].ToString());
                btn.Click += new EventHandler(Button_Click);
                this.Panel1.Controls.Add(btn);
            }

            foreach (DataRow red in tblArtikli.Rows)
            {
                Button btn1 = DugmeArtikli(red["Naziv"].ToString(), Convert.ToInt32(red["IdArtikal"]));
                btn1.Click += new EventHandler(ButtonArtikal_Click);
                this.Panel2.Controls.Add(btn1);
            }

            tblPodela = new DataTable("tblPodela");
            tblPodela.Columns.Add("IdArtikal", Type.GetType("System.Int32"));
            tblPodela.Columns.Add("Artikal", Type.GetType("System.String"));
            tblPodela.Columns.Add("Cena", Type.GetType("System.Double"));
            bsZaposleni = new BindingSource();
            bsZaposleni.DataSource = tblPodela;

            DataGridView2.AutoGenerateColumns = false;
            DataGridView2.DataSource = bsZaposleni;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (bsZaposleni.Count > 1)
            {
                tblPodela.Clear();
            }
            int idkat = Convert.ToInt32(((Button)sender).Name);
            DataRow[] redovi = tblZaposleni.Select("IdPotpis = " + idkat);
            idZaposl = 0;
            Label1.Text = string.Empty;
            Panel3.Controls.Clear();
            foreach (DataRow red in redovi)
            {
                Button btn = DugmeZaposleni(red["Ime"].ToString(), Convert.ToInt32(red["IdIme"]));
                btn.Click += new EventHandler(ButtonZaposleni_Click);
                Panel3.Controls.Add(btn);
            }
        }

        private void ButtonZaposleni_Click(object sender, EventArgs e)
        {
            if (bsZaposleni.Count > 1)
            {
                if (MessageBox.Show("Da li zelite da zadrzite unesene stavke? ", "!!!!!!!!! ",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    tblPodela.Clear();
                    suma = 0;
                }
            }
            else
            {
                suma = 0;
            }
            idZaposl = Convert.ToInt32(((Button)sender).Name);
            this.Label1.Text = ((Button)sender).Text;
        }

        private void ButtonArtikal_Click(object sender, EventArgs e)
        {
            DataRow redPodela = tblPodela.NewRow();
            redPodela["IdArtikal"] = Convert.ToInt32(((Button)sender).Name);
            redPodela["Artikal"] = ((Button)sender).Text;
            DlgOkno frrm = new DlgOkno("Da li placa?");
            switch (frrm.ShowDialog())
            {
                case DialogResult.OK:
                    redPodela["Cena"] = dictCene[Convert.ToInt32(redPodela["IdArtikal"])];
                    break;
                default:
                    redPodela["Cena"] = 0;
                    break;
            }
            suma += Convert.ToDouble(redPodela["Cena"]);
            this.Label2.Text = suma.ToString();
            tblPodela.Rows.Add(redPodela);
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            if (idZaposl == 0)
            {
                MessageBox.Show("Unesite ime!!!");
                return;
            }

            string TextZ = string.Empty;
            TextToBePrinted = DateTime.Now.ToString() + "\r\n";
            TextToBePrinted += "Topli Obrok:    " + "\r\n" + Label1.Text + " - " + "\r\n" + "\r\n";
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = Window2.konekcija;
            SqlCommand cmd1 = InsertZaposleniKomanda(con1);
            if (tblPodela.Rows.Count > 0)
            {
                con1.Open();
                foreach (DataRow red in tblPodela.Rows)
                {
                    try
                    {
                        cmd1.Parameters["@IdIme"].Value = idZaposl;
                        cmd1.Parameters["@IdArtikal"].Value = red["IdArtikal"];
                        cmd1.Parameters["@Cena"].Value = red["Cena"];
                        cmd1.Parameters["@Konobar"].Value = Window2.KonobarIme;
                        cmd1.ExecuteNonQuery();
                        TextZ = string.Empty;
                        TextZ += red["Cena"].ToString() + "din, " + red["Artikal"].ToString();
                        TextToBePrinted += DatabaseHelper.UbacenvbCrLf(TextZ, 31) + "\r\n";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "Splav");
                    }
                }
                con1.Close();
                TextToBePrinted += "." + "\r\n" + "---------------------------------------";
                try
                {
                    StampanjeNarudzbine();
                }
                catch (Exception)
                {
                    MessageBox.Show("Proverite stampac");
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("niste uneli artikle!!!");
                return;
            }
        }

        private void StampanjeNarudzbine()
        {
            Form1.prn.PrintPage += new PrintPageEventHandler(StampanjeNarudzbineHandler);
            Form1.prn.Print();
            Form1.prn.PrintPage -= new PrintPageEventHandler(StampanjeNarudzbineHandler);
        }

        private void StampanjeNarudzbineHandler(object sender, PrintPageEventArgs args)
        {
            Font myFont = new Font("Microsoft San Serif", 11);
            args.Graphics.DrawString(TextToBePrinted, new Font(myFont, FontStyle.Regular), Brushes.Black, margina, 0);
        }

        private SqlCommand InsertZaposleniKomanda(SqlConnection kon)
        {
            SqlCommand cmd = kon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO dbo.NarucenoZaposleni (IDIme, IdArtikal, Cena, Konobar) VALUES (@IdIme, @IdArtikal, @Cena, @Konobar)";
            SqlParameter param = new SqlParameter("@IdIme", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@IdArtikal", SqlDbType.Int);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Cena", SqlDbType.Float);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            param = new SqlParameter("@Konobar", SqlDbType.NVarChar);
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
            return cmd;
        }

        private Button Dugme(string capt, string ime)
        {
            Button dgm = new Button();
            dgm.Name = ime;
            dgm.Text = capt;
            dgm.Width = 81;
            dgm.Height = 59;
            dgm.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
            dgm.BackColor = Color.DarkGoldenrod;
            dgm.ForeColor = Color.White;
            return dgm;
        }

        private Button DugmeZaposleni(string capt, int ime)
        {
            Button dgm = new Button();
            dgm.Name = ime.ToString();
            dgm.Text = capt;
            dgm.Width = 81;
            dgm.Height = 69;
            dgm.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
            dgm.BackColor = Color.IndianRed;
            dgm.ForeColor = Color.White;
            return dgm;
        }

        private Button DugmeArtikli(string capt, int ime)
        {
            Button dgm = new Button();
            dgm.Name = ime.ToString();
            dgm.Text = capt;
            dgm.Width = 89;
            dgm.Height = 69;
            dgm.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
            dgm.BackColor = Color.Yellow;
            dgm.ForeColor = Color.Black;
            return dgm;
        }
    }
}
