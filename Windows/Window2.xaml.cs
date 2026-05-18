using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Data.SqlClient;

namespace WpfAmsterdam
{
    public partial class Window2 : Window
    {
        public static string konekcijaPom = "User ID=daca;Password=spider2204;Data Source=DACA-PC\\DACAR2;Initial Catalog=AmsterdamSplavNovi";
        public static string konekcijaPom1 = "User ID=daca;Password=spider2204;Data Source=WIN-PC\\DACASQL14;Initial Catalog=AmsterdamSplavNovi";
        public static string konekcijaPom2 = "User ID=daca;Password=spider2204;Data Source=DACHA-LAPTOP\\DACASQL14;Initial Catalog=AmsterdamSplavNovi";
        public static string konekcijaPom3 = "User ID=daca;Password=spider2204;Data Source=LENOVO-PC\\DACASQL2014;Initial Catalog=AmsterdamSplavNovi";
        public static string konekcijaPom4 = "User ID=daca;Password=spider2204;Data Source=DESKTOP-HP\\SQLEXPRESS16;Initial Catalog=AmsterdamSplavNovi";
        //public static string konekcija = "User ID=daca;Password=spider2204;Data Source=ELO15E1-PC\\SQLTOUCH2R2;Initial Catalog=AmsterdamSplavNovi";
        public static string konekcija = "User ID=daca;Password=spider2204;Data Source=DESKTOP-N6QEGP1\\DACASQL;Initial Catalog=AmsterdamSplavNovi;TrustServerCertificate=True";

        private Form1 _frm1;
        public static System.Windows.Forms.Timer Timer1 = new System.Windows.Forms.Timer();
        public static DataTable tblStolovi = null;
        public static DataTable tblKonobari;
        public static DataTable tblOtvoreniStolovi = new DataTable();
        private DataTable tblNajnovijeStavke = new DataTable();
        public static string KonobarIme = string.Empty;
        public static int KonobarId = 0;
        public static int IdImee = 0;
        public static string Korisnik = string.Empty;
        public static bool daliAdmin = false;
        public static string BrojStola = string.Empty;
        public static string Sto1 = string.Empty;
        public static string Sto2 = string.Empty;
        private string myValue = string.Empty;
        private SqlConnection connectionInsert = null;
        private SqlCommand commandInsert = null;
        private Dictionary<string, Button> dctButton;

