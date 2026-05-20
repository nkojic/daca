using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.Sqlite;

namespace WpfAmsterdam
{
    public partial class DlgCrudEditor : Window
    {
        private string konekcija = Window2.konekcija;
        private string tableName;
        private string selectQuery;
        private string[] columns;
        private string pkColumn;
        private string activeColumn;
        private DataTable dataTable;

        public DlgCrudEditor(string tableName, string selectQuery,
            string[] columns, string pkColumn, string activeColumn)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.selectQuery = selectQuery;
            this.columns = columns;
            this.pkColumn = pkColumn;
            this.activeColumn = activeColumn;
            this.Title = "Editor - " + tableName;
            txtTitle.Text = tableName;
            LoadData();
        }

        private void LoadData()
        {
            dataTable = DatabaseHelper.ReaderTabela(konekcija, selectQuery);

            dataGrid.Columns.Clear();
            foreach (string col in columns)
            {
                DataGridTextColumn dgCol = new DataGridTextColumn();
                dgCol.Header = col;
                dgCol.Binding = new System.Windows.Data.Binding(col);

                if (col == pkColumn)
                {
                    dgCol.IsReadOnly = true;
                    dgCol.Width = 60;
                }
                else if (col == activeColumn)
                {
                    dgCol.Width = 60;
                }
                else
                {
                    dgCol.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                }

                dataGrid.Columns.Add(dgCol);
            }

            dataGrid.ItemsSource = dataTable.DefaultView;
            txtCount.Text = dataTable.Rows.Count + " zapisa";
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            DataRow newRow = dataTable.NewRow();

            // Izračunaj sledeći ID za PK kolonu
            int maxId = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row.RowState == DataRowState.Deleted) continue;
                int id = Convert.ToInt32(row[pkColumn]);
                if (id > maxId) maxId = id;
            }

            // Postavi default vrednosti
            foreach (DataColumn col in dataTable.Columns)
            {
                if (col.ColumnName == pkColumn)
                    newRow[col] = maxId + 1;
                else if (col.DataType == typeof(string))
                    newRow[col] = "";
                else if (col.DataType == typeof(int) || col.DataType == typeof(long))
                    newRow[col] = 0;
                else if (col.DataType == typeof(double) || col.DataType == typeof(float))
                    newRow[col] = 0.0;
                else if (col.DataType == typeof(bool))
                    newRow[col] = true;
            }

            // Aktivna/aktivan default = 1
            if (dataTable.Columns.Contains(activeColumn))
                newRow[activeColumn] = 1;

            dataTable.Rows.Add(newRow);
            dataGrid.ScrollIntoView(dataGrid.Items[dataGrid.Items.Count - 1]);
            dataGrid.SelectedItem = dataGrid.Items[dataGrid.Items.Count - 1];
            txtCount.Text = dataTable.Rows.Count + " zapisa";
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem == null)
            {
                System.Windows.Forms.MessageBox.Show("Izaberite red za brisanje.");
                return;
            }

            DataRowView row = dataGrid.SelectedItem as DataRowView;
            if (row == null) return;

            var result = System.Windows.Forms.MessageBox.Show(
                "Da li ste sigurni da želite da deaktivirate ovaj zapis?",
                "Brisanje", System.Windows.Forms.MessageBoxButtons.YesNo,
                System.Windows.Forms.MessageBoxIcon.Warning);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Soft delete
                row[activeColumn] = 0;
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqliteConnection con = new SqliteConnection(konekcija))
                {
                    con.Open();

                    using (SqliteCommand fkOff = new SqliteCommand("PRAGMA foreign_keys = OFF", con))
                        fkOff.ExecuteNonQuery();

                    using (SqliteTransaction txn = con.BeginTransaction())
                    {
                        // Obriši sve i ponovo upiši
                        using (SqliteCommand cmdDel = new SqliteCommand(
                            "DELETE FROM " + tableName, con, txn))
                        {
                            cmdDel.ExecuteNonQuery();
                        }

                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row.RowState == DataRowState.Deleted) continue;

                            string cols = string.Join(", ", columns);
                            string pars = "";
                            for (int i = 0; i < columns.Length; i++)
                            {
                                if (i > 0) pars += ", ";
                                pars += "@p" + i;
                            }

                            using (SqliteCommand cmd = new SqliteCommand(
                                "INSERT OR REPLACE INTO " + tableName + " (" + cols + ") VALUES (" + pars + ")",
                                con, txn))
                            {
                                for (int i = 0; i < columns.Length; i++)
                                {
                                    object val = row[columns[i]];
                                    if (val == null || val == DBNull.Value) val = "";
                                    cmd.Parameters.AddWithValue("@p" + i, val);
                                }
                                cmd.ExecuteNonQuery();
                            }
                        }

                        txn.Commit();
                    }

                    using (SqliteCommand fkOn = new SqliteCommand("PRAGMA foreign_keys = ON", con))
                        fkOn.ExecuteNonQuery();
                }

                System.Windows.Forms.MessageBox.Show(
                    "Sačuvano " + dataTable.Rows.Count + " zapisa.",
                    "Uspeh", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);

                dataTable.AcceptChanges();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Greška: " + ex.Message, "Greška",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
