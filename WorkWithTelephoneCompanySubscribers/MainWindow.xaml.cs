using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WorkWithTelephoneCompanySubscribers.Data;
using WorkWithTelephoneCompanySubscribers.ViewModel;

namespace WorkWithTelephoneCompanySubscribers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string number;
        string street;
        MainViewModel mainViewModel;
        public MainWindow()
        {
            InitializeComponent();
            DBUtilities.FileExists();
            
            
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new SearchWindow();
            if(searchWindow.ShowDialog() == true) 
            {
                number = searchWindow.Number;
                mainViewModel = new MainViewModel(number);
                dataGrid.ItemsSource = mainViewModel.SearchAbonents;
                
            }

        }

        private void Streets_Click(object sender, RoutedEventArgs e)
        {
            StreetsWindow streetsWindow = new StreetsWindow();
            if (streetsWindow.ShowDialog() == true)
            {
                street = streetsWindow.Street;
            }
        }
    }
}