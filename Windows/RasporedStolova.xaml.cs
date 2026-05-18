using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
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

        private string konekcija = Window2.konekcija;
        private List<TableItem> tableItems = new List<TableItem>();
        private Button draggedButton = null;
        private Point dragOffset;

        public RasporedStolova()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = DatabaseHelper.ReaderTabela(konekcija,
                "SELECT BrojStola, PosX, PosY, TipStola FROM dbo.Stolovi");

            if (dt.Rows.Count > 0)
            {
                int squareCount = 0;
                int roundCount = 0;

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

                    if (type == "round") roundCount++;
                    else squareCount++;
                }

                txtSquareCount.Text = squareCount.ToString();
                txtRoundCount.Text = roundCount.ToString();
            }
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

        private void btnPrikazi_Click(object sender, RoutedEventArgs e)
        {
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

            canvasStolovi.Children.Clear();
            tableItems.Clear();

            // Ažuriraj layout da dobijemo ActualWidth/Height
            canvasStolovi.UpdateLayout();
            double canvasWidth = canvasStolovi.ActualWidth;
            if (canvasWidth < 100) canvasWidth = 1000;

            int counter = 0;
            int maxCols = (int)((canvasWidth - 20) / 75);
            if (maxCols < 1) maxCols = 10;
            int col = 0;
            int row = 0;

            // Kvadratni stolovi
            for (int i = 0; i < squareCount; i++)
            {
                counter++;
                string name = "S" + counter;
                double x = 20 + col * 75;
                double y = 20 + row * 75;

                Button btn = CreateTableButton(name, "square");
                Canvas.SetLeft(btn, x);
                Canvas.SetTop(btn, y);
                canvasStolovi.Children.Add(btn);

                tableItems.Add(new TableItem
                {
                    BrojStola = name,
                    PosX = x,
                    PosY = y,
                    TipStola = "square",
                    UiButton = btn
                });

                col++;
                if (col >= maxCols) { col = 0; row++; }
            }

            // Kružni stolovi - novi red
            if (squareCount > 0) { col = 0; row++; }

            for (int i = 0; i < roundCount; i++)
            {
                counter++;
                string name = "S" + counter;
                double x = 15 + col * 80;
                double y = 20 + row * 80;

                Button btn = CreateTableButton(name, "round");
                Canvas.SetLeft(btn, x);
                Canvas.SetTop(btn, y);
                canvasStolovi.Children.Add(btn);

                tableItems.Add(new TableItem
                {
                    BrojStola = name,
                    PosX = x,
                    PosY = y,
                    TipStola = "round",
                    UiButton = btn
                });

                col++;
                if (col >= maxCols) { col = 0; row++; }
            }
        }

        // --- Drag and Drop ---

        private void Table_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            draggedButton = sender as Button;
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

                Canvas.SetLeft(draggedButton, newX);
                Canvas.SetTop(draggedButton, newY);
            }
        }

        private void Table_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (draggedButton != null)
            {
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

        // --- Snimanje u bazu ---

        private void btnSnimi_Click(object sender, RoutedEventArgs e)
        {
            if (tableItems.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Nema stolova za snimanje.");
                return;
            }

            using (SqlConnection con = new SqlConnection(konekcija))
            {
                con.Open();
                using (SqlTransaction txn = con.BeginTransaction())
                {
                    try
                    {
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

                        txn.Commit();
                        System.Windows.Forms.MessageBox.Show(
                            "Raspored stolova je sačuvan. (" + tableItems.Count + " stolova)",
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
