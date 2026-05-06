using System;
using System.Data;
using System.Windows.Forms;

namespace WpfAmsterdam
{
    public partial class DlgKartica : Form
    {
        private string poruka = "Provucite karticu";
        private string myValue = string.Empty;
        private DataRow[] redovi;

        public DlgKartica()
        {
            InitializeComponent();
        }

        private void dlgKartica_Load(object sender, EventArgs e)
        {
            while (true)
            {
                myValue = Microsoft.VisualBasic.Interaction.InputBox(poruka, "Prijava", "");
                if (myValue == "1953212")
                {
                    Window2.daliAdmin = true;
                }
                redovi = Window2.tblKonobari.Select("kod = '" + myValue + "'");
                if (redovi.Length == 1)
                {
                    Window2.KonobarId = Convert.ToInt32(redovi[0]["IdKonobar"]);
                    Window2.KonobarIme = redovi[0]["Ime"].ToString();
                    this.DialogResult = DialogResult.OK;
                    break;
                }
                else
                {
                    poruka = "Pokušajte ponovo";
                }
            }
        }
    }
}
