using HotelReservationSystem.Models;
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
        public App()
        {
            _hotel = new Hotel("Hamza Hotel", "Argenteuil");
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_hotel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
