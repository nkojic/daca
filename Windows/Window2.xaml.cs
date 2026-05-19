using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Data.Sqlite;

namespace WpfAmsterdam
{
    public partial class Window2 : Window
    {
        public static string konekcija;

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
        public static bool KoristiKartice = true;
        public static string BrojStola = string.Empty;
        public static string Sto1 = string.Empty;
        public static string Sto2 = string.Empty;
        private string myValue = string.Empty;
            private Dictionary<string, Button> dctButton;

        public Window2()
        {
            InitializeComponent();

            // Inicijalizacija SQLite baze
            DatabaseHelper.InitializeDatabase();
            konekcija = DatabaseHelper.GetConnectionString();

            string tekstKonobari = "SELECT K.IdKonobar, K.Ime, KK.Kod " +
                "FROM Konobari K INNER JOIN KonobariKodoviKartica KK ON " +
                "K.BrojKartice = KK.IdKod WHERE K.aktivan = 1";
            tblKonobari = DatabaseHelper.ReaderTabela(konekcija, tekstKonobari);

            // Učitaj konfiguraciju
            LoadKonfiguracija();

            dctButton = new Dictionary<string, Button>();
            ReloadTablesFromDatabase();

            Timer1.Tick += Tikovanje;
            Timer1.Interval = 5000;
            DlgLogin dlgLogin = new DlgLogin();
            dlgLogin.ShowDialog();
            if (dlgLogin.Izlaz || !dlgLogin.LoginUspeo)
            {
                this.Close();
                return;
            }

            ApplyTheme();
            _frm1 = new Form1(this);
            tblOtvoreniStolovi = DatabaseHelper.ReaderTabela(konekcija, "SELECT * FROM KonobariStolovi");
            BojenjeStolova();

            // Pokreni timer samo ako se koriste kartice
            if (KoristiKartice)
            {
                Timer1.Start();
            }

            // Registracija Click event-a za kontrolna dugmad
            exp.Click += exp_Click;
            staf.Click += staf_Click;
            izlaz.Click += izlaz_Click;
            ZamenaStolova.Click += ZamenaStolova_Click;
            ZamenaKonobara.Click += ZamenaKonobara_Click;
            RasporedStolova.Click += RasporedStolova_Click;
            btnKonfiguracija.Click += Konfiguracija_Click;

            // Admin dugme vidljivo samo za admina
            if (daliAdmin)
            {
                btnKonfiguracija.Visibility = Visibility.Visible;
            }
        }

        private void LoadKonfiguracija()
        {
            try
            {
                DataTable dt = DatabaseHelper.ReaderTabela(konekcija,
                    "SELECT Kljuc, Vrednost FROM Konfiguracija");
                foreach (DataRow row in dt.Rows)
                {
                    string kljuc = row["Kljuc"].ToString();
                    string vrednost = row["Vrednost"].ToString();
                    if (kljuc == "KoristiKartice")
                        KoristiKartice = vrednost == "1";
                    else if (kljuc == "Tema")
                        ThemeManager.CurrentTheme = vrednost;
                }
            }
            catch
            {
                KoristiKartice = true;
            }
        }

        private void Konfiguracija_Click(object sender, RoutedEventArgs e)
        {
            Timer1.Stop();
            DlgKonfiguracija dlg = new DlgKonfiguracija();
            dlg.ShowDialog();

            // Primeni temu odmah
            ApplyTheme();
            ReloadTablesFromDatabase();
            tblOtvoreniStolovi = DatabaseHelper.ReaderTabela(konekcija, "SELECT * FROM KonobariStolovi");
            BojenjeStolova();

            if (!KoristiKartice && !daliAdmin)
            {
                // Ako su kartice isključene, ne pokreći timer
            }
            else if (!daliAdmin)
            {
                Timer1.Start();
            }
        }

