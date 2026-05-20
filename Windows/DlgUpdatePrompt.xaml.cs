using System.Windows;

namespace WpfAmsterdam
{
    public partial class DlgUpdatePrompt : Window
    {
        public bool Accepted { get; private set; }

        public DlgUpdatePrompt(string message)
        {
            InitializeComponent();
            txtMessage.Text = message;
        }

        private void btnDa_Click(object sender, RoutedEventArgs e)
        {
            Accepted = true;
            Close();
        }

        private void btnNe_Click(object sender, RoutedEventArgs e)
        {
            Accepted = false;
            Close();
        }
    }
}
