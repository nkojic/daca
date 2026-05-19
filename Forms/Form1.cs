using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;

namespace WpfAmsterdam
{
    public partial class Form1 : Form
    {
        private string Direktorijum = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).ToString() + "\\Data\\";
        private string fiskalFilename = "C:\\Metaline\\Exch\\Lnk\\To_FP\\ABC_0000.csv";
        private string fiskalFilenameUser = "\\\\DESKTOP1\\Metaline\\Exch\\Lnk\\To_FP\\ABC_0001.csv";
        private int margina = 10;
        public static PrintDocument prn;
        public static string strPrinterName = "BIXOLON SRP-350plusII";
        private string strPrinterNameDatecs = "Datecs EP-1000";
        private string strPrinterNameAdobe = "Adobe PDF";
        private string strPrinterNameCanon = "Canon iP4800 series";
        private string strPrinterNameBixolon = "Datecs EP-10001";
        private Window2 _win2;
        public static bool daliPaint = true;
        private DsKonStoloviStavke dsPrebacivanje;
        private KonobStoloviStavkeTableAdapter daPrebacivanje;
        public static int TrenutniIdArt = 0;
        public static int IdArt = 0;
        public static string ImeArt = string.Empty;
        private double deo = 1;
        public static double sumica = 0;
        public static double kom = 0;
        public static string tip = string.Empty;
        public static double cenaArt = 0;
        public static string TipPlacanja = string.Empty;
        public static bool daliBelo = true;
        public static string Potpisao = string.Empty;
        public static string koment = string.Empty;
        public static double popust = 0;
        private string TextToBePrinted = string.Empty;
        private DataTable tblKonStStavke = null;
        public static StringBuilder sb = null;
        public static StringBuilder sbPredracun = null;
        public static double konacno = 0;
        public static bool daliNapravljenRacun = false;
        private DataTable tblIme;
        private DataTable tblPotpis;
        private DataTable tblArtikliKojiImajuPrilog;
        private DataTable tblArtikliPrilog;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (daliPaint)
            {
                daliPaint = false;
                Label1.Text = Window2.BrojStola + "  " + Window2.KonobarIme;
                daliNapravljenRacun = Convert.ToBoolean(Window2.tblOtvoreniStolovi.Select("BrojStola = '" + Window2.BrojStola + "'")[0]["daliRacun"]);
                popust = Convert.ToDouble(Window2.tblOtvoreniStolovi.Select("BrojStola = '" + Window2.BrojStola + "'")[0]["popust"]);
                daPrebacivanje.Fill(dsPrebacivanje.KonobStoloviStavke, Window2.BrojStola, Window2.KonobarId);
                DataView dw1 = dsPrebacivanje.KonobStoloviStavke.DefaultView;
                tblKonStStavke = dsPrebacivanje.KonobStoloviStavke.Copy();
                DataView dw2 = tblKonStStavke.DefaultView;
                dw1.RowFilter = "Odneto = False";
                dw2.RowFilter = "Odneto = True";
                DataGridView1.DataSource = dw1;
                DataGridView2.DataSource = dw2;
                sumica = 0;
                foreach (DataRow rdd in dsPrebacivanje.KonobStoloviStavke.Rows)
                {
                    sumica += Convert.ToDouble(rdd["Ukupno"]);
                }
                lblSuma.Text = sumica.ToString("0,0.00", CultureInfo.InvariantCulture);
                if (daliNapravljenRacun)
                {
                    DaliNapravljenRacunVisible(false);
                }
                else
                {
                    DaliNapravljenRacunVisible(true);
                    PraznjenjeKontrola();
                }
            }
        }

        public Form1(Window2 win2)
        {
            InitializeComponent();
            ThemeManager.ApplyWinFormsTheme(this);

            // Kategorije levo - posebno stilizovanje
            KategorijaDataGridView.DefaultCellStyle.BackColor = ThemeManager.WfAccent;
            KategorijaDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            KategorijaDataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            KategorijaDataGridView.DefaultCellStyle.SelectionBackColor = ThemeManager.WfHeader;
            KategorijaDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            KategorijaDataGridView.RowTemplate.DefaultCellStyle.BackColor = ThemeManager.WfAccent;
            KategorijaDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;

            _win2 = win2;

            switch (Environment.MachineName)
            {
                case "DESKTOP1":
                    strPrinterName = "Datecs EP-700";
                    break;
                case "DACA-PC":
                    strPrinterName = strPrinterNameCanon;
                    break;
                case "DESKTOP-HP":
                    strPrinterName = strPrinterNameAdobe;
                    break;
                default:
                    strPrinterName = strPrinterNameDatecs;
                    fiskalFilename = fiskalFilenameUser;
                    margina = 3;
                    break;
            }

            prn = new PrintDocument();
            prn.PrinterSettings.PrinterName = strPrinterName;
            prn.PrinterSettings.Copies = 1;

            dsPrebacivanje = new DsKonStoloviStavke();
            daPrebacivanje = new KonobStoloviStavkeTableAdapter();
            daPrebacivanje.ConnectionString = Window2.konekcija;
            DataGridView1.AutoGenerateColumns = false;
            DataGridView2.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ArtikliTableAdapter.ConnectionString = Window2.konekcija;
            this.ArtikliTableAdapter.Fill(this.DsArtikli.Artikli);
            this.Kategorija1TableAdapter.ConnectionString = Window2.konekcija;
            this.Kategorija1TableAdapter.Fill(this.DsArtikli.Kategorija1);
            this.KategorijaTableAdapter.ConnectionString = Window2.konekcija;
            this.KategorijaTableAdapter.Fill(this.DsArtikli.Kategorija);
            Label1.Text = Window2.BrojStola + "  " + Window2.KonobarIme;

            tblIme = DatabaseHelper.ReaderTabela(Window2.konekcija, "SELECT * FROM Ime WHERE (IdPotpis <> 24) AND (aktivan = 1)");
            tblPotpis = DatabaseHelper.ReaderTabela(Window2.konekcija, "SELECT * FROM tblPotpis WHERE IdPotpis BETWEEN 1 AND 20");
            tblArtikliKojiImajuPrilog = DatabaseHelper.ReaderTabela(Window2.konekcija, "SELECT IdArtikal FROM ArtikliKojiImajuPrilog");
            tblArtikliPrilog = DatabaseHelper.ReaderTabela(Window2.konekcija, "SELECT IdArtikal, Naziv FROM ArtikliPrilog");

            dsPrebacivanje.KonobStoloviStavke.Columns["Odneto"].DefaultValue = false;
        }

        private void KategorijaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int idkat = Convert.ToInt32(((DataRowView)KategorijaBindingSource.Current).Row["IdKat"]);
            DataRow[] redovi = DsArtikli.Kategorija1.Select("IdKat = " + idkat);
            flPanel1.Controls.Clear();
            foreach (DataRow red in redovi)
            {
                Button btn = Dugme(red["PodKat"].ToString(), red["IdKat1"].ToString());
                btn.Click += Button_Click;
                flPanel1.Controls.Add(btn);
            }
            flPanel2.Controls.Clear();
            PraznjenjeKontrola();
        }

        private Button Dugme(string capt, string ime)
        {
            Button dgm = new Button();
            dgm.Name = ime;
            dgm.Text = capt;
            dgm.Width = 100;
            dgm.Height = 80;
            dgm.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgm.BackColor = ThemeManager.WfAccent;
            dgm.ForeColor = Color.White;
            dgm.FlatStyle = FlatStyle.Flat;
            dgm.FlatAppearance.BorderSize = 0;
            dgm.Margin = new Padding(3);
            dgm.Cursor = Cursors.Hand;
            ThemeManager.RoundControl(dgm, 16);
            return dgm;
        }

        private Button DugmeArtikli(string capt, string ime)
        {
            Button dgm = new Button();
            dgm.Name = ime;
            dgm.Text = capt;
            dgm.Width = 110;
            dgm.Height = 75;
            dgm.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgm.BackColor = ThemeManager.WfButtonBg;
            dgm.ForeColor = ThemeManager.WfTextColor;
            dgm.FlatStyle = FlatStyle.Flat;
            dgm.FlatAppearance.BorderColor = ThemeManager.WfAccent;
            dgm.FlatAppearance.BorderSize = 2;
            dgm.Margin = new Padding(3);
            dgm.Cursor = Cursors.Hand;
            ThemeManager.RoundControl(dgm, 16);
            return dgm;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            flPanel2.Controls.Clear();
            int idkat1 = Convert.ToInt32(((Button)sender).Name);
            DataRow[] redovi = DsArtikli.Artikli.Select("IdKat1 = " + idkat1);

            foreach (DataRow red in redovi)
            {
                Button btn = DugmeArtikli(red["Naziv"].ToString(), red["IdArtikal"].ToString());
                btn.Click += ButtonArtikli_Click;
                flPanel2.Controls.Add(btn);
            }
            lblKomada.Text = "0";
            kom = 0;
        }

        private void ButtonArtikli_Click(object sender, EventArgs e)
        {
            IdArt = Convert.ToInt32(((Button)sender).Name);
            if (IdArt != TrenutniIdArt)
            {
                TrenutniIdArt = IdArt;
                kom = 0;
                DataRow red = DsArtikli.Artikli.Select("IdArtikal = " + IdArt.ToString())[0];
                lblJM.Text = red["ProdajnaJedMere"].ToString();
                deo = 1;
                lblDeo.Text = "1";
                cenaArt = Convert.ToDouble(red["Price"]);
                tip = red["Tip"].ToString();
                ImeArt = red["NazivKasa"].ToString();
                this.Label2.Text = ImeArt;
                lblCena.Text = cenaArt.ToString();
            }
            kom = kom + 1;
            lblKomada.Text = kom.ToString();
            lblUkupno.Text = (deo * kom * cenaArt).ToString();
        }

        private void PraznjenjeKontrola()
        {
            Label2.Text = "";
            lblKomada.Text = "";
            kom = 0;
            lblJM.Text = "";
            deo = 1;
            lblDeo.Text = "1";
            cenaArt = 0;
            tip = string.Empty;
            TrenutniIdArt = 0;
            IdArt = 0;
            ImeArt = string.Empty;
            lblCena.Text = "";
            lblUkupno.Text = "";
            rtb1.Text = "";
        }

        private void btnKomada_Click(object sender, EventArgs e)
        {
            DlgKalk frm = new DlgKalk(false);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblKomada.Text = kom.ToString();
                lblUkupno.Text = (deo * kom * cenaArt).ToString();
            }
        }

        private void btnCena_Click(object sender, EventArgs e)
        {
            DlgKalk frm = new DlgKalk(true);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                lblCena.Text = cenaArt.ToString();
                lblUkupno.Text = (deo * kom * cenaArt).ToString();
            }
        }

        private void btnDeo_Click(object sender, EventArgs e)
        {
            if (deo == 1)
            {
                deo = 0.7;
            }
            else
            {
                deo = 1;
            }
            lblDeo.Text = deo.ToString();
            lblUkupno.Text = (deo * kom * cenaArt).ToString();
        }

        private void btnUpisi_Click(object sender, EventArgs e)
        {
            if (IdArt != 0)
            {
                DataRow novaStavka = dsPrebacivanje.KonobStoloviStavke.NewRow();
                int id = dsPrebacivanje.KonobStoloviStavke.Select("BrojStola = '" + Window2.BrojStola + "' AND IdKonobar = " + Window2.KonobarId.ToString()).Length;
                novaStavka["Id"] = id + 1;
                novaStavka["BrojStola"] = Window2.BrojStola;
                novaStavka["IdKonobar"] = Window2.KonobarId;
                novaStavka["IdArtikal"] = IdArt;
                novaStavka["Komada"] = kom;
                novaStavka["vreme"] = DateTime.Now.TimeOfDay.ToString();
                try
                {
                    novaStavka["DeoPorcije"] = deo;
                }
                catch (Exception)
                {
                    novaStavka["DeoPorcije"] = 1;
                }
                novaStavka["Cena"] = cenaArt;
                novaStavka["JedMere"] = lblJM.Text;
                if (tip != "Kuhinja")
                {
                    tip = "Šank";
                }
                novaStavka["Tip"] = tip;
                novaStavka["ImeArtikal"] = ImeArt;
                novaStavka["Komentar"] = rtb1.Text;
                try
                {
                    dsPrebacivanje.KonobStoloviStavke.Rows.Add(novaStavka);
                }
                catch (Exception)
                {
                    MessageBox.Show("pokušajte ponovo");
                }
            }
            if (tblArtikliKojiImajuPrilog.Select("IdArtikal = " + IdArt.ToString()).Length != 0)
            {
                DlgPrilozi frfrm = new DlgPrilozi(tblArtikliPrilog);
                if (frfrm.ShowDialog() == DialogResult.OK)
                {
                    if (IdArt != 0)
                    {
                        DataRow novaStavka = dsPrebacivanje.KonobStoloviStavke.NewRow();
                        int id = dsPrebacivanje.KonobStoloviStavke.Select("BrojStola = '" + Window2.BrojStola + "' AND IdKonobar = " + Window2.KonobarId.ToString()).Length;
                        novaStavka["Id"] = id + 1;
                        novaStavka["BrojStola"] = Window2.BrojStola;
                        novaStavka["IdKonobar"] = Window2.KonobarId;
                        novaStavka["IdArtikal"] = IdArt;
                        novaStavka["Komada"] = kom;
                        novaStavka["vreme"] = DateTime.Now.TimeOfDay.ToString();
                        try
                        {
                            novaStavka["DeoPorcije"] = deo;
                        }
                        catch (Exception)
                        {
                            novaStavka["DeoPorcije"] = 1;
                        }
                        novaStavka["Cena"] = 0;
                        novaStavka["JedMere"] = "kom";
                        if (tip != "Kuhinja")
                        {
                            tip = "Šank";
                        }
                        novaStavka["Tip"] = tip;
                        novaStavka["ImeArtikal"] = ImeArt;
                        novaStavka["Komentar"] = string.Empty;
                        try
                        {
                            dsPrebacivanje.KonobStoloviStavke.Rows.Add(novaStavka);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("pokušajte ponovo");
                        }
                    }
                }
            }
            PraznjenjeKontrola();
        }

        private void btnPrebaci_Click(object sender, EventArgs e)
        {
            TekstNarudzbine("Kuhinja");
            TekstNarudzbine("Šank");
            try
            {
                DataRow[] redovi = dsPrebacivanje.KonobStoloviStavke.Select("Odneto = FALSE");
                if (redovi.Length > 0)
                {
                    for (int i = redovi.Length - 1; i >= 0; i--)
                    {
                        dsPrebacivanje.KonobStoloviStavke.Rows.Remove(redovi[i]);
                    }
                }
            }
            catch (Exception)
            {
            }
            daPrebacivanje.Update(dsPrebacivanje.KonobStoloviStavke);
            flPanel1.Controls.Clear();
            flPanel2.Controls.Clear();
            PraznjenjeKontrola();
            this.Hide();
            _win2.Show();
            _win2.WindowState = System.Windows.WindowState.Maximized;
            if (!Window2.daliAdmin && Window2.KoristiKartice)
            {
                DlgOkno frrm = new DlgOkno("Da li želite da nastavite unos?");
                if (frrm.ShowDialog() == DialogResult.OK)
                {
                    Window2.Timer1.Interval = 7000;
                    Window2.Timer1.Start();
                }
                else
                {
                    Window2.Timer1.Interval = 700;
                    Window2.Timer1.Start();
                }
            }
        }

        private void btnPonisti_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow[] redovi = dsPrebacivanje.KonobStoloviStavke.Select("Odneto = FALSE");
                if (redovi.Length > 0)
                {
                    dsPrebacivanje.KonobStoloviStavke.Rows.Remove(redovi[redovi.Length - 1]);
                }
            }
            catch (Exception)
            {
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                kom = kom - 1;
            }
            catch (Exception)
            {
                kom = -1;
            }
            lblKomada.Text = kom.ToString();
            try
            {
                lblUkupno.Text = (deo * kom * cenaArt).ToString();
            }
            catch (Exception)
            {
                lblUkupno.Text = "0";
            }
        }

        private void btnRacun_Click(object sender, EventArgs e)
        {
            if (DataGridView1.RowCount > 0)
            {
                MessageBox.Show("Niste isporučili zadnju narudžbinu");
                return;
            }
            else if (DataGridView2.RowCount == 0)
            {
                MessageBox.Show("Nema ništa za naplatu!!!");
                return;
            }
            else if (sumica <= 0)
            {
                MessageBox.Show("Suma za naplatu je 0. Proverite šta se desilo!!!");
                return;
            }
            DlgRacun frfrm = new DlgRacun();
            DialogResult result = frfrm.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (popust != 0)
                {
                    DlgPopust fr = new DlgPopust(tblIme, tblPotpis);
                    fr.ShowDialog();
                }
                if (!daliNapravljenRacun)
                {
                    try
                    {
                        StampanjePredracuna();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Proverite štampač");
                    }
                }
                daliNapravljenRacun = true;
                SqliteConnection con1 = new SqliteConnection();
                con1.ConnectionString = Window2.konekcija;
                SqliteCommand cmd1 = con1.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = SQLUpdateKonobariStolovi();
                try
                {
                    con1.Open();
                    cmd1.ExecuteNonQuery();
                    con1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Window2.tblOtvoreniStolovi.Select("BrojStola = '" + Window2.BrojStola + "'")[0]["daliRacun"] = true;
                Window2.tblOtvoreniStolovi.Select("BrojStola = '" + Window2.BrojStola + "'")[0]["popust"] = popust;
                DaliNapravljenRacunVisible(false);
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("Greška u stavkama računa. Proverite!!!");
            }
        }

        private void btnZatvoriSto_Click(object sender, EventArgs e)
        {
            if (daliNapravljenRacun)
            {
                DlgPlacanje frfrm = new DlgPlacanje(this.DsArtikli.Artikli, tblIme, tblPotpis);
                DialogResult result = frfrm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (daliBelo)
                    {
                        string tFileName = Direktorijum + "\\ABC_0000.csv";
                        try
                        {
                            tFileName = Direktorijum + "\\ABC_0000.csv";
                            if (File.Exists(tFileName))
                            {
                                File.Delete(tFileName);
                            }
                            using (StreamWriter fw = new StreamWriter(tFileName))
                            {
                                fw.Write(sb);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "pisanje");
                        }
                        try
                        {
                            if (File.Exists(fiskalFilename))
                            {
                                File.Delete(fiskalFilename);
                            }
                            File.Move(tFileName, fiskalFilename);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("podaci nisu prebačeni u fiskalnu kasu");
                        }
                    }
                }
                else if (result == DialogResult.Abort)
                {
                    rtb1.Visible = true;
                    MessageBox.Show("Suma za naplatu je pogresna. Upišite šta se desilo (najmanje 5 reči)!!!");
                    return;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (DataGridView2.RowCount == 0)
                {
                    MessageBox.Show("Nema ništa za naplatu. Sto se zatvara!!!");
                }
                if (sumica <= 0)
                {
                    if (rtb1.Text.Length < 10)
                    {
                        MessageBox.Show("Suma za naplatu je 0. Upišite šta se desilo (najmanje 5 reči)!!!");
                        return;
                    }
                    else
                    {
                        int id = DatabaseHelper.ProcInsertNarucenoZ(Window2.konekcija, sumica, rtb1.Text, false, "", Window2.BrojStola, Window2.KonobarIme);
                    }
                }
                else
                {
                    MessageBox.Show("Niste napravili račun");
                    return;
                }
            }
            DatabaseHelper.ProcBrisanjeStola(Window2.konekcija, Window2.BrojStola);
            flPanel1.Controls.Clear();
            PraznjenjeKontrola();
            this.Hide();
            _win2.Show();
            _win2.WindowState = System.Windows.WindowState.Maximized;
            if (!Window2.daliAdmin && Window2.KoristiKartice)
            {
                Window2.Timer1.Interval = 700;
                Window2.Timer1.Start();
            }
        }

        private string SQLUpdateKonobariStolovi()
        {
            string tekst = "UPDATE KonobariStolovi SET daliRacun = 1, popust = " + popust.ToString() +
                " WHERE brojStola = '" + Window2.BrojStola + "'";
            if (popust > 0)
            {
                tekst = "UPDATE KonobariStolovi SET daliRacun = 1, popust = " + popust.ToString() +
                    ", IdIme = " + Window2.IdImee.ToString() + ", Korisnik = '" + Window2.Korisnik +
                    "' WHERE brojStola = '" + Window2.BrojStola + "'";
            }
            return tekst;
        }

        private void TekstNarudzbine(string tipParam)
        {
            string Text = string.Empty;
            int brojRedovaVecihOdNule = 0;
            DataRow[] redovi = dsPrebacivanje.KonobStoloviStavke.Select("Odneto = FALSE and Tip = '" + tipParam + "'");
            if (redovi.Length > 0)
            {
                TextToBePrinted = DateTime.Now.ToString() + "\r\n";
                TextToBePrinted += tipParam.ToUpper() + ":    " + "\r\n" + Window2.KonobarIme + " - " + Window2.BrojStola + "\r\n\r\n";
                double iznos = 0;
                foreach (DataRow red in redovi)
                {
                    red["Odneto"] = true;
                    if (Convert.ToDouble(red["Komada"]) > 0)
                    {
                        brojRedovaVecihOdNule += 1;
                        iznos += Convert.ToDouble(red["Komada"]) * Convert.ToDouble(red["Cena"]);
                        Text = string.Empty;
                        Text += red["Komada"].ToString() + " X ";
                        if (Convert.ToDouble(red["DeoPorcije"]) != 1)
                        {
                            Text += "1/2 porc. ";
                        }
                        Text += red["ImeArtikal"].ToString();
                        TextToBePrinted += DatabaseHelper.UbacenvbCrLf(Text, 31) + "\r\n";
                        Text = string.Empty;
                        Text += red["Komada"].ToString() + " X ";
                        Text += red["Cena"].ToString() + " = " + (Convert.ToDouble(red["Cena"]) * Convert.ToDouble(red["Komada"])).ToString();
                        TextToBePrinted += DatabaseHelper.UbacenvbCrLf(Text, 31) + "\r\n";
                        if (red["Komentar"].ToString() != string.Empty)
                        {
                            TextToBePrinted += DatabaseHelper.UbacenvbCrLf(red["Komentar"].ToString(), 31) + "\r\n";
                        }
                    }
                }
                TextToBePrinted += "." + "\r\n" + "---------------------------------------";
                TextToBePrinted += "." + "\r\n" + "  UKUPNO: " + iznos.ToString();
                if (brojRedovaVecihOdNule > 0)
                {
                    try
                    {
                        StampanjeNarudzbine();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Proverite štampač");
                    }
                }
            }
        }

        private void StampanjeNarudzbine()
        {
            prn.PrintPage += StampanjeNarudzbineHandler;
            prn.Print();
            prn.PrintPage -= StampanjeNarudzbineHandler;
        }

        private void StampanjeNarudzbineHandler(object sender, PrintPageEventArgs args)
        {
            Font myFont = new Font("Microsoft San Serif", 11);
            args.Graphics.DrawString(TextToBePrinted, new Font(myFont, FontStyle.Regular), System.Drawing.Brushes.Black, margina, 0);
        }

        private void StampanjePredracuna()
        {
            prn.PrintPage += StampanjePredracunaHendler;
            prn.Print();
            prn.PrintPage -= StampanjePredracunaHendler;
        }

        private void StampanjePredracunaHendler(object sender, PrintPageEventArgs args)
        {
            float yPos = 30;
            Font myFont = new Font("Microsoft San Serif", 18);
            Font drawFont = new Font("Arial", 12);
            Font normalFont = new Font("TimesNewRoman", 10);
            float visina = myFont.GetHeight(args.Graphics);
            float visina1 = drawFont.GetHeight(args.Graphics);
            args.Graphics.DrawString("SPECIFIKACIJA" + "\r\n", new Font(myFont, FontStyle.Bold), System.Drawing.Brushes.Black, margina, yPos);
            yPos += visina;
            args.Graphics.DrawString("ovo nije fiskalni račun !!!", new Font(normalFont, FontStyle.Bold), System.Drawing.Brushes.Black, margina + 19, yPos);

            yPos += visina;
            args.Graphics.DrawString(DateTime.Now.ToLongDateString() + "   " + DateTime.Now.ToShortTimeString(), new Font(normalFont, FontStyle.Italic), System.Drawing.Brushes.Black, margina + 17, yPos);
            yPos += 2 * visina1;
            args.Graphics.DrawString("Konobar " + Window2.KonobarId.ToString(), new Font(normalFont, FontStyle.Bold), System.Drawing.Brushes.Black, margina + 45, yPos);
            yPos += visina;
            args.Graphics.DrawString("Iznos za naplatu: ", new Font(normalFont, FontStyle.Italic), System.Drawing.Brushes.Black, margina, yPos + 3);
            args.Graphics.DrawString(konacno.ToString("0,0.00", CultureInfo.InvariantCulture), new Font(drawFont, FontStyle.Bold), System.Drawing.Brushes.Black, 125, yPos);

            yPos += visina;
            args.Graphics.DrawString(sbPredracun.ToString(), new Font(normalFont, FontStyle.Regular), System.Drawing.Brushes.Black, margina, yPos);
        }

        private void DaliNapravljenRacunVisible(bool dali)
        {
            Panel2.Visible = dali;
            lblKomada.Visible = dali;
            Button1.Visible = dali;
            btnUpisi.Visible = dali;
            btnRacun.Visible = dali;
            KategorijaDataGridView.Visible = dali;
            Label2.Visible = dali;
            DataGridView1.Visible = dali;
        }
    }
}
