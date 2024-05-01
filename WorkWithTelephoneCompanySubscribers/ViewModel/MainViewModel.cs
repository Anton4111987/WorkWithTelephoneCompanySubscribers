using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WorkWithTelephoneCompanySubscribers.Data;
using WorkWithTelephoneCompanySubscribers.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WorkWithTelephoneCompanySubscribers.ViewModel
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Street>? streets;
        private ObservableCollection<Address>? addresses;
        private ObservableCollection<Abonent>? abonents;
        private ObservableCollection<PhoneNumber>? phoneNumbers;
        private ObservableCollection<SearchAbonent>? searchAbonents;

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
        public MainViewModel(string number)
        {
            LoadStreets();
            LoadAddresses();
            LoadAbonents();
            LoadPhoneNumbers();
            LoadSearchAbonents(number);
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

        /*private static ObservableCollection<SearchAbonent> GetSearchAbonents()
        {
            return SearchAbonents;
        }*/

        public async void LoadSearchAbonents(string number)
        {
            SearchAbonents = new ObservableCollection<SearchAbonent>(await DataService.LoadSearchAbonents(number));
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
