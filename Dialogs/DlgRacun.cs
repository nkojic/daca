using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace WpfAmsterdam
{
    public partial class DlgRacun : Form
    {
        private DataTable tblPromet;
        private DataTable tblArtikal;
        private double suma = 0;
        private double popust = 0;
        private double konacno = 0;
        public static double Broj = 0;
        StringBuilder sbPred = new StringBuilder();

        public DlgRacun()
        {
            InitializeComponent();
        }

        private void dlgPlacanje_Load(object sender, EventArgs e)
        {
            tblPromet = DatabaseHelper.ReaderTabela(Window2.konekcija, "SELECT * FROM fncPromet('" + Window2.BrojStola + "')");

            suma = 0;
            foreach (DataRow redd in tblPromet.Rows)
            {
                if (Convert.ToDouble(redd["Ukupno"]) < 0 || Convert.ToDouble(redd["Komada"]) < 0)
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                    return;
                }
                suma += Convert.ToDouble(redd["Ukupno"]);
            }

            if (suma <= 0)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }

            if (suma != Form1.sumica)
            {
                MessageBox.Show("Imate nesparene negativne količine. Ispravite unos !!!");
                this.Close();
                return;
            }

            Label6.Text = suma.ToString("0,0.00", CultureInfo.InvariantCulture);
            DataGridView2.AutoGenerateColumns = false;
            DataGridView2.DataSource = tblPromet;
            if (DataGridView2.RowCount < 1)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
                return;
            }
            Label7.Text = suma.ToString("0,0.00", CultureInfo.InvariantCulture);
            konacno = suma;
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Form1.popust = popust;
            Form1.koment = RichTextBox1.Text;

            DataRow artikRed = null;
            string artik = string.Empty;
            double Kolicina = 0;
            double Iznos = 0;
            string deoPorc = string.Empty;
            sbPred.AppendLine("\r\n========================\r\n");
            foreach (DataRow redSt in tblPromet.Rows)
            {
                artik = Convert.ToString(redSt["ImeArtikal"]);
                Kolicina = Math.Round(Convert.ToDouble(redSt["Komada"]) * Convert.ToDouble(redSt["DeoPorcije"]), 2);
                Iznos = Math.Round(Kolicina * Convert.ToDouble(redSt["Cena"]), 2);
                if (Convert.ToDouble(redSt["DeoPorcije"]) < 1)
                {
                    deoPorc = "1/2p.";
                }
                else
                {
                    deoPorc = string.Empty;
                }
                sbPred.AppendLine(string.Format("  {0}", artik));
                sbPred.AppendLine(string.Format("{1}{0}{2}{0}{3}", "\t", Convert.ToString(redSt["Komada"]) + " X", Convert.ToString(redSt["Cena"]), Iznos.ToString("0,0.00", CultureInfo.InvariantCulture) + "   " + deoPorc));
            }
            sbPred.AppendLine("\r\n========================\r\n");
            if (popust > 0)
            {
                sbPred.AppendLine("Iznos bez popusta: " + suma.ToString("0,0.00", CultureInfo.InvariantCulture));
                sbPred.AppendLine("Popust " + popust.ToString() + "% : " + (suma - konacno).ToString("0,0.00", CultureInfo.InvariantCulture));
            }
            sbPred.AppendLine("Iznos za naplatu: " + konacno.ToString("0,0.00", CultureInfo.InvariantCulture));
            sbPred.AppendLine("\r\n\r\nIzaberite način plaćanja:\r\n" +
                                            "    ČEK\r\n" +
                                            "    GOTOVINA\r\n" +
                                            "    KARTICA\r\n\r\n" +
                                            "Molimo sačekajte račun!!!");
            Form1.sbPredracun = sbPred;
            Form1.konacno = konacno;
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch ((int)popust)
            {
                case 0:
                    popust = 5;
                    break;
                case 5:
                    popust = 10;
                    break;
                case 10:
                    popust = 20;
                    break;
                case 20:
                    popust = 30;
                    break;
                case 30:
                    popust = 40;
                    break;
                case 40:
                    popust = 50;
                    break;
                case 50:
                    popust = 0;
                    break;
            }
            Button1.Text = popust.ToString();
            konacno = suma * (1 - popust / 100);
            Label7.Text = konacno.ToString("0,0.00", CultureInfo.InvariantCulture);
        }
    }
}
