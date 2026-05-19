using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WpfAmsterdam
{
    public partial class DlgPrilozi : Form
    {
        private DataTable tblArtikliPrilog;
        private int idArtikal = 0;
        private string Naziv = string.Empty;

        public DlgPrilozi(DataTable prilog)
        {
            InitializeComponent();
            ThemeManager.ApplyWinFormsTheme(this);
            tblArtikliPrilog = prilog;
        }

        private void dlgPrilozi_Load(object sender, EventArgs e)
        {
            Button btnn = Dugme("bez priloga", "0");
            btnn.Click += new EventHandler(Button_Click);
            this.Panel1.Controls.Add(btnn);
            foreach (DataRow red in tblArtikliPrilog.Rows)
            {
                Button btn = Dugme(red["Naziv"].ToString(), red["IdArtikal"].ToString());
                btn.Click += new EventHandler(Button_Click);
                this.Panel1.Controls.Add(btn);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            idArtikal = Convert.ToInt32(((Button)sender).Name);
            Naziv = ((Button)sender).Text;
            Label1.Text = Naziv;
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            Form1.IdArt = idArtikal;
            Form1.ImeArt = Naziv;
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
            dgm.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular);
            dgm.BackColor = Color.DarkGoldenrod;
            dgm.ForeColor = Color.White;
            return dgm;
        }
    }
}
