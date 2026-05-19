using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WpfAmsterdam
{
    public partial class DlgZamenaKonobara : Form
    {
        private int IdKonobarNovi = 0;

        public DlgZamenaKonobara() { InitializeComponent(); }

        private void dlgZamenaKonobara_Load(object sender, EventArgs e)
        {
            Window2.Timer1.Stop();
            foreach (DataRow red in Window2.tblKonobari.Rows)
            {
                Button btn1 = Dugme1(red["Ime"].ToString(), red["IdKonobar"].ToString());
                btn1.Click += Button1_Click;
                this.Panel1.Controls.Add(btn1);
            }
            this.Label1.Text = Window2.KonobarIme + " preuzima sto od:";
        }

        private void btnNE_Click(object sender, EventArgs e)
        {
            if (Window2.KoristiKartice)
                Window2.Timer1.Start();
            this.Close();
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            if (IdKonobarNovi != 0)
            {
                DatabaseHelper.ProcZamenaKonobara(Window2.konekcija, Window2.KonobarId, IdKonobarNovi);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Niste odabrali konobara!!!");
            }
        }

        private Button Dugme1(string capt, string ime)
        {
            Button dgm = new Button();
            dgm.Name = ime; dgm.Text = capt;
            dgm.Width = 103; dgm.Height = 85;
            dgm.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            dgm.BackColor = Color.DarkGoldenrod; dgm.ForeColor = Color.White;
            return dgm;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Label2.Text = ((Button)sender).Text;
            IdKonobarNovi = Convert.ToInt32(((Button)sender).Name);
        }
    }
}
