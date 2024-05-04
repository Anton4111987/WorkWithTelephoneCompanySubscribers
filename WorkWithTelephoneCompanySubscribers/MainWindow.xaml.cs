using System.Windows;
using WorkWithTelephoneCompanySubscribers.Data;
using WorkWithTelephoneCompanySubscribers.ViewModel;
using CsvHelper;
using System.IO;
using System.Text;
using CsvHelper.Configuration;
using WorkWithTelephoneCompanySubscribers.Models;

namespace WorkWithTelephoneCompanySubscribers
{
    public partial class MainWindow : Window
    {
        MainViewModel? mainViewModel;
        public MainWindow()
        {
            InitializeComponent();
            DBUtilities.FileExists();
            mainViewModel = new MainViewModel();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow searchWindow = new ();
            if(searchWindow.ShowDialog() == true) 
            {
                mainViewModel?.LoadSearchAbonents(searchWindow.Number.Trim());
                if (mainViewModel?.SearchAbonents.Count == 0)
                    MessageBox.Show("Нет абонентов, удовлетворяющих критерию поиска", "Info");
                dataGrid.ItemsSource = mainViewModel?.SearchAbonents;
            }
        }

        private void Streets_Click(object sender, RoutedEventArgs e)
        {
            StreetsWindow streetsWindow = new(mainViewModel);
            if (streetsWindow.ShowDialog() == true){}
        }

        private void ShowAllAbonents_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = mainViewModel?.AllAbonents;
        }

        private void Unload_Click(object sender, RoutedEventArgs e)
        {
            string date = DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss"); 
            string pathCsvFile = $@"report_"+date+".csv";
            using (StreamWriter writer = new StreamWriter(pathCsvFile, false, Encoding.UTF8))
            {
                using (var csv = new CsvWriter(writer, new CsvConfiguration(System.Globalization.CultureInfo.InvariantCulture)))
                {
                    var items = dataGrid.Items.OfType<object>();
                    csv.WriteHeader(items.First().GetType());
                    csv.NextRecord();
                    foreach (var item in items)
                    {
                        csv.WriteRecord(item);
                        csv.NextRecord();
                    }
                }
            }
            if (File.Exists(pathCsvFile))
                MessageBox.Show("Файл успешно выгружен", "Выгрузка файла csv");
        }
    }
}