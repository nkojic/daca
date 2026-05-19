using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;

namespace WpfAmsterdam
{
    public partial class RasporedStolova : Window
    {
        private class TableItem
        {
            public string BrojStola { get; set; }
            public double PosX { get; set; }
            public double PosY { get; set; }
            public string TipStola { get; set; }
            public Button UiButton { get; set; }
        }

        private class ZoneItem
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public double PosX { get; set; }
            public double PosY { get; set; }
            public double Sirina { get; set; }
            public double Visina { get; set; }
            public string Boja { get; set; }
            public Border UiBorder { get; set; }
            public TextBlock UiLabel { get; set; }
        }

        private class LabelItem
        {
            public int Id { get; set; }
            public string Naziv { get; set; }
            public double PosX { get; set; }
            public double PosY { get; set; }
            public TextBlock UiText { get; set; }
        }

        private string konekcija = Window2.konekcija;
        private List<TableItem> tableItems = new List<TableItem>();
        private Button draggedButton = null;
        private Point dragOffset;
        private bool deleteMode = false;
        private int maxId = 0;

        // Alignment guides
        private const double SnapThreshold = 6;
        private List<Line> guideLines = new List<Line>();
        private static readonly SolidColorBrush GuideBrush = new SolidColorBrush(Color.FromRgb(0, 148, 255));

        // Zone
        private List<ZoneItem> zoneItems = new List<ZoneItem>();
        private ZoneItem draggedZone = null;
        private Point zoneDragOffset;
        private ZoneItem resizingZone = null;
        private string resizeDirection = null;
        private Point resizeStart;
        private double resizeOrigX, resizeOrigY, resizeOrigW, resizeOrigH;
        private int zoneColorIndex = 0;
        private static readonly string[] ZonePalette = new string[]
        {
            "#E8F4FD", "#E8F8E8", "#FFF3E0", "#FCE4EC",
            "#F3E5F5", "#E0F2F1", "#FFF9C4", "#E8EAF6"
        };
        private static readonly string[] ZoneBorderPalette = new string[]
        {
            "#90CAF9", "#A5D6A7", "#FFB74D", "#F48FB1",
            "#CE93D8", "#80CBC4", "#FFF176", "#9FA8DA"
        };

        // Labele
        private List<LabelItem> labelItems = new List<LabelItem>();
        private LabelItem draggedLabel = null;
        private Point labelDragOffset;

        // Zidovi
        private class WallItem
        {
            public int Id { get; set; }
            public double PosX { get; set; }
            public double PosY { get; set; }
            public double Duzina { get; set; }
            public bool Vertikalan { get; set; }
            public Line UiLine { get; set; }
        }
        private List<WallItem> wallItems = new List<WallItem>();
        private WallItem draggedWall = null;
        private Point wallDragOffset;

        public RasporedStolova()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Učitaj pasivne elemente (pre stolova, da budu ispod)
            LoadZonesFromDatabase();
            LoadLabelsFromDatabase();
            LoadWallsFromDatabase();

            DataTable dt = DatabaseHelper.ReaderTabela(konekcija,
                "SELECT BrojStola, PosX, PosY, TipStola FROM dbo.Stolovi");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string name = row["BrojStola"].ToString();
                    string type = row["TipStola"].ToString();
                    double posX = Convert.ToDouble(row["PosX"]);
                    double posY = Convert.ToDouble(row["PosY"]);

                    Button btn = CreateTableButton(name, type);
                    Canvas.SetLeft(btn, posX);
                    Canvas.SetTop(btn, posY);
                    canvasStolovi.Children.Add(btn);

                    tableItems.Add(new TableItem
                    {
                        BrojStola = name,
                        PosX = posX,
                        PosY = posY,
                        TipStola = type,
                        UiButton = btn
                    });

                    ParseMaxId(name);
                }

                UpdateCounts();
            }
        }

        private void LoadZonesFromDatabase()
        {
            try
            {
                DataTable dt = DatabaseHelper.ReaderTabela(konekcija,
                    "SELECT Id, Naziv, PosX, PosY, Sirina, Visina, Boja FROM dbo.PasivniElementi WHERE Tip = 'zona'");

                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    string naziv = row["Naziv"].ToString();
                    double posX = Convert.ToDouble(row["PosX"]);
                    double posY = Convert.ToDouble(row["PosY"]);
                    double sirina = Convert.ToDouble(row["Sirina"]);
                    double visina = Convert.ToDouble(row["Visina"]);
                    string boja = row["Boja"].ToString();

                    CreateZoneOnCanvas(id, naziv, posX, posY, sirina, visina, boja);
                }
            }
            catch
            {
                // Tabela možda još ne postoji - tiho ignorišemo
            }
        }

        private void LoadLabelsFromDatabase()
        {
            try
            {
                DataTable dt = DatabaseHelper.ReaderTabela(konekcija,
                    "SELECT Id, Naziv, PosX, PosY FROM dbo.PasivniElementi WHERE Tip = 'labela'");

                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    string naziv = row["Naziv"].ToString();
                    double posX = Convert.ToDouble(row["PosX"]);
                    double posY = Convert.ToDouble(row["PosY"]);

                    CreateLabelOnCanvas(id, naziv, posX, posY);
                }
            }
            catch
            {
                // Tabela možda još ne postoji
            }
        }

        private void LoadWallsFromDatabase()
        {
            try
            {
                DataTable dt = DatabaseHelper.ReaderTabela(konekcija,
                    "SELECT Id, PosX, PosY, Sirina, Visina FROM dbo.PasivniElementi WHERE Tip = 'zid'");

                foreach (DataRow row in dt.Rows)
                {
                    int id = Convert.ToInt32(row["Id"]);
                    double posX = Convert.ToDouble(row["PosX"]);
                    double posY = Convert.ToDouble(row["PosY"]);
                    double duzina = Convert.ToDouble(row["Sirina"]);
                    bool vertikalan = Convert.ToDouble(row["Visina"]) == 1;

                    CreateWallOnCanvas(id, posX, posY, duzina, vertikalan);
                }
            }
            catch
            {
                // Tabela možda još ne postoji
            }
        }

        private void ParseMaxId(string name)
        {
            if (name.Length > 1 && name.StartsWith("S"))
            {
                int num;
                if (int.TryParse(name.Substring(1), out num) && num > maxId)
                {
                    maxId = num;
                }
            }
        }

        private string GetNextName()
        {
            maxId++;
            return "S" + maxId;
        }

        private void UpdateCounts()
        {
            int sq = tableItems.Count(t => t.TipStola == "square");
            int rd = tableItems.Count(t => t.TipStola == "round");
            txtTotal.Text = tableItems.Count.ToString();
            txtSqCount.Text = sq.ToString();
            txtRdCount.Text = rd.ToString();
            txtSquareCount.Text = sq.ToString();
            txtRoundCount.Text = rd.ToString();
        }

        private Button CreateTableButton(string name, string type)
        {
            Button btn = new Button();
            btn.Content = name;
            btn.Tag = name;
            btn.Background = Brushes.White;

            if (type == "round")
            {
                btn.Style = (Style)FindResource("StoKrug");
            }
            else
            {
                btn.Style = (Style)FindResource("StoKvadrat");
            }

            btn.PreviewMouseLeftButtonDown += Table_MouseLeftButtonDown;
            btn.PreviewMouseMove += Table_MouseMove;
            btn.PreviewMouseLeftButtonUp += Table_MouseLeftButtonUp;
            btn.MouseDoubleClick += Table_DoubleClick;

            return btn;
        }

        // --- Inicijalno generisanje ---

        private void btnPrikazi_Click(object sender, RoutedEventArgs e)
        {
            if (deleteMode) ToggleDeleteMode();

            int squareCount, roundCount;
            if (!int.TryParse(txtSquareCount.Text, out squareCount) || squareCount < 0)
            {
                System.Windows.Forms.MessageBox.Show("Unesite ispravan broj kvadratnih stolova.");
                return;
            }
            if (!int.TryParse(txtRoundCount.Text, out roundCount) || roundCount < 0)
            {
                System.Windows.Forms.MessageBox.Show("Unesite ispravan broj kružnih stolova.");
                return;
            }

            // Očisti stolove ali sačuvaj zone
            foreach (TableItem t in tableItems)
                canvasStolovi.Children.Remove(t.UiButton);
            tableItems.Clear();
            maxId = 0;

            canvasStolovi.UpdateLayout();
            double canvasWidth = canvasStolovi.ActualWidth;
            if (canvasWidth < 100) canvasWidth = 1000;

            int maxCols = (int)((canvasWidth - 20) / 75);
            if (maxCols < 1) maxCols = 10;
            int col = 0;
            int row = 0;

            for (int i = 0; i < squareCount; i++)
            {
                string name = GetNextName();
                double x = 20 + col * 75;
                double y = 20 + row * 75;

                Button btn = CreateTableButton(name, "square");
                Canvas.SetLeft(btn, x);
                Canvas.SetTop(btn, y);
                canvasStolovi.Children.Add(btn);

                tableItems.Add(new TableItem
                {
                    BrojStola = name, PosX = x, PosY = y,
                    TipStola = "square", UiButton = btn
                });

                col++;
                if (col >= maxCols) { col = 0; row++; }
            }

            if (squareCount > 0) { col = 0; row++; }

            for (int i = 0; i < roundCount; i++)
            {
                string name = GetNextName();
                double x = 15 + col * 80;
                double y = 20 + row * 80;

                Button btn = CreateTableButton(name, "round");
                Canvas.SetLeft(btn, x);
                Canvas.SetTop(btn, y);
                canvasStolovi.Children.Add(btn);

                tableItems.Add(new TableItem
                {
                    BrojStola = name, PosX = x, PosY = y,
                    TipStola = "round", UiButton = btn
                });

                col++;
                if (col >= maxCols) { col = 0; row++; }
            }

            UpdateCounts();
        }

        // --- Dodavanje pojedinačnog stola ---

        private void btnDodajKvadrat_Click(object sender, RoutedEventArgs e)
        {
            if (deleteMode) ToggleDeleteMode();
            DodajSto("square");
        }

        private void btnDodajKrug_Click(object sender, RoutedEventArgs e)
        {
            if (deleteMode) ToggleDeleteMode();
            DodajSto("round");
        }

        private void DodajSto(string type)
        {
            string name = GetNextName();
            double x = 30;
            double y = 30;

            Button btn = CreateTableButton(name, type);
            Canvas.SetLeft(btn, x);
            Canvas.SetTop(btn, y);
            canvasStolovi.Children.Add(btn);

            tableItems.Add(new TableItem
            {
                BrojStola = name, PosX = x, PosY = y,
                TipStola = type, UiButton = btn
            });

            UpdateCounts();
        }

        // --- Režim brisanja ---

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            ToggleDeleteMode();
        }

        private void ToggleDeleteMode()
        {
            deleteMode = !deleteMode;

            if (deleteMode)
            {
                canvasBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 118, 117));
                canvasBorder.Background = new SolidColorBrush(Color.FromRgb(255, 245, 245));
                btnObrisi.Background = new SolidColorBrush(Color.FromRgb(183, 28, 28));
                txtMode.Text = "REŽIM BRISANJA — kliknite na element za brisanje";
                txtMode.Foreground = new SolidColorBrush(Color.FromRgb(214, 48, 49));
            }
            else
            {
                canvasBorder.BorderBrush = new SolidColorBrush(Color.FromRgb(238, 241, 245));
                canvasBorder.Background = null; // DrawingBrush iz XAML-a
                LinearGradientBrush deleteGrad = new LinearGradientBrush();
                deleteGrad.StartPoint = new Point(0, 0);
                deleteGrad.EndPoint = new Point(1, 1);
                deleteGrad.GradientStops.Add(new GradientStop(Color.FromRgb(255, 118, 117), 0));
                deleteGrad.GradientStops.Add(new GradientStop(Color.FromRgb(225, 112, 85), 1));
                btnObrisi.Background = deleteGrad;
                txtMode.Text = "";
                txtMode.Foreground = new SolidColorBrush(Color.FromRgb(85, 85, 85));
            }
        }

        private void ObrisiSto(Button btn)
        {
            TableItem item = tableItems.Find(t => t.UiButton == btn);
            if (item == null) return;

            System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show(
                "Da li ste sigurni da želite da obrišete sto " + item.BrojStola + "?",
                "Brisanje stola",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                canvasStolovi.Children.Remove(btn);
                tableItems.Remove(item);
                UpdateCounts();
            }
        }

        // --- Drag and Drop ---

        private void Table_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button btn = sender as Button;

            if (deleteMode)
            {
                ObrisiSto(btn);
                e.Handled = true;
                return;
            }

            draggedButton = btn;
            dragOffset = e.GetPosition(draggedButton);
            draggedButton.CaptureMouse();
            e.Handled = true;
        }

        private void Table_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedButton != null && e.LeftButton == MouseButtonState.Pressed)
            {
                Point position = e.GetPosition(canvasStolovi);
                double newX = position.X - dragOffset.X;
                double newY = position.Y - dragOffset.Y;

                newX = Math.Max(0, Math.Min(newX, canvasStolovi.ActualWidth - draggedButton.Width));
                newY = Math.Max(0, Math.Min(newY, canvasStolovi.ActualHeight - draggedButton.Height));

                // Alignment guides - snap i prikaz linija
                ClearGuideLines();

                double dragW = draggedButton.Width;
                double dragH = draggedButton.Height;
                double dragCX = newX + dragW / 2;
                double dragCY = newY + dragH / 2;
                double dragRight = newX + dragW;
                double dragBottom = newY + dragH;

                double canvasH = canvasStolovi.ActualHeight;
                double canvasW = canvasStolovi.ActualWidth;

                foreach (TableItem other in tableItems)
                {
                    if (other.UiButton == draggedButton) continue;

                    double oX = Canvas.GetLeft(other.UiButton);
                    double oY = Canvas.GetTop(other.UiButton);
                    double oW = other.UiButton.Width;
                    double oH = other.UiButton.Height;
                    double oCX = oX + oW / 2;
                    double oCY = oY + oH / 2;
                    double oRight = oX + oW;
                    double oBottom = oY + oH;

                    // Vertikalne linije (X poravnanje)
                    // Centar - centar
                    if (Math.Abs(dragCX - oCX) < SnapThreshold)
                    {
                        newX = oCX - dragW / 2;
                        AddGuideLine(oCX, 0, oCX, canvasH);
                    }
                    // Leva ivica - leva ivica
                    else if (Math.Abs(newX - oX) < SnapThreshold)
                    {
                        newX = oX;
                        AddGuideLine(oX, 0, oX, canvasH);
                    }
                    // Desna ivica - desna ivica
                    else if (Math.Abs(dragRight - oRight) < SnapThreshold)
                    {
                        newX = oRight - dragW;
                        AddGuideLine(oRight, 0, oRight, canvasH);
                    }

                    // Horizontalne linije (Y poravnanje)
                    // Centar - centar
                    if (Math.Abs(dragCY - oCY) < SnapThreshold)
                    {
                        newY = oCY - dragH / 2;
                        AddGuideLine(0, oCY, canvasW, oCY);
                    }
                    // Gornja ivica - gornja ivica
                    else if (Math.Abs(newY - oY) < SnapThreshold)
                    {
                        newY = oY;
                        AddGuideLine(0, oY, canvasW, oY);
                    }
                    // Donja ivica - donja ivica
                    else if (Math.Abs(dragBottom - oBottom) < SnapThreshold)
                    {
                        newY = oBottom - dragH;
                        AddGuideLine(0, oBottom, canvasW, oBottom);
                    }
                }

                Canvas.SetLeft(draggedButton, newX);
                Canvas.SetTop(draggedButton, newY);
            }
        }

        private void AddGuideLine(double x1, double y1, double x2, double y2)
        {
            Line line = new Line
            {
                X1 = x1, Y1 = y1, X2 = x2, Y2 = y2,
                Stroke = GuideBrush,
                StrokeThickness = 0.8,
                StrokeDashArray = new DoubleCollection { 4, 3 },
                IsHitTestVisible = false,
                Opacity = 0.7
            };
            canvasStolovi.Children.Add(line);
            guideLines.Add(line);
        }

        private void ClearGuideLines()
        {
            foreach (Line line in guideLines)
            {
                canvasStolovi.Children.Remove(line);
            }
            guideLines.Clear();
        }

        private void Table_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedButton != null)
            {
                ClearGuideLines();
                draggedButton.ReleaseMouseCapture();
                TableItem item = tableItems.Find(t => t.UiButton == draggedButton);
                if (item != null)
                {
                    item.PosX = Canvas.GetLeft(draggedButton);
                    item.PosY = Canvas.GetTop(draggedButton);
                }
                draggedButton = null;
            }
        }

        // --- Preimenovanje ---

        private void Table_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (deleteMode) return;

            Button btn = sender as Button;
            TableItem item = tableItems.Find(t => t.UiButton == btn);
            if (item == null) return;

            string newName = Microsoft.VisualBasic.Interaction.InputBox(
                "Unesite novo ime stola:", "Preimenovanje", item.BrojStola);

            if (string.IsNullOrWhiteSpace(newName) || newName == item.BrojStola)
                return;

            if (tableItems.Exists(t => t.BrojStola == newName))
            {
                System.Windows.Forms.MessageBox.Show(
                    "Sto sa imenom \"" + newName + "\" već postoji!",
                    "Greška", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            item.BrojStola = newName;
            btn.Content = newName;
            btn.Tag = newName;
        }

        // --- Zidovi ---

        private void btnDodajZid_Click(object sender, RoutedEventArgs e)
        {
            if (deleteMode) ToggleDeleteMode();
            CreateWallOnCanvas(0, 30, 30, 150, false);
        }

        private void CreateWallOnCanvas(int id, double posX, double posY, double duzina, bool vertikalan)
        {
            Line line = new Line
            {
                X1 = 0,
                Y1 = 0,
                X2 = vertikalan ? 0 : duzina,
                Y2 = vertikalan ? duzina : 0,
                Stroke = new SolidColorBrush(Color.FromRgb(99, 110, 114)),
                StrokeThickness = 4,
                StrokeStartLineCap = PenLineCap.Round,
                StrokeEndLineCap = PenLineCap.Round,
                Cursor = Cursors.SizeAll
            };

            Canvas.SetLeft(line, posX);
            Canvas.SetTop(line, posY);
            Panel.SetZIndex(line, 0);
            canvasStolovi.Children.Add(line);

            WallItem wall = new WallItem
            {
                Id = id,
                PosX = posX,
                PosY = posY,
                Duzina = duzina,
                Vertikalan = vertikalan,
                UiLine = line
            };
            wallItems.Add(wall);

            line.MouseLeftButtonDown += Wall_MouseLeftButtonDown;
            line.MouseMove += Wall_MouseMove;
            line.MouseLeftButtonUp += Wall_MouseLeftButtonUp;
        }

        private void Wall_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Line line = sender as Line;
            WallItem wall = wallItems.Find(w => w.UiLine == line);
            if (wall == null) return;

            if (deleteMode)
            {
                ObrisiZid(wall);
                e.Handled = true;
                return;
            }

            if (e.ClickCount == 2)
            {
                wall.Vertikalan = !wall.Vertikalan;
                line.X2 = wall.Vertikalan ? 0 : wall.Duzina;
                line.Y2 = wall.Vertikalan ? wall.Duzina : 0;
                e.Handled = true;
                return;
            }

            draggedWall = wall;
            wallDragOffset = e.GetPosition(canvasStolovi);
            wallDragOffset = new Point(
                wallDragOffset.X - Canvas.GetLeft(line),
                wallDragOffset.Y - Canvas.GetTop(line));
            line.CaptureMouse();
            e.Handled = true;
        }

        private void Wall_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedWall != null && e.LeftButton == MouseButtonState.Pressed)
            {
                Point position = e.GetPosition(canvasStolovi);
                double newX = position.X - wallDragOffset.X;
                double newY = position.Y - wallDragOffset.Y;

                newX = Math.Max(0, newX);
                newY = Math.Max(0, newY);

                Canvas.SetLeft(draggedWall.UiLine, newX);
                Canvas.SetTop(draggedWall.UiLine, newY);
                e.Handled = true;
            }
        }

        private void Wall_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedWall != null)
            {
                draggedWall.UiLine.ReleaseMouseCapture();
                draggedWall.PosX = Canvas.GetLeft(draggedWall.UiLine);
                draggedWall.PosY = Canvas.GetTop(draggedWall.UiLine);
                draggedWall = null;
            }
        }

        private void ObrisiZid(WallItem wall)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show(
                "Da li ste sigurni da želite da obrišete zid?",
                "Brisanje zida",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                canvasStolovi.Children.Remove(wall.UiLine);
                wallItems.Remove(wall);
            }
        }

        // --- Labele ---

        private void btnDodajLabelu_Click(object sender, RoutedEventArgs e)
        {
            if (deleteMode) ToggleDeleteMode();

            string tekst = Microsoft.VisualBasic.Interaction.InputBox(
                "Unesite tekst labele:", "Nova labela", "Ulaz");

            if (string.IsNullOrWhiteSpace(tekst)) return;

            CreateLabelOnCanvas(0, tekst, 30, 30);
        }

        private void CreateLabelOnCanvas(int id, string naziv, double posX, double posY)
        {
            TextBlock text = new TextBlock
            {
                Text = naziv,
                FontSize = 12,
                FontWeight = FontWeights.SemiBold,
                Foreground = new SolidColorBrush(Color.FromRgb(99, 110, 114)),
                Background = new SolidColorBrush(Color.FromArgb(200, 255, 255, 255)),
                Padding = new Thickness(6, 3, 6, 3),
                Cursor = Cursors.SizeAll
            };

            Canvas.SetLeft(text, posX);
            Canvas.SetTop(text, posY);
            Panel.SetZIndex(text, 0); // Između zona (-1) i stolova (default)
            canvasStolovi.Children.Add(text);

            LabelItem label = new LabelItem
            {
                Id = id,
                Naziv = naziv,
                PosX = posX,
                PosY = posY,
                UiText = text
            };
            labelItems.Add(label);

            text.MouseLeftButtonDown += Label_MouseLeftButtonDown;
            text.MouseMove += Label_MouseMove;
            text.MouseLeftButtonUp += Label_MouseLeftButtonUp;
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock text = sender as TextBlock;
            LabelItem label = labelItems.Find(l => l.UiText == text);
            if (label == null) return;

            if (deleteMode)
            {
                ObrisiLabelu(label);
                e.Handled = true;
                return;
            }

            if (e.ClickCount == 2)
            {
                string newText = Microsoft.VisualBasic.Interaction.InputBox(
                    "Unesite novi tekst:", "Izmena labele", label.Naziv);
                if (!string.IsNullOrWhiteSpace(newText) && newText != label.Naziv)
                {
                    label.Naziv = newText;
                    label.UiText.Text = newText;
                }
                e.Handled = true;
                return;
            }

            draggedLabel = label;
            labelDragOffset = e.GetPosition(text);
            text.CaptureMouse();
            e.Handled = true;
        }

        private void Label_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggedLabel != null && e.LeftButton == MouseButtonState.Pressed)
            {
                Point position = e.GetPosition(canvasStolovi);
                double newX = position.X - labelDragOffset.X;
                double newY = position.Y - labelDragOffset.Y;

                newX = Math.Max(0, newX);
                newY = Math.Max(0, newY);

                Canvas.SetLeft(draggedLabel.UiText, newX);
                Canvas.SetTop(draggedLabel.UiText, newY);
                e.Handled = true;
            }
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedLabel != null)
            {
                draggedLabel.UiText.ReleaseMouseCapture();
                draggedLabel.PosX = Canvas.GetLeft(draggedLabel.UiText);
                draggedLabel.PosY = Canvas.GetTop(draggedLabel.UiText);
                draggedLabel = null;
            }
        }

        private void ObrisiLabelu(LabelItem label)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show(
                "Da li ste sigurni da želite da obrišete labelu \"" + label.Naziv + "\"?",
                "Brisanje labele",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                canvasStolovi.Children.Remove(label.UiText);
                labelItems.Remove(label);
            }
        }

        // --- Zone ---

        private void btnDodajZonu_Click(object sender, RoutedEventArgs e)
        {
            if (deleteMode) ToggleDeleteMode();

            string naziv = Microsoft.VisualBasic.Interaction.InputBox(
                "Unesite naziv zone:", "Nova zona", "Sala 1");

            if (string.IsNullOrWhiteSpace(naziv)) return;

            string boja = ZonePalette[zoneColorIndex % ZonePalette.Length];
            zoneColorIndex++;

            CreateZoneOnCanvas(0, naziv, 20, 20, 200, 150, boja);
        }

        private void CreateZoneOnCanvas(int id, string naziv, double posX, double posY,
            double sirina, double visina, string boja)
        {
            int colorIdx = Array.IndexOf(ZonePalette, boja);
            if (colorIdx < 0) colorIdx = 0;
            string borderColor = ZoneBorderPalette[colorIdx % ZoneBorderPalette.Length];

            Border border = new Border
            {
                Width = sirina,
                Height = visina,
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(boja)),
                BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(borderColor)),
                BorderThickness = new Thickness(2),
                CornerRadius = new CornerRadius(8),
                Opacity = 0.7,
                Cursor = Cursors.SizeAll
            };

            TextBlock label = new TextBlock
            {
                Text = naziv,
                FontSize = 13,
                FontWeight = FontWeights.SemiBold,
                Foreground = new SolidColorBrush(Color.FromRgb(99, 110, 114)),
                Margin = new Thickness(8, 6, 0, 0),
                IsHitTestVisible = false
            };

            border.Child = label;

            Canvas.SetLeft(border, posX);
            Canvas.SetTop(border, posY);
            Panel.SetZIndex(border, -1); // Ispod stolova

            // Ubacujemo na početak canvas-a da bude ispod svega
            canvasStolovi.Children.Insert(0, border);

            ZoneItem zone = new ZoneItem
            {
                Id = id,
                Naziv = naziv,
                PosX = posX,
                PosY = posY,
                Sirina = sirina,
                Visina = visina,
                Boja = boja,
                UiBorder = border,
                UiLabel = label
            };
            zoneItems.Add(zone);

            // Eventi za zonu
            border.MouseLeftButtonDown += Zone_MouseLeftButtonDown;
            border.MouseMove += Zone_MouseMove;
            border.MouseLeftButtonUp += Zone_MouseLeftButtonUp;
        }

        private void Zone_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            ZoneItem zone = zoneItems.Find(z => z.UiBorder == border);
            if (zone == null) return;

            if (deleteMode)
            {
                ObrisiZonu(zone);
                e.Handled = true;
                return;
            }

            if (e.ClickCount == 2)
            {
                string newName = Microsoft.VisualBasic.Interaction.InputBox(
                    "Unesite novi naziv zone:", "Preimenovanje zone", zone.Naziv);
                if (!string.IsNullOrWhiteSpace(newName) && newName != zone.Naziv)
                {
                    zone.Naziv = newName;
                    zone.UiLabel.Text = newName;
                }
                e.Handled = true;
                return;
            }

            Point pos = e.GetPosition(border);
            double edgeMargin = 12;

            // Provera da li je klik na ivici (resize) ili unutra (drag)
            bool onRight = pos.X >= border.Width - edgeMargin;
            bool onBottom = pos.Y >= border.Height - edgeMargin;
            bool onLeft = pos.X <= edgeMargin;
            bool onTop = pos.Y <= edgeMargin;

            if (onRight && onBottom)
            {
                resizingZone = zone;
                resizeDirection = "BR";
            }
            else if (onRight)
            {
                resizingZone = zone;
                resizeDirection = "R";
            }
            else if (onBottom)
            {
                resizingZone = zone;
                resizeDirection = "B";
            }
            else
            {
                draggedZone = zone;
                zoneDragOffset = pos;
            }

            if (resizingZone != null)
            {
                resizeStart = e.GetPosition(canvasStolovi);
                resizeOrigX = zone.PosX;
                resizeOrigY = zone.PosY;
                resizeOrigW = zone.Sirina;
                resizeOrigH = zone.Visina;
            }

            border.CaptureMouse();
            e.Handled = true;
        }

        private void Zone_MouseMove(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if (border == null) return;

            if (e.LeftButton != MouseButtonState.Pressed)
            {
                // Promena kursora na ivicama
                ZoneItem zone = zoneItems.Find(z => z.UiBorder == border);
                if (zone == null || deleteMode) return;

                Point pos = e.GetPosition(border);
                double edgeMargin = 12;
                bool onRight = pos.X >= border.Width - edgeMargin;
                bool onBottom = pos.Y >= border.Height - edgeMargin;

                if (onRight && onBottom)
                    border.Cursor = Cursors.SizeNWSE;
                else if (onRight)
                    border.Cursor = Cursors.SizeWE;
                else if (onBottom)
                    border.Cursor = Cursors.SizeNS;
                else
                    border.Cursor = Cursors.SizeAll;

                return;
            }

            // Resize
            if (resizingZone != null)
            {
                Point current = e.GetPosition(canvasStolovi);
                double dx = current.X - resizeStart.X;
                double dy = current.Y - resizeStart.Y;

                if (resizeDirection == "R" || resizeDirection == "BR")
                {
                    double newW = Math.Max(80, resizeOrigW + dx);
                    resizingZone.UiBorder.Width = newW;
                    resizingZone.Sirina = newW;
                }
                if (resizeDirection == "B" || resizeDirection == "BR")
                {
                    double newH = Math.Max(50, resizeOrigH + dy);
                    resizingZone.UiBorder.Height = newH;
                    resizingZone.Visina = newH;
                }
                e.Handled = true;
                return;
            }

            // Drag
            if (draggedZone != null)
            {
                Point position = e.GetPosition(canvasStolovi);
                double newX = position.X - zoneDragOffset.X;
                double newY = position.Y - zoneDragOffset.Y;

                newX = Math.Max(0, Math.Min(newX, canvasStolovi.ActualWidth - draggedZone.Sirina));
                newY = Math.Max(0, Math.Min(newY, canvasStolovi.ActualHeight - draggedZone.Visina));

                Canvas.SetLeft(draggedZone.UiBorder, newX);
                Canvas.SetTop(draggedZone.UiBorder, newY);
                e.Handled = true;
            }
        }

        private void Zone_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Border border = sender as Border;
            if (border != null) border.ReleaseMouseCapture();

            if (draggedZone != null)
            {
                draggedZone.PosX = Canvas.GetLeft(draggedZone.UiBorder);
                draggedZone.PosY = Canvas.GetTop(draggedZone.UiBorder);
                draggedZone = null;
            }

            if (resizingZone != null)
            {
                resizingZone = null;
                resizeDirection = null;
            }
        }

        private void ObrisiZonu(ZoneItem zone)
        {
            System.Windows.Forms.DialogResult result = System.Windows.Forms.MessageBox.Show(
                "Da li ste sigurni da želite da obrišete zonu \"" + zone.Naziv + "\"?",
                "Brisanje zone",
                System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                canvasStolovi.Children.Remove(zone.UiBorder);
                zoneItems.Remove(zone);
            }
        }

        // --- Snimanje u bazu ---

        private void btnSnimi_Click(object sender, RoutedEventArgs e)
        {
            if (tableItems.Count == 0 && zoneItems.Count == 0 && labelItems.Count == 0 && wallItems.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Nema podataka za snimanje.");
                return;
            }

            if (deleteMode) ToggleDeleteMode();

            using (SqlConnection con = new SqlConnection(konekcija))
            {
                con.Open();
                using (SqlTransaction txn = con.BeginTransaction())
                {
                    try
                    {
                        // Snimi stolove
                        SqlCommand cmdDel = new SqlCommand("DELETE FROM dbo.Stolovi", con, txn);
                        cmdDel.ExecuteNonQuery();

                        foreach (TableItem item in tableItems)
                        {
                            SqlCommand cmdIns = new SqlCommand(
                                "INSERT INTO dbo.Stolovi (BrojStola, PosX, PosY, TipStola) VALUES (@b, @x, @y, @t)",
                                con, txn);
                            cmdIns.Parameters.AddWithValue("@b", item.BrojStola);
                            cmdIns.Parameters.AddWithValue("@x", item.PosX);
                            cmdIns.Parameters.AddWithValue("@y", item.PosY);
                            cmdIns.Parameters.AddWithValue("@t", item.TipStola);
                            cmdIns.ExecuteNonQuery();
                        }

                        // Snimi zone
                        SqlCommand cmdDelZone = new SqlCommand(
                            "DELETE FROM dbo.PasivniElementi WHERE Tip = 'zona'", con, txn);
                        cmdDelZone.ExecuteNonQuery();

                        foreach (ZoneItem zone in zoneItems)
                        {
                            SqlCommand cmdIns = new SqlCommand(
                                "INSERT INTO dbo.PasivniElementi (Tip, Naziv, PosX, PosY, Sirina, Visina, Boja) " +
                                "VALUES ('zona', @n, @x, @y, @w, @h, @b)", con, txn);
                            cmdIns.Parameters.AddWithValue("@n", zone.Naziv);
                            cmdIns.Parameters.AddWithValue("@x", zone.PosX);
                            cmdIns.Parameters.AddWithValue("@y", zone.PosY);
                            cmdIns.Parameters.AddWithValue("@w", zone.Sirina);
                            cmdIns.Parameters.AddWithValue("@h", zone.Visina);
                            cmdIns.Parameters.AddWithValue("@b", zone.Boja);
                            cmdIns.ExecuteNonQuery();
                        }

                        // Snimi labele
                        SqlCommand cmdDelLabel = new SqlCommand(
                            "DELETE FROM dbo.PasivniElementi WHERE Tip = 'labela'", con, txn);
                        cmdDelLabel.ExecuteNonQuery();

                        foreach (LabelItem label in labelItems)
                        {
                            SqlCommand cmdIns = new SqlCommand(
                                "INSERT INTO dbo.PasivniElementi (Tip, Naziv, PosX, PosY, Sirina, Visina, Boja) " +
                                "VALUES ('labela', @n, @x, @y, 0, 0, '')", con, txn);
                            cmdIns.Parameters.AddWithValue("@n", label.Naziv);
                            cmdIns.Parameters.AddWithValue("@x", label.PosX);
                            cmdIns.Parameters.AddWithValue("@y", label.PosY);
                            cmdIns.ExecuteNonQuery();
                        }

                        // Snimi zidove
                        SqlCommand cmdDelWall = new SqlCommand(
                            "DELETE FROM dbo.PasivniElementi WHERE Tip = 'zid'", con, txn);
                        cmdDelWall.ExecuteNonQuery();

                        foreach (WallItem wall in wallItems)
                        {
                            SqlCommand cmdIns = new SqlCommand(
                                "INSERT INTO dbo.PasivniElementi (Tip, Naziv, PosX, PosY, Sirina, Visina, Boja) " +
                                "VALUES ('zid', '', @x, @y, @d, @v, '')", con, txn);
                            cmdIns.Parameters.AddWithValue("@x", wall.PosX);
                            cmdIns.Parameters.AddWithValue("@y", wall.PosY);
                            cmdIns.Parameters.AddWithValue("@d", wall.Duzina);
                            cmdIns.Parameters.AddWithValue("@v", wall.Vertikalan ? 1.0 : 0.0);
                            cmdIns.ExecuteNonQuery();
                        }

                        txn.Commit();
                        System.Windows.Forms.MessageBox.Show(
                            "Raspored je sačuvan. (" + tableItems.Count + " stolova, " +
                            zoneItems.Count + " zona, " + labelItems.Count + " labela, " +
                            wallItems.Count + " zidova)",
                            "Uspeh", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        txn.Rollback();
                        System.Windows.Forms.MessageBox.Show(
                            "Greška pri snimanju: " + ex.Message,
                            "Greška", System.Windows.Forms.MessageBoxButtons.OK,
                            System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