        public void ApplyTheme()
        {
            // Window pozadina
            this.Background = new SolidColorBrush(ThemeManager.WindowBackground);

            // Container (glavni Border)
            if (this.Content is System.Windows.Controls.Border mainBorder)
            {
                mainBorder.Background = new SolidColorBrush(ThemeManager.ContainerBackground);

                if (mainBorder.Child is Grid grid)
                {
                    // Header (Row 0)
                    if (grid.Children[0] is System.Windows.Controls.Border headerBorder)
                    {
                        headerBorder.Background = ThemeManager.MakeGradient(
                            ThemeManager.HeaderGradient1, ThemeManager.HeaderGradient2);
                        headerBorder.BorderBrush = new SolidColorBrush(ThemeManager.HeaderBorder);

                        // Dugmad u headeru
                        if (headerBorder.Child is StackPanel headerStack)
                        {
                            // Kraj
                            izlaz.Background = ThemeManager.MakeGradient(
                                ThemeManager.BtnKraj1, ThemeManager.BtnKraj2);
                            // Stolovi
                            ZamenaStolova.Background = ThemeManager.MakeGradient(
                                ThemeManager.BtnStolovi1, ThemeManager.BtnStolovi2);
                            // Konobari
                            ZamenaKonobara.Background = ThemeManager.MakeGradient(
                                ThemeManager.BtnKonobari1, ThemeManager.BtnKonobari2);
                            // Raspored
                            RasporedStolova.Background = ThemeManager.MakeGradient(
                                ThemeManager.BtnRaspored1, ThemeManager.BtnRaspored2);
                            // Secondary dugmad
                            exp.Background = ThemeManager.MakeGradient(
                                ThemeManager.BtnSecondary1, ThemeManager.BtnSecondary2);
                            exp.Foreground = new SolidColorBrush(ThemeManager.BtnSecondaryFg);
                            staf.Background = ThemeManager.MakeGradient(
                                ThemeManager.BtnSecondary1, ThemeManager.BtnSecondary2);
                            staf.Foreground = new SolidColorBrush(ThemeManager.BtnSecondaryFg);
                            // Admin
                            btnKonfiguracija.Background = ThemeManager.MakeGradient(
                                ThemeManager.BtnAdmin1, ThemeManager.BtnAdmin2);
                        }
                    }

                    // Waiter info strip (Row 1)
                    if (grid.Children[1] is System.Windows.Controls.Border waiterBorder)
                    {
                        waiterBorder.Background = new SolidColorBrush(ThemeManager.FooterBackground);
                        waiterBorder.BorderBrush = new SolidColorBrush(ThemeManager.HeaderBorder);
                    }
                    txtKonobarIme.Foreground = new SolidColorBrush(ThemeManager.WaiterAccent);
                    txtDatum.Foreground = new SolidColorBrush(ThemeManager.TextMuted);

                    // Canvas border (Row 2)
                    if (grid.Children[2] is System.Windows.Controls.Border canvasBorder)
                    {
                        canvasBorder.BorderBrush = new SolidColorBrush(ThemeManager.HeaderBorder);
                        // Grid pattern pozadina
                        DrawingBrush gridBrush = new DrawingBrush();
                        gridBrush.TileMode = TileMode.Tile;
                        gridBrush.Viewport = new Rect(0, 0, 30, 30);
                        gridBrush.ViewportUnits = BrushMappingMode.Absolute;
                        DrawingGroup dg = new DrawingGroup();
                        dg.Children.Add(new GeometryDrawing(
                            new SolidColorBrush(ThemeManager.CanvasBackground),
                            null,
                            new RectangleGeometry(new Rect(0, 0, 30, 30))));
                        Pen gridPen = new Pen(new SolidColorBrush(ThemeManager.GridLine), 0.5);
                        GeometryGroup gg = new GeometryGroup();
                        gg.Children.Add(new LineGeometry(new System.Windows.Point(30, 0), new System.Windows.Point(30, 30)));
                        gg.Children.Add(new LineGeometry(new System.Windows.Point(0, 30), new System.Windows.Point(30, 30)));
                        dg.Children.Add(new GeometryDrawing(null, gridPen, gg));
                        gridBrush.Drawing = dg;
                        canvasBorder.Background = gridBrush;
                    }

                    // Legenda (Row 3)
                    if (grid.Children[3] is System.Windows.Controls.Border legendBorder)
                    {
                        legendBorder.Background = new SolidColorBrush(ThemeManager.FooterBackground);
                        legendBorder.BorderBrush = new SolidColorBrush(ThemeManager.HeaderBorder);
                    }
                }
            }

            // Ažuriraj status brusheve
            UpdateStatusBrushes();
        }

