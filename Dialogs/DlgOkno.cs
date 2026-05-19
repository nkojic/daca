using System;
using System.Windows.Forms;

namespace WpfAmsterdam
{
    public partial class DlgOkno : Form
    {
        public DlgOkno(string poruka)
        {
            InitializeComponent();
            ThemeManager.ApplyWinFormsTheme(this);
            this.Label1.Text = poruka;
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNE_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
