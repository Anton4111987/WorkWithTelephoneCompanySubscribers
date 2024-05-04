using System.Windows;
using WorkWithTelephoneCompanySubscribers.ViewModel;

namespace WorkWithTelephoneCompanySubscribers
{
    public partial class StreetsWindow : Window
    {
        public StreetsWindow(MainViewModel mainViewModel)
        {
            InitializeComponent();
            dataGridStreets.ItemsSource=mainViewModel.ShowByStreets;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

