using HotelReservationSystem.Models;
using HotelReservationSystem.Stores;
using HotelReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HotelReservationSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application 
    {
        private readonly Hotel? _hotel;
        // Override the OnStartup method
        private readonly NavigationStore? _navigationStore;
        public App()
        {
            _hotel = new Hotel("Hamza Hotel", "Argenteuil");
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = new ReservListingViewModel(_hotel, _navigationStore);
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
