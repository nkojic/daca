using System.Windows;

namespace WpfAmsterdam
{
    public partial class DlgUpdateProgress : Window
    {
        public DlgUpdateProgress()
        {
            InitializeComponent();
        }

        public void SetStatus(string text)
        {
            txtStatus.Text = text;
        }
    }
}
