using System;
using System.Drawing;
using System.Windows.Forms;

namespace WpfAmsterdam
{
    public partial class DlgKalkPlacanje : Form
    {
        private string broj = string.Empty;

        public DlgKalkPlacanje()
        {
            InitializeComponent();
            ThemeManager.ApplyWinFormsTheme(this);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            broj = broj + ((Button)sender).Text;
            lblUkupno.Text = broj;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblUkupno.Text = "";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DlgPlacanje.Broj = Convert.ToDouble(broj);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
