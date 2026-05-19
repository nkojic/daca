using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

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
            ThemeManager.ApplyWinFormsTheme(this);
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

            // Stilizovanje nakon kreiranja kontrola
            Label1.BackColor = ThemeManager.WfHeader;
            Label1.ForeColor = Color.White;
            Label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            Label1.BorderStyle = BorderStyle.None;

            Label2.BackColor = ThemeManager.WfHeader;
            Label2.ForeColor = ThemeManager.WfButtonDa;
            Label2.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            Label2.BorderStyle = BorderStyle.None;

            DataGridView2.BackgroundColor = ThemeManager.WfPanel;
            DataGridView2.DefaultCellStyle.BackColor = ThemeManager.WfPanel;
            DataGridView2.DefaultCellStyle.ForeColor = ThemeManager.WfTextColor;
            DataGridView2.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            DataGridView2.DefaultCellStyle.SelectionBackColor = ThemeManager.WfAccent;
            DataGridView2.DefaultCellStyle.SelectionForeColor = Color.White;
            DataGridView2.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);
            DataGridView2.AlternatingRowsDefaultCellStyle.BackColor = ThemeManager.WfBackground;
            DataGridView2.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.WfHeader;
            DataGridView2.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DataGridView2.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            DataGridView2.EnableHeadersVisualStyles = false;
            DataGridView2.GridColor = ThemeManager.WfBackground;
            DataGridView2.BorderStyle = BorderStyle.None;
            DataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DataGridView2.RowHeadersVisible = false;
            DataGridView2.Columns["IdArtikal1"].Width = 220;
            DataGridView2.Columns["IdArtikal1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DataGridView2.Columns["Cena"].Width = 70;

            btnNE.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnDA.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
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
            SqliteConnection con1 = new SqliteConnection();
            con1.ConnectionString = Window2.konekcija;
            SqliteCommand cmd1 = InsertZaposleniKomanda(con1);
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

        private SqliteCommand InsertZaposleniKomanda(SqliteConnection kon)
        {
            SqliteCommand cmd = kon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO NarucenoZaposleni (IDIme, IdArtikal, Cena, Konobar) VALUES (@IdIme, @IdArtikal, @Cena, @Konobar)";
            cmd.Parameters.AddWithValue("@IdIme", 0);
            cmd.Parameters.AddWithValue("@IdArtikal", 0);
            cmd.Parameters.AddWithValue("@Cena", 0.0);
            cmd.Parameters.AddWithValue("@Konobar", "");
            return cmd;
        }

        private Button Dugme(string capt, string ime)
        {
            Button dgm = new Button();
            dgm.Name = ime;
            dgm.Text = capt;
            dgm.Width = 140;
            dgm.Height = 48;
            dgm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgm.BackColor = ThemeManager.WfAccent;
            dgm.ForeColor = Color.White;
            dgm.FlatStyle = FlatStyle.Flat;
            dgm.FlatAppearance.BorderSize = 0;
            dgm.Margin = new Padding(3);
            dgm.Cursor = Cursors.Hand;
            ThemeManager.RoundControl(dgm, 20);
            return dgm;
        }

        private Button DugmeZaposleni(string capt, int ime)
        {
            Button dgm = new Button();
            dgm.Name = ime.ToString();
            dgm.Text = capt;
            dgm.Width = 110;
            dgm.Height = 48;
            dgm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgm.BackColor = ThemeManager.WfButtonNe;
            dgm.ForeColor = Color.White;
            dgm.FlatStyle = FlatStyle.Flat;
            dgm.FlatAppearance.BorderSize = 0;
            dgm.Margin = new Padding(3);
            dgm.Cursor = Cursors.Hand;
            ThemeManager.RoundControl(dgm, 20);
            return dgm;
        }

        private Button DugmeArtikli(string capt, int ime)
        {
            Button dgm = new Button();
            dgm.Name = ime.ToString();
            dgm.Text = capt;
            dgm.Width = 110;
            dgm.Height = 58;
            dgm.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgm.BackColor = ThemeManager.WfPanel;
            dgm.ForeColor = ThemeManager.WfTextColor;
            dgm.FlatStyle = FlatStyle.Flat;
            dgm.FlatAppearance.BorderColor = ThemeManager.WfAccent;
            dgm.FlatAppearance.BorderSize = 2;
            dgm.Margin = new Padding(4);
            dgm.Cursor = Cursors.Hand;
            ThemeManager.RoundControl(dgm, 16);
            return dgm;
        }
    }
}
