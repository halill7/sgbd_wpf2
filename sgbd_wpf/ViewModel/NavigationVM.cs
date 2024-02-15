
using Page_Navigation_App.Utilities;
using Page_Navigation_App.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Page_Navigation_App.ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand CustomersCommand { get; set; }
        public ICommand ProductsCommand { get; set; }
        public ICommand OrdersCommand { get; set; }
        public ICommand TransactionsCommand { get; set; }
        public ICommand ShipmentsCommand { get; set; }
        public ICommand SettingsCommand { get; set; }
        public ICommand ParticipationCommand { get; set; }
        public ICommand ListUeSectionCommand { get; set; }

        private void Home(object obj) => CurrentView = new EtudiantVM();
        private void Customer(object obj) => CurrentView = new CustomerVM();
        private void Product(object obj) => CurrentView = new ProductVM();
        private void Order(object obj) => CurrentView = new OrderVM();
        private void Transaction(object obj) => CurrentView = new TransactionVM();
        private void Shipment(object obj) => CurrentView = new ShipmentVM();
        private void Setting(object obj) => CurrentView = new SettingVM();
        private void Participation(object obj) => CurrentView = new ParticipationVM();
        private void ListUeSection(object obj) => CurrentView = new ListUeSectionVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            CustomersCommand = new RelayCommand(Customer);
            ProductsCommand = new RelayCommand(Product);
            OrdersCommand = new RelayCommand(Order);
            TransactionsCommand = new RelayCommand(Transaction);
            ShipmentsCommand = new RelayCommand(Shipment);
            SettingsCommand = new RelayCommand(Setting);
            ParticipationCommand = new RelayCommand(Participation);
            ListUeSectionCommand = new RelayCommand(ListUeSection);   

            // Startup Page
            CurrentView = new EtudiantVM();
        }
    }
}
