using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WorkWithTelephoneCompanySubscribers.Data;
using WorkWithTelephoneCompanySubscribers.Models;

namespace WorkWithTelephoneCompanySubscribers.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Street>? streets;
        private ObservableCollection<Address>? addresses;
        private ObservableCollection<Abonent>? abonents;
        private ObservableCollection<PhoneNumber>? phoneNumbers;
        private ObservableCollection<SearchAbonent>? searchAbonents;
        private ObservableCollection<SearchAbonent>? allAbonents;
        private ObservableCollection<ShowByStreet>? showByStreets;

        public ObservableCollection<Street> Streets
        {
            get { return streets; }
            set { streets = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Address> Addresses
        {
            get { return addresses; }
            set { addresses = value; OnPropertyChanged(); }
        }
        public ObservableCollection<Abonent> Abonents
        {
            get { return abonents; }
            set { abonents = value; OnPropertyChanged(); }
        }
        public ObservableCollection<PhoneNumber> PhoneNumbers
        {
            get { return phoneNumbers; }
            set { phoneNumbers = value; OnPropertyChanged(); }
        }

        public ObservableCollection<SearchAbonent> SearchAbonents
        {
            get { return searchAbonents; }
            set { searchAbonents = value; OnPropertyChanged(); }
        }
        public ObservableCollection<SearchAbonent> AllAbonents
        {
            get { return allAbonents; }
            set { allAbonents = value; OnPropertyChanged(); }
        }
        public ObservableCollection<ShowByStreet> ShowByStreets
        {
            get { return showByStreets; }
            set { showByStreets = value; OnPropertyChanged(); }
        }
        public MainViewModel()
        {
            LoadStreets();
            LoadAddresses();
            LoadAbonents();
            LoadPhoneNumbers();
            LoadAllAbonents();
            LoadShowByStreets();
        }
        

        private async void LoadStreets()
        {
            Streets = new ObservableCollection<Street>(await DataService.LoadStreets());
        }

        private async void LoadAddresses()
        {
            Addresses = new ObservableCollection<Address>(await DataService.LoadAddresses());
        }

        private async void LoadAbonents()
        {
            Abonents = new ObservableCollection<Abonent>(await DataService.LoadAbonents());
        }

        private async void LoadPhoneNumbers()
        {
            PhoneNumbers = new ObservableCollection<PhoneNumber>(await DataService.LoadPhoneNumbers());
        }

        public async void LoadSearchAbonents(string number)
        {
            SearchAbonents = new ObservableCollection<SearchAbonent>(await DataService.LoadSearchAbonents(number));
        }
        public async void LoadAllAbonents()
        {
            AllAbonents = new ObservableCollection<SearchAbonent>(await DataService.LoadAllAbonents());
        }
        public async void LoadShowByStreets()
        {
            ShowByStreets = new ObservableCollection<ShowByStreet>(await DataService.LoadShowByStreets());
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
