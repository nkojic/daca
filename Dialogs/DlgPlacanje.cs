using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WpfAmsterdam
{
    public partial class DlgPlacanje : Form
    {
        private DataTable tblPromet;
        private DataTable tblArtikal;
        private DataTable tblIme;
        private DataTable tblPotpis;
        private double suma = 0;
        private double popust = 0;
        private double konacno = 0;
        private double sumaPodela = 0;
        private int daliTekDugme = 0;
        private bool daliPodela = false;
        private DataTable tblPodela = null;
        private BindingSource bsPodela = null;
        private bool daliNadole = true;
        public static double Broj = 0;
        public static int IdImee = 0;
        public static string potpiss = string.Empty;
        public static string Korisnik = string.Empty;

        public DlgPlacanje(DataTable artikal, DataTable Ime, DataTable potpis)
        {
            InitializeComponent();
            ThemeManager.ApplyWinFormsTheme(this);
            tblArtikal = artikal;
            tblIme = Ime;
            tblPotpis = potpis;
            popust = Form1.popust;
        }

        private void dlgPlacanje_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            tblPromet = DatabaseHelper.FuncPromet(Window2.konekcija, Window2.BrojStola);

            suma = 0;
            foreach (DataRow redd in tblPromet.Rows)
            {
                suma += Convert.ToDouble(redd["Ukupno"]);
            }

            if (suma <= 0)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }

            Label6.Text = suma.ToString("0,0.00", CultureInfo.InvariantCulture);
            DataGridView2.AutoGenerateColumns = false;
            DataGridView2.DataSource = tblPromet;
            if (DataGridView2.RowCount < 1)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }

            konacno = Math.Round(suma * (1 - popust / 100), 2);
            daliPodela = false;
            tblPodela = new DataTable("tblPodela");
            tblPodela.Columns.Add("NacinPlacanja", Type.GetType("System.String"));
            tblPodela.Columns.Add("Iznos", Type.GetType("System.Double"));
            tblPodela.Columns.Add("daliBelo", Type.GetType("System.Boolean"));
            tblPodela.Columns.Add("Potpis", Type.GetType("System.String"));
            tblPodela.Columns.Add("IdIme", Type.GetType("System.Int32"));
            DataRow redPodela = tblPodela.NewRow();
            redPodela["NacinPlacanja"] = "Pazar";
            redPodela["Iznos"] = konacno;
            tblPodela.Rows.Add(redPodela);
            bsPodela = new BindingSource();
            bsPodela.DataSource = tblPodela;
            DataGridView1.AutoGenerateColumns = false;
            DataGridView1.DataSource = bsPodela;
            dgcIdIme.DataSource = tblIme;
            dgcIdIme.ValueMember = "IdIme";
            dgcIdIme.DisplayMember = "Ime";

            Button1.Text = popust.ToString();
            Button1.Enabled = false;
            Label7.Text = konacno.ToString("0,0.00", CultureInfo.InvariantCulture);
            tbSuma.Text = Label7.Text;
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            if (!(Label1.Text == string.Empty))
            {
                try
                {
                    if (!(konacno == Convert.ToDouble(tbSuma.Text)))
                    {
                        MessageBox.Show("Podela placanja nije dobra!!!");
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Suma podele placanja nije dobra!!!");
                    return;
                }

                string TextFiskal = string.Empty;
                StringBuilder sb = new StringBuilder();
                DataRow artikRed = null;
                string artik = string.Empty;
                string porez = string.Empty;
                double cenaPopust = 0;
                double Kolicina = 0;
                double Iznos = 0;
                string deoPorc = string.Empty;
                try
                {
                    foreach (DataRow redSt in tblPromet.Rows)
                    {
                        artikRed = tblArtikal.Rows.Find(redSt["IdArtikal"]);
                        artik = Convert.ToString(artikRed["NazivKasa"]);
                        porez = Convert.ToString(artikRed["Cost"]);
                        cenaPopust = Math.Round(Convert.ToDouble(redSt["Cena"]) * (1 - popust / 100), 2);
                        Kolicina = Math.Round(Convert.ToDouble(redSt["Komada"]) * Convert.ToDouble(redSt["DeoPorcije"]), 2);
                        TextFiskal = redSt["IdArtikal"] + "," + porez.ToString();
                        sb.AppendLine(string.Format("{0},\"{1}\",{2},{3}", TextFiskal, artik, cenaPopust.ToString(), Kolicina.ToString()));
                    }
                    sb.AppendLine("END_OF_SALE,0,0,0,0,0");
                    string tip = string.Empty;
                    foreach (DataRow red in tblPodela.Rows)
                    {
                        if (red["NacinPlacanja"] is DBNull)
                        {
                            red["NacinPlacanja"] = "Pazar";
                        }
                        switch (Convert.ToString(red["NacinPlacanja"]))
                        {
                            case "Pazar":
                                tip = "PAY_CASH";
                                break;
                            case "Kartica":
                                tip = "PAY_DEBIT";
                                break;
                            case "Račun":
                                tip = "PAY_CHEQUE";
                                break;
                            case "Potpis":
                                if (Convert.ToString(red["Potpis"]) == string.Empty)
                                {
                                    MessageBox.Show("Unesite ko je potpisao!!!");
                                    return;
                                }
                                tip = "PAY_CHEQUE";
                                break;
                            default:
                                tip = "PAY_CHEQUE";
                                break;
                        }
                        TextFiskal = tip + ",0";
                        artik = string.Empty;
                        sb.AppendLine(string.Format("{0},\"{1}\",{2},{3}", TextFiskal, artik, red["Iznos"].ToString(), "0,0"));
                    }
                    sb.AppendLine("END_OF_PAY,0,0,0,0,0");
                    sb.AppendLine("USER_ID,0," + Window2.KonobarId.ToString() + ",0,0,0");
                    Form1.sb = sb;
                }
                catch (Exception)
                {
                    MessageBox.Show("Fiskalni račun nije dobar!!!");
                    return;
                }

                int id = DatabaseHelper.ProcInsertNarucenoZ(Window2.konekcija, suma, RichTextBox1.Text,
                    Form1.daliBelo, sb.ToString(), Window2.BrojStola, Window2.KonobarIme);

                SqliteConnection con1 = new SqliteConnection();
                con1.ConnectionString = Window2.konekcija;
                SqliteCommand cmd1 = InsertZNacinKomanda(con1, Form1.daliBelo);
                if (tblPodela.Rows.Count > 0)
                {
                    con1.Open();
                    foreach (DataRow red in tblPodela.Rows)
                    {
                        try
                        {
                            cmd1.Parameters["@IdZaglavlje"].Value = id;
                            cmd1.Parameters["@Nacin"].Value = red["NacinPlacanja"];
                            cmd1.Parameters["@Iznos"].Value = red["Iznos"];
                            if (red["IdIme"] == DBNull.Value && Window2.IdImee != 0)
                            {
                                cmd1.Parameters["@Potpis"].Value = Window2.Korisnik;
                                cmd1.Parameters["@IdIme"].Value = Window2.IdImee;
                            }
                            else
                            {
                                cmd1.Parameters["@Potpis"].Value = red["Potpis"];
                                cmd1.Parameters["@IdIme"].Value = red["IdIme"];
                            }
                            cmd1.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "nije dobro uneseno u bazu");
                        }
                    }
                    con1.Close();
                    this.DialogResult = DialogResult.OK;
                    Form1.TipPlacanja = Label1.Text;
                    Form1.Potpisao = Label3.Text;
                    Form1.popust = popust;
                    Form1.koment = RichTextBox1.Text;
                }
                else
                {
                    MessageBox.Show("niste dobro uneli tip placanja!!!");
                    return;
                }
                DatabaseHelper.ProcZatvoriSto(Window2.konekcija, id, Form1.daliBelo);
                this.Close();
            }
            else
            {
                MessageBox.Show("Unesite način plaćanja!!!");
            }
        }

        private void btnKes_Click(object sender, EventArgs e)
        {
            Label1.Text = ((System.Windows.Forms.Button)sender).Text;
            if (daliPodela)
            {
                try
                {
                    DataRow red = ((DataRowView)bsPodela.Current).Row;
                    red["NacinPlacanja"] = ((System.Windows.Forms.Button)sender).Text;
                    red["daliBelo"] = true;
                    red["Potpis"] = string.Empty;
                    red["IdIme"] = DBNull.Value;
                }
                catch (Exception)
                {
                    tblPodela.Clear();
                    DataRow redPodela = tblPodela.NewRow();
                    redPodela["NacinPlacanja"] = Label1.Text;
                    redPodela["Iznos"] = konacno;
                    redPodela["daliBelo"] = Form1.daliBelo;
                    redPodela["Potpis"] = Label3.Text;
                    if (IdImee == 0)
                    {
                        redPodela["IdIme"] = DBNull.Value;
                    }
                    else
                    {
                        redPodela["IdIme"] = IdImee;
                    }
                    tblPodela.Rows.Add(redPodela);
                    tbSuma.Text = konacno.ToString("0,0.00", CultureInfo.InvariantCulture);
                    sumaPodela = konacno;
                }
            }
            else
            {
                tblPodela.Rows[0]["NacinPlacanja"] = Label1.Text;
                tblPodela.Rows[0]["daliBelo"] = true;
                tblPodela.Rows[0]["Potpis"] = Label3.Text;
                if (IdImee == 0)
                {
                    tblPodela.Rows[0]["IdIme"] = DBNull.Value;
                }
                else
                {
                    tblPodela.Rows[0]["IdIme"] = IdImee;
                }
            }
            daliTekDugme = 0;
            Label3.Text = string.Empty;
            Label2.Text = string.Empty;
            IdImee = 0;
            Form1.daliBelo = true;
        }

        private void btnTek_Click(object sender, EventArgs e)
        {
            switch (daliTekDugme)
            {
                case 0:
                    Label1.Text = "Pazar";
                    Label3.Text = string.Empty;
                    Label2.Text = string.Empty;
                    IdImee = 0;
                    daliTekDugme = 2;
                    break;
                case 1:
                    Label1.Text = "Kartica";
                    Label3.Text = string.Empty;
                    Label2.Text = string.Empty;
                    IdImee = 0;
                    daliTekDugme = 2;
                    break;
                case 2:
                    Label1.Text = "Potpis";
                    DlgPotpis1 frfrm = new DlgPotpis1(tblIme, tblPotpis);
                    if (frfrm.ShowDialog() == DialogResult.OK)
                    {
                        this.Label3.Text = potpiss;
                        this.Label2.Text = Korisnik;
                    }
                    daliTekDugme = 0;
                    break;
            }
            Form1.daliBelo = false;
            if (daliPodela)
            {
                try
                {
                    DataRow red = ((DataRowView)bsPodela.Current).Row;
                    red["NacinPlacanja"] = Label1.Text;
                    red["daliBelo"] = false;
                    red["Potpis"] = Label3.Text;
                    if (IdImee == 0)
                    {
                        red["IdIme"] = DBNull.Value;
                    }
                    else
                    {
                        red["IdIme"] = IdImee;
                    }
                }
                catch (Exception)
                {
                    tblPodela.Clear();
                    DataRow redPodela = tblPodela.NewRow();
                    redPodela["NacinPlacanja"] = Label1.Text;
                    redPodela["Iznos"] = konacno;
                    redPodela["daliBelo"] = false;
                    redPodela["Potpis"] = Label3.Text;
                    if (IdImee == 0)
                    {
                        redPodela["IdIme"] = DBNull.Value;
                    }
                    else
                    {
                        redPodela["IdIme"] = IdImee;
                    }
                    tblPodela.Rows.Add(redPodela);
                    tbSuma.Text = konacno.ToString("0,0.00", CultureInfo.InvariantCulture);
                    sumaPodela = konacno;
                }
            }
            else
            {
                tblPodela.Rows[0]["NacinPlacanja"] = Label1.Text;
                tblPodela.Rows[0]["daliBelo"] = false;
                tblPodela.Rows[0]["Potpis"] = Label3.Text;
                if (IdImee == 0)
                {
                    tblPodela.Rows[0]["IdIme"] = DBNull.Value;
                }
                else
                {
                    tblPodela.Rows[0]["IdIme"] = IdImee;
                }
            }
        }

        private void btnPodela_Click(object sender, EventArgs e)
        {
            if (daliPodela == false)
            {
                Panel2.Visible = true;
                daliPodela = true;
            }
            else
            {
                Panel2.Visible = false;
                daliPodela = false;
                tblPodela.Clear();
                DataRow redPodela = tblPodela.NewRow();
                redPodela["NacinPlacanja"] = Label1.Text;
                redPodela["Iznos"] = konacno;
                redPodela["daliBelo"] = Form1.daliBelo;
                redPodela["Potpis"] = Label3.Text;
                if (IdImee == 0)
                {
                    redPodela["IdIme"] = DBNull.Value;
                }
                else
                {
                    redPodela["IdIme"] = IdImee;
                }
                tblPodela.Rows.Add(redPodela);
                tbSuma.Text = konacno.ToString("0,0.00", CultureInfo.InvariantCulture);
                sumaPodela = konacno;
                DugmadVisible(true);
                btnTek.Visible = true;
            }
        }

        private void btnNova_Click(object sender, EventArgs e)
        {
            DataRow redPodela = tblPodela.NewRow();
            redPodela["NacinPlacanja"] = Label1.Text;
            redPodela["daliBelo"] = Form1.daliBelo;
            redPodela["Potpis"] = Label3.Text;
            redPodela["Iznos"] = konacno - sumaPodela;
            tblPodela.Rows.Add(redPodela);
            sumaPodela = konacno;
            tbSuma.Text = konacno.ToString("0,0.00", CultureInfo.InvariantCulture);
            bsPodela.MoveLast();
            if (bsPodela.Count == 2)
            {
                if (Form1.daliBelo)
                {
                    btnTek.Visible = false;
                }
                else
                {
                    DugmadVisible(false);
                }
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (bsPodela.Count > 1)
            {
                bsPodela.RemoveAt(bsPodela.Count - 1);
                sumaPodela = 0;
                foreach (DataRow redd in tblPodela.Rows)
                {
                    sumaPodela += Convert.ToDouble(redd["Iznos"]);
                }
                tbSuma.Text = sumaPodela.ToString("0,0.00", CultureInfo.InvariantCulture);
            }
            if (bsPodela.Count == 1)
            {
                DugmadVisible(true);
                btnTek.Visible = true;
            }
        }

        private void btnGoreDole_Click(object sender, EventArgs e)
        {
            if (bsPodela.Count > 1)
            {
                switch (daliNadole)
                {
                    case true:
                        if (bsPodela.IndexOf(bsPodela.Current) < bsPodela.Count - 1)
                        {
                            bsPodela.MoveNext();
                        }
                        else
                        {
                            daliNadole = false;
                            bsPodela.MovePrevious();
                        }
                        break;
                    case false:
                        if (bsPodela.IndexOf(bsPodela.Current) > 0)
                        {
                            bsPodela.MovePrevious();
                        }
                        else
                        {
                            daliNadole = true;
                            bsPodela.MoveNext();
                        }
                        break;
                }
            }
        }

        private void btnKalk_Click(object sender, EventArgs e)
        {
            DlgKalkPlacanje frm = new DlgKalkPlacanje();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                DataRow red = ((DataRowView)bsPodela.Current).Row;
                red["Iznos"] = Broj;
            }
            sumaPodela = 0;
            foreach (DataRow redd in tblPodela.Rows)
            {
                sumaPodela += Convert.ToDouble(redd["Iznos"]);
            }
            tbSuma.Text = sumaPodela.ToString("0,0.00", CultureInfo.InvariantCulture);
        }

        private SqliteCommand InsertZNacinKomanda(SqliteConnection kon, bool belo)
        {
            SqliteCommand cmd = kon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (belo)
            {
                cmd.CommandText = SQLInsertNarucenoZNacin();
            }
            else
            {
                cmd.CommandText = SQLInsertNarucenoZNacinTek();
            }
            cmd.Parameters.AddWithValue("@IdZaglavlje", 0);
            cmd.Parameters.AddWithValue("@Nacin", "");
            cmd.Parameters.AddWithValue("@Iznos", 0.0);
            cmd.Parameters.AddWithValue("@Potpis", "");
            cmd.Parameters.AddWithValue("@IdIme", 0);
            return cmd;
        }

        private string SQLInsertNarucenoZNacin()
        {
            return "INSERT INTO NarucenoZNacin (IDZaglavlje, NacinPlacanja, Iznos, Potpis, IdIme) " +
                "VALUES (@IdZaglavlje, @Nacin, @Iznos, @Potpis, @IdIme)";
        }

        private string SQLInsertNarucenoZNacinTek()
        {
            return "INSERT INTO KuhinjaZNacin (IDZaglavlje, NacinPlacanja, Iznos, Potpis, IdIme) " +
                "VALUES (@IdZaglavlje, @Nacin, @Iznos, @Potpis, @IdIme)";
        }

        private void DugmadVisible(bool dali)
        {
            btnKes.Visible = dali;
            btnKartica.Visible = dali;
            btnRacun.Visible = dali;
        }
    }
}