        public Window2()
        {
            InitializeComponent();
            try
            {
                if (Environment.MachineName == "DACA-PC")
                {
                    konekcija = konekcijaPom;
                }
                else if (Environment.MachineName == "WIN-PC")
                {
                    konekcija = konekcijaPom1;
                }
                else if (Environment.MachineName == "DACHA-LAPTOP")
                {
                    konekcija = konekcijaPom2;
                }
                else if (Environment.MachineName == "LENOVO-PC")
                {
                    konekcija = konekcijaPom3;
                }
                else if (Environment.MachineName == "DESKTOP-HP")
                {
                    konekcija = konekcijaPom4;
                }
            }
            catch (Exception)
            {
            }

            string tekstKonobari = "SELECT dbo.Konobari.IdKonobar, dbo.Konobari.Ime, dbo.KonobariKodoviKartica.Kod ";
            tekstKonobari += "FROM dbo.Konobari INNER JOIN dbo.KonobariKodoviKartica ON ";
            tekstKonobari += "dbo.Konobari.BrojKartice = dbo.KonobariKodoviKartica.IdKod WHERE aktivan = 'TRUE'";
            tblKonobari = DatabaseHelper.ReaderTabela(konekcija, tekstKonobari);

            dctButton = new Dictionary<string, Button>();
            ReloadTablesFromDatabase();

            Timer1.Tick += Tikovanje;
            Timer1.Interval = 5000;
            DlgKartica dlgfrm = new DlgKartica();
            if (dlgfrm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
            {
                this.Close();
            }

            _frm1 = new Form1(this);
            tblOtvoreniStolovi = DatabaseHelper.ReaderTabela(konekcija, "SELECT * FROM KonobariStolovi");
            BojenjeStolova();
            Timer1.Start();

            // Registracija Click event-a za kontrolna dugmad
            exp.Click += exp_Click;
            staf.Click += staf_Click;
            izlaz.Click += izlaz_Click;
            ZamenaStolova.Click += ZamenaStolova_Click;
            ZamenaKonobara.Click += ZamenaKonobara_Click;
            RasporedStolova.Click += RasporedStolova_Click;
        }

        public void ReloadTablesFromDatabase()
        {
            canvasTables.Children.Clear();
            dctButton.Clear();

            tblStolovi = DatabaseHelper.ReaderTabela(konekcija,
                "SELECT BrojStola, PosX, PosY, TipStola FROM dbo.Stolovi");

            foreach (DataRow row in tblStolovi.Rows)
            {
                string name = row["BrojStola"].ToString();
                string type = row["TipStola"].ToString();
                double posX = Convert.ToDouble(row["PosX"]);
                double posY = Convert.ToDouble(row["PosY"]);

                Button btn = new Button();
                btn.Content = name;
                btn.Tag = name;
                btn.Background = Brushes.White;
                btn.FontSize = 18;
                btn.FontWeight = FontWeights.Bold;
                btn.Click += exp_Click;

                if (type == "round")
                {
                    btn.Width = 60;
                    btn.Height = 60;
                    btn.Style = (Style)FindResource("Okrugli");
                }
                else
                {
                    btn.Width = 45;
                    btn.Height = 45;
                }

                Canvas.SetLeft(btn, posX);
                Canvas.SetTop(btn, posY);
                canvasTables.Children.Add(btn);
                dctButton[name] = btn;
            }
        }

        private void RasporedStolova_Click(object sender, RoutedEventArgs e)
        {
            Timer1.Stop();
            RasporedStolova rasporedWin = new RasporedStolova();
            rasporedWin.ShowDialog();
            // Po zatvaranju prozora, ponovo učitaj stolove iz baze
            ReloadTablesFromDatabase();
            tblOtvoreniStolovi = DatabaseHelper.ReaderTabela(konekcija, "SELECT * FROM KonobariStolovi");
            BojenjeStolova();
            Timer1.Start();
        }

        private void staf_Click(object sender, RoutedEventArgs e)
        {
            Timer1.Stop();
            DlgStaff frfrm = new DlgStaff();
            frfrm.ShowDialog();
            Timer1.Start();
        }

        private void exp_Click(object sender, RoutedEventArgs e)
        {
            Timer1.Stop();
            Button TT = (Button)sender;
            BrojStola = TT.Tag?.ToString() ?? TT.Content.ToString();
            try
            {
                IdImee = Convert.ToInt32(tblOtvoreniStolovi.Select("BrojStola = '" + BrojStola + "'")[0]["IdIme"]);
                Korisnik = tblOtvoreniStolovi.Select("BrojStola = '" + BrojStola + "'")[0]["Korisnik"].ToString();
            }
            catch (Exception)
            {
                IdImee = 0;
                Korisnik = string.Empty;
            }
            if (!daliAdmin)
            {
                if (tblOtvoreniStolovi.Select("BrojStola = '" + BrojStola + "'").Length == 0)
                {
                    DlgOkno frrm = new DlgOkno("Da li želite da otvorite sto " + BrojStola + " ?");
                    if (frrm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        TT.Background = Brushes.Red;
                        InsertStola();
                    }
                    else
                    {
                        Timer1.Start();
                        return;
                    }
                }
                else if (Convert.ToInt32(tblOtvoreniStolovi.Select("BrojStola = '" + BrojStola + "'")[0]["IdKonobar"]) != KonobarId)
                {
                    string konobar = tblOtvoreniStolovi.Select("BrojStola = '" + BrojStola + "'")[0]["Ime"].ToString();
                    System.Windows.Forms.MessageBox.Show(konobar);
                    Timer1.Start();
                    return;
                }
            }
            else
            {
                if (tblOtvoreniStolovi.Select("BrojStola = '" + BrojStola + "'").Length == 0)
                {
                    return;
                }
                else
                {
                    KonobarId = Convert.ToInt32(tblOtvoreniStolovi.Select("BrojStola = '" + BrojStola + "'")[0]["IdKonobar"]);
                    KonobarIme = tblOtvoreniStolovi.Select("BrojStola = '" + BrojStola + "'")[0]["Ime"].ToString();
                }
            }
            this.Hide();
            _frm1.Show();
            Form1.daliPaint = true;
        }

        private void BojenjeStolova()
        {
            foreach (Button dugme in dctButton.Values)
            {
                dugme.Background = Brushes.White;
            }
            if (daliAdmin)
            {
                tblNajnovijeStavke = DatabaseHelper.ReaderTabela(konekcija, "SELECT BrojStola, proteklo FROM NajnovijeStavke");
                foreach (DataRow red in tblNajnovijeStavke.Rows)
                {
                    string brojStola = red["BrojStola"].ToString();
                    if (dctButton.ContainsKey(brojStola))
                    {
                        if (Convert.ToInt32(red["proteklo"]) < 2)
                        {
                            dctButton[brojStola].Background = Brushes.Red;
                        }
                        else
                        {
                            dctButton[brojStola].Background = Brushes.Orange;
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow red in tblOtvoreniStolovi.Rows)
                {
                    string brojStola = red["BrojStola"].ToString();
                    if (dctButton.ContainsKey(brojStola))
                    {
                        if (Convert.ToInt32(red["IdKonobar"]) == KonobarId)
                        {
                            dctButton[brojStola].Background = Brushes.GreenYellow;
                        }
                        else
                        {
                            dctButton[brojStola].Background = Brushes.Orange;
                        }
                    }
                }
            }
        }

        private string GetSQLInsert()
        {
            return "INSERT INTO dbo.KonobariStolovi (IDKonobar, BrojStola, Ime) " +
                   "VALUES (@IdKonobar, @BrojStola, @Ime)";
        }

        private void InsertStola()
        {
            if (connectionInsert == null)
            {
                connectionInsert = new SqlConnection(konekcija);
            }
            if (commandInsert == null)
            {
                commandInsert = new SqlCommand(GetSQLInsert(), connectionInsert);
                SqlParameter param = new SqlParameter("@BrojStola", SqlDbType.NVarChar);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                commandInsert.Parameters.Add(param);
                param = new SqlParameter("@Ime", SqlDbType.NVarChar);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.String;
                commandInsert.Parameters.Add(param);
                param = new SqlParameter("@IdKonobar", SqlDbType.Int);
                param.Direction = ParameterDirection.Input;
                param.DbType = DbType.Int32;
                commandInsert.Parameters.Add(param);
            }
            commandInsert.Parameters["@BrojStola"].Value = BrojStola;
            commandInsert.Parameters["@ime"].Value = KonobarIme;
            commandInsert.Parameters["@IdKonobar"].Value = KonobarId;
            connectionInsert.Open();
            int rowsAffected = commandInsert.ExecuteNonQuery();
            connectionInsert.Close();
            tblOtvoreniStolovi = DatabaseHelper.ReaderTabela(konekcija, "SELECT * FROM KonobariStolovi");
        }

        private void Tikovanje(object sender, EventArgs e)
        {
            this.Hide();
            Timer1.Stop();
            DlgKartica dlgfrm = new DlgKartica();
            if (dlgfrm.ShowDialog() == System.Windows.Forms.DialogResult.Abort)
            {
                this.Close();
            }
            this.Show();

            tblOtvoreniStolovi = DatabaseHelper.ReaderTabela(konekcija, "SELECT * FROM KonobariStolovi");
            BojenjeStolova();
            if (!daliAdmin)
            {
                Timer1.Interval = 5000;
                Timer1.Start();
            }
        }

        private void izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ZamenaStolova_Click(object sender, RoutedEventArgs e)
        {
            if (!daliAdmin)
            {
                DlgZamenaStolova frmZamena = new DlgZamenaStolova();
                if (frmZamena.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (tblOtvoreniStolovi.Select("BrojStola = '" + Sto2 + "'").Length != 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Sto " + Sto2 + " je već otvoren");
                        Timer1.Start();
                        return;
                    }
                    else if (tblOtvoreniStolovi.Select("BrojStola = '" + Sto1 + "'").Length == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Sto " + Sto1 + " nije otvoren");
                        Timer1.Start();
                        return;
                    }
                    DatabaseHelper.ProcZamenaStolova(konekcija, Sto1, Sto2);
                    Timer1.Interval = 500;
                    Timer1.Start();
                }
            }
            tblOtvoreniStolovi = DatabaseHelper.ReaderTabela(konekcija, "SELECT * FROM KonobariStolovi");
            BojenjeStolova();
        }

        private void ZamenaKonobara_Click(object sender, RoutedEventArgs e)
        {
            DlgZamenaKonobara frmZamena = new DlgZamenaKonobara();
            if (frmZamena.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Timer1.Interval = 500;
                Timer1.Start();
            }
        }
    }
}
