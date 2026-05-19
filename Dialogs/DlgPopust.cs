using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WpfAmsterdam
{
    public partial class DlgPopust : Form
    {
        private DataTable tblZaposleni;
        private DataTable tblPotpisi;
        private int idZaposl = 0;

        public DlgPopust(DataTable Ime, DataTable potpis)
        {
            InitializeComponent();
            ThemeManager.ApplyWinFormsTheme(this);
            tblZaposleni = Ime;
            tblPotpisi = potpis;
        }

        private void dlgPopust_Load(object sender, EventArgs e)
        {
            foreach (DataRow red in tblPotpisi.Rows)
            {
                Button btn = Dugme(Convert.ToString(red["Ime"]), Convert.ToString(red["IdPotpis"]));
                btn.Click += Button_Click;
                Panel1.Controls.Add(btn);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            int idkat = Convert.ToInt32(((Button)sender).Name);
            DataRow[] redovi = tblZaposleni.Select("IdPotpis = " + idkat);
            idZaposl = 0;
            Label2.Text = string.Empty;
            Label1.Text = ((Button)sender).Text;
            Panel3.Controls.Clear();
            foreach (DataRow red in redovi)
            {
                Button btn = DugmeZaposleni(Convert.ToString(red["Ime"]), Convert.ToInt32(red["IdIme"]));
                btn.Click += ButtonZaposleni_Click;
                Panel3.Controls.Add(btn);
            }
        }

        private void ButtonZaposleni_Click(object sender, EventArgs e)
        {
            idZaposl = Convert.ToInt32(((Button)sender).Name);
            Label2.Text = ((Button)sender).Text;
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            if (Label2.Text == string.Empty || idZaposl == 0)
            {
                MessageBox.Show("Ponovo!!!");
                return;
            }
            Window2.IdImee = idZaposl;
            Window2.Korisnik = Label1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private Button Dugme(string capt, string ime)
        {
            Button dgm = new Button();
            dgm.Name = ime;
            dgm.Text = capt;
            dgm.Width = 81;
            dgm.Height = 69;
            dgm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgm.BackColor = ThemeManager.WfAccent;
            dgm.ForeColor = Color.White;
            dgm.FlatStyle = FlatStyle.Flat;
            dgm.FlatAppearance.BorderSize = 0;
            dgm.Margin = new Padding(3);
            dgm.Cursor = Cursors.Hand;
            return dgm;
        }

        private Button DugmeZaposleni(string capt, int ime)
        {
            Button dgm = new Button();
            dgm.Name = ime.ToString();
            dgm.Text = capt;
            dgm.Width = 81;
            dgm.Height = 69;
            dgm.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dgm.BackColor = ThemeManager.WfButtonBg;
            dgm.ForeColor = ThemeManager.WfTextColor;
            dgm.FlatStyle = FlatStyle.Flat;
            dgm.FlatAppearance.BorderColor = ThemeManager.WfAccent;
            dgm.FlatAppearance.BorderSize = 1;
            dgm.Margin = new Padding(3);
            dgm.Cursor = Cursors.Hand;
            return dgm;
        }
    }
}
