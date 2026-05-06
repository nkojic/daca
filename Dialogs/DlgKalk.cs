using System;
using System.Drawing;
using System.Windows.Forms;

namespace WpfAmsterdam
{
    public partial class DlgKalk : Form
    {
        private bool _daliCena;
        private string broj = string.Empty;

        public DlgKalk(bool daliCena)
        {
            InitializeComponent();
            _daliCena = daliCena;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            broj = broj + ((Button)sender).Text;
            lblUkupno.Text = broj;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            broj = string.Empty;
            lblUkupno.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_daliCena)
            {
                Form1.cenaArt = Convert.ToDouble(broj);
            }
            else
            {
                Form1.kom = Convert.ToDouble(broj);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