        private void UpdateStatusBrushes()
        {
            BrushEmpty = new SolidColorBrush(ThemeManager.StatusEmpty);
            BrushMine = new SolidColorBrush(ThemeManager.StatusMine);
            BrushOther = new SolidColorBrush(ThemeManager.StatusOther);
            BrushNewOrder = new SolidColorBrush(ThemeManager.StatusNewOrder);
            BrushNewOrderRecent = new SolidColorBrush(ThemeManager.StatusNewOrderRecent);
        }

        // Boje za status stolova
        private static SolidColorBrush BrushEmpty = new SolidColorBrush(Color.FromRgb(240, 242, 245));
        private static SolidColorBrush BrushMine = new SolidColorBrush(Color.FromRgb(184, 245, 216));
        private static SolidColorBrush BrushOther = new SolidColorBrush(Color.FromRgb(255, 224, 178));
        private static SolidColorBrush BrushNewOrder = new SolidColorBrush(Color.FromRgb(255, 184, 184));
        private static SolidColorBrush BrushNewOrderRecent = new SolidColorBrush(Color.FromRgb(255, 118, 117));

        public void ReloadTablesFromDatabase()
        {
            canvasTables.Children.Clear();
            dctButton.Clear();

            // Učitaj pasivne elemente (zone, labele, zidove) - pre stolova da budu ispod
            LoadPassiveElements();

            tblStolovi = DatabaseHelper.ReaderTabela(konekcija,
                "SELECT BrojStola, PosX, PosY, TipStola FROM Stolovi");

            foreach (DataRow row in tblStolovi.Rows)
            {
                string name = row["BrojStola"].ToString();
                string type = row["TipStola"].ToString();
                double posX = Convert.ToDouble(row["PosX"]);
                double posY = Convert.ToDouble(row["PosY"]);

                Button btn = new Button();
                btn.Content = name;
                btn.Tag = name;
                btn.Background = BrushEmpty;
                btn.Foreground = new SolidColorBrush(ThemeManager.StatusEmptyFg);
                btn.Click += exp_Click;

                if (type == "round")
                {
                    btn.Style = (Style)FindResource("StoKrugW2");
                }
                else
                {
                    btn.Style = (Style)FindResource("StoKvadratW2");
                }

                Canvas.SetLeft(btn, posX);
                Canvas.SetTop(btn, posY);
                canvasTables.Children.Add(btn);
                dctButton[name] = btn;
            }

            // Ažuriraj waiter strip
            txtKonobarIme.Text = KonobarIme;
            txtDatum.Text = DateTime.Now.ToString("dd. MMMM yyyy.  |  HH:mm", new CultureInfo("sr-Latn-RS"));
        }

