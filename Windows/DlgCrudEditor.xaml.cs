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
        private Action<DataTable, SqliteConnection, SqliteTransaction> customSave;

        public DlgCrudEditor(string tableName, string selectQuery,
            string[] columns, string pkColumn, string activeColumn,
            Action<DataTable, SqliteConnection, SqliteTransaction> customSave = null)
        {
            InitializeComponent();
            this.tableName = tableName;
            this.selectQuery = selectQuery;
            this.columns = columns;
            this.pkColumn = pkColumn;
            this.activeColumn = activeColumn;
            this.customSave = customSave;
            this.Title = "Editor - " + tableName;
            txtTitle.Text = tableName;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataTable = DatabaseHelper.ReaderTabela(konekcija, selectQuery);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Greška pri učitavanju: " + ex.Message);
                dataTable = new DataTable();
                return;
            }

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
                int updated = 0;
                int inserted = 0;

                using (SqliteConnection con = new SqliteConnection(konekcija))
                {
                    con.Open();

                    using (SqliteCommand fkOff = new SqliteCommand("PRAGMA foreign_keys = OFF", con))
                        fkOff.ExecuteNonQuery();

                    using (SqliteTransaction txn = con.BeginTransaction())
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            if (row.RowState == DataRowState.Deleted) continue;
                            if (row.RowState == DataRowState.Unchanged) continue;

                            if (row.RowState == DataRowState.Added)
                            {
                                // INSERT novi red
                                string cols = string.Join(", ", columns);
                                string parStr = "";
                                for (int i = 0; i < columns.Length; i++)
                                {
                                    if (i > 0) parStr += ", ";
                                    parStr += "@p" + i;
                                }

                                using (SqliteCommand cmd = new SqliteCommand(
                                    "INSERT INTO " + tableName + " (" + cols + ") VALUES (" + parStr + ")",
                                    con, txn))
                                {
                                    for (int i = 0; i < columns.Length; i++)
                                    {
                                        object val = row[columns[i]];
                                        if (val == null || val == DBNull.Value) val = 0;
                                        cmd.Parameters.AddWithValue("@p" + i, val);
                                    }
                                    cmd.ExecuteNonQuery();
                                    inserted++;
                                }
                            }
                            else if (row.RowState == DataRowState.Modified)
                            {
                                // UPDATE postojeći red
                                string setClause = "";
                                for (int i = 0; i < columns.Length; i++)
                                {
                                    if (columns[i] == pkColumn) continue;
                                    if (setClause.Length > 0) setClause += ", ";
                                    setClause += columns[i] + " = @p" + i;
                                }

                                using (SqliteCommand cmd = new SqliteCommand(
                                    "UPDATE " + tableName + " SET " + setClause +
                                    " WHERE " + pkColumn + " = @pk",
                                    con, txn))
                                {
                                    for (int i = 0; i < columns.Length; i++)
                                    {
                                        if (columns[i] == pkColumn) continue;
                                        object val = row[columns[i]];
                                        if (val == null || val == DBNull.Value) val = 0;
                                        cmd.Parameters.AddWithValue("@p" + i, val);
                                    }
                                    cmd.Parameters.AddWithValue("@pk", Convert.ToInt64(row[pkColumn]));
                                    cmd.ExecuteNonQuery();
                                    updated++;
                                }
                            }
                        }

                        // Custom save logika (npr. za konobari kartice)
                        if (customSave != null)
                            customSave(dataTable, con, txn);

                        txn.Commit();
                    }

                    using (SqliteCommand fkOn = new SqliteCommand("PRAGMA foreign_keys = ON", con))
                        fkOn.ExecuteNonQuery();
                }

                System.Windows.Forms.MessageBox.Show(
                    "Izmenjeno: " + updated + ", Dodato: " + inserted,
                    "Uspeh", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);

                // Ponovo učitaj podatke iz baze da budu konzistentni
                LoadData();
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
