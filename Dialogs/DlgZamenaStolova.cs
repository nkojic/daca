using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WpfAmsterdam
{
    public partial class DlgZamenaStolova : Form
    {
        public DlgZamenaStolova() { InitializeComponent(); }

        private void dlgZamenaStolova_Load(object sender, EventArgs e)
        {
            Window2.Timer1.Stop();
            foreach (DataRow red in Window2.tblStolovi.Rows)
            {
                Button btn1 = Dugme1(red["BrojStola"].ToString(), red["BrojStola"].ToString());
                btn1.Click += Button1_Click;
                this.Panel1.Controls.Add(btn1);
                Button btn2 = Dugme2(red["BrojStola"].ToString(), red["BrojStola"].ToString());
                btn2.Click += Button2_Click;
                this.Panel2.Controls.Add(btn2);
            }
        }

        private void btnNE_Click(object sender, EventArgs e)
        {
            Window2.Timer1.Start();
            this.Close();
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            if (!(Label2.Text == string.Empty || Label4.Text == string.Empty))
            {
                Window2.Sto1 = Label2.Text;
                Window2.Sto2 = Label4.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Niste odabrali stolove");
            }
        }

        private Button Dugme1(string capt, string ime)
        {
            Button dgm = new Button();
            dgm.Name = ime; dgm.Text = capt;
            dgm.Width = 55; dgm.Height = 55;
            dgm.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            dgm.BackColor = Color.DarkGoldenrod; dgm.ForeColor = Color.White;
            return dgm;
        }

        private Button Dugme2(string capt, string ime)
        {
            Button dgm = new Button();
            dgm.Name = ime; dgm.Text = capt;
            dgm.Width = 55; dgm.Height = 55;
            dgm.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            dgm.BackColor = Color.IndianRed; dgm.ForeColor = Color.White;
            return dgm;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Label2.Text = ((Button)sender).Text;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Label4.Text = ((Button)sender).Text;
        }
    }
}