        private void LoadPassiveElements()
        {
            try
            {
                // Zone
                DataTable dtZone = DatabaseHelper.ReaderTabela(konekcija,
                    "SELECT Naziv, PosX, PosY, Sirina, Visina, Boja FROM PasivniElementi WHERE Tip = 'zona'");
                foreach (DataRow row in dtZone.Rows)
                {
                    string boja = row["Boja"].ToString();
                    string borderColor = "#B2BEC3";
                    // Mapiranje boja zona na border boje
                    string[] bgPalette = { "#E8F4FD", "#E8F8E8", "#FFF3E0", "#FCE4EC", "#F3E5F5", "#E0F2F1", "#FFF9C4", "#E8EAF6" };
                    string[] brPalette = { "#90CAF9", "#A5D6A7", "#FFB74D", "#F48FB1", "#CE93D8", "#80CBC4", "#FFF176", "#9FA8DA" };
                    int idx = Array.IndexOf(bgPalette, boja);
                    if (idx >= 0) borderColor = brPalette[idx];

                    System.Windows.Controls.Border border = new System.Windows.Controls.Border
                    {
                        Width = Convert.ToDouble(row["Sirina"]),
                        Height = Convert.ToDouble(row["Visina"]),
                        Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(boja)),
                        BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(borderColor)),
                        BorderThickness = new Thickness(2),
                        CornerRadius = new CornerRadius(8),
                        Opacity = 0.7,
                        IsHitTestVisible = false
                    };
                    border.Child = new System.Windows.Controls.TextBlock
                    {
                        Text = row["Naziv"].ToString(),
                        FontSize = 13,
                        FontWeight = FontWeights.SemiBold,
                        Foreground = new SolidColorBrush(Color.FromRgb(99, 110, 114)),
                        Margin = new Thickness(8, 6, 0, 0)
                    };
                    Canvas.SetLeft(border, Convert.ToDouble(row["PosX"]));
                    Canvas.SetTop(border, Convert.ToDouble(row["PosY"]));
                    System.Windows.Controls.Panel.SetZIndex(border, -1);
                    canvasTables.Children.Add(border);
                }

                // Labele
                DataTable dtLabele = DatabaseHelper.ReaderTabela(konekcija,
                    "SELECT Naziv, PosX, PosY FROM PasivniElementi WHERE Tip = 'labela'");
                foreach (DataRow row in dtLabele.Rows)
                {
                    System.Windows.Controls.TextBlock text = new System.Windows.Controls.TextBlock
                    {
                        Text = row["Naziv"].ToString(),
                        FontSize = 12,
                        FontWeight = FontWeights.SemiBold,
                        Foreground = new SolidColorBrush(Color.FromRgb(99, 110, 114)),
                        Background = new SolidColorBrush(Color.FromArgb(200, 255, 255, 255)),
                        Padding = new Thickness(6, 3, 6, 3),
                        IsHitTestVisible = false
                    };
                    Canvas.SetLeft(text, Convert.ToDouble(row["PosX"]));
                    Canvas.SetTop(text, Convert.ToDouble(row["PosY"]));
                    canvasTables.Children.Add(text);
                }

                // Zidovi
                DataTable dtZidovi = DatabaseHelper.ReaderTabela(konekcija,
                    "SELECT PosX, PosY, Sirina, Visina FROM PasivniElementi WHERE Tip = 'zid'");
                foreach (DataRow row in dtZidovi.Rows)
                {
                    double duzina = Convert.ToDouble(row["Sirina"]);
                    bool vertikalan = Convert.ToDouble(row["Visina"]) == 1;
                    System.Windows.Shapes.Line line = new System.Windows.Shapes.Line
                    {
                        X1 = 0, Y1 = 0,
                        X2 = vertikalan ? 0 : duzina,
                        Y2 = vertikalan ? duzina : 0,
                        Stroke = new SolidColorBrush(Color.FromRgb(99, 110, 114)),
                        StrokeThickness = 4,
                        StrokeStartLineCap = System.Windows.Media.PenLineCap.Round,
                        StrokeEndLineCap = System.Windows.Media.PenLineCap.Round,
                        IsHitTestVisible = false
                    };
                    Canvas.SetLeft(line, Convert.ToDouble(row["PosX"]));
                    Canvas.SetTop(line, Convert.ToDouble(row["PosY"]));
                    canvasTables.Children.Add(line);
                }
            }
            catch
            {
                // Tabela možda još ne postoji
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
            if (KoristiKartice) Timer1.Start();
        }

