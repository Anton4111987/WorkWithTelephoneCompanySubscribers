using System.Windows;

namespace WorkWithTelephoneCompanySubscribers
{
    public partial class SearchWindow : Window
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public string Number
        {
            get { return numberBox.Text; }
        }
    }
}