        private void staf_Click(object sender, RoutedEventArgs e)
        {
            Timer1.Stop();
            DlgStaff frfrm = new DlgStaff();
            frfrm.ShowDialog();
            if (KoristiKartice) Timer1.Start();
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
                        if (KoristiKartice) Timer1.Start();
                        return;
                    }
                }
                else if (Convert.ToInt32(tblOtvoreniStolovi.Select("BrojStola = '" + BrojStola + "'")[0]["IdKonobar"]) != KonobarId)
                {
                    string konobar = tblOtvoreniStolovi.Select("BrojStola = '" + BrojStola + "'")[0]["Ime"].ToString();
                    System.Windows.Forms.MessageBox.Show(konobar);
                    if (KoristiKartice) Timer1.Start();
                    return;
                }
            }
            else
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
                        return;
                    }
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
            SolidColorBrush fgEmpty = new SolidColorBrush(ThemeManager.StatusEmptyFg);
            SolidColorBrush fgMine = new SolidColorBrush(ThemeManager.StatusMineFg);
            SolidColorBrush fgOther = new SolidColorBrush(ThemeManager.StatusOtherFg);
            SolidColorBrush fgNew = new SolidColorBrush(ThemeManager.StatusNewOrderFg);

            foreach (Button dugme in dctButton.Values)
            {
                dugme.Background = BrushEmpty;
                dugme.Foreground = fgEmpty;
            }
            if (daliAdmin)
            {
                tblNajnovijeStavke = DatabaseHelper.ViewNajnovijeStavke(konekcija);
                foreach (DataRow red in tblNajnovijeStavke.Rows)
                {
                    string brojStola = red["BrojStola"].ToString();
                    if (dctButton.ContainsKey(brojStola))
                    {
                        if (Convert.ToInt32(red["proteklo"]) < 2)
                        {
                            dctButton[brojStola].Background = BrushNewOrderRecent;
                            dctButton[brojStola].Foreground = Brushes.White;
                        }
                        else
                        {
                            dctButton[brojStola].Background = BrushNewOrder;
                            dctButton[brojStola].Foreground = fgNew;
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
                            dctButton[brojStola].Background = BrushMine;
                            dctButton[brojStola].Foreground = fgMine;
                        }
                        else
                        {
                            dctButton[brojStola].Background = BrushOther;
                            dctButton[brojStola].Foreground = fgOther;
                        }
                    }
                }
            }

            // Ažuriraj waiter strip
            txtKonobarIme.Text = KonobarIme;
            txtDatum.Text = DateTime.Now.ToString("dd. MMMM yyyy.  |  HH:mm", new CultureInfo("sr-Latn-RS"));
        }

        private void InsertStola()
        {
            using (SqliteConnection con = new SqliteConnection(konekcija))
            {
                con.Open();
                using (SqliteCommand cmd = new SqliteCommand(
                    "INSERT INTO KonobariStolovi (IDKonobar, BrojStola, Ime) VALUES (@IdKonobar, @BrojStola, @Ime)", con))
                {
                    cmd.Parameters.AddWithValue("@BrojStola", BrojStola);
                    cmd.Parameters.AddWithValue("@Ime", KonobarIme);
                    cmd.Parameters.AddWithValue("@IdKonobar", KonobarId);
                    cmd.ExecuteNonQuery();
                }
            }
            tblOtvoreniStolovi = DatabaseHelper.ReaderTabela(konekcija, "SELECT * FROM KonobariStolovi");
        }

        private void Tikovanje(object sender, EventArgs e)
        {
            this.Hide();
            Timer1.Stop();
            DlgLogin dlgLogin = new DlgLogin();
            dlgLogin.ShowDialog();
            if (dlgLogin.Izlaz)
            {
                this.Close();
                return;
            }
            this.Show();

            tblOtvoreniStolovi = DatabaseHelper.ReaderTabela(konekcija, "SELECT * FROM KonobariStolovi");
            BojenjeStolova();
            if (!daliAdmin && KoristiKartice)
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
                        if (KoristiKartice) Timer1.Start();
                        return;
                    }
                    else if (tblOtvoreniStolovi.Select("BrojStola = '" + Sto1 + "'").Length == 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Sto " + Sto1 + " nije otvoren");
                        if (KoristiKartice) Timer1.Start();
                        return;
                    }
                    DatabaseHelper.ProcZamenaStolova(konekcija, Sto1, Sto2);
                    Timer1.Interval = 500;
                    if (KoristiKartice) Timer1.Start();
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
                if (KoristiKartice) Timer1.Start();
            }
        }
    }
}
