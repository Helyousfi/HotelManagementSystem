using HotelReservationSystem.Models;
using HotelReservationSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; set; }

        public MainWindowViewModel(Hotel hotel)
        {
            CurrentViewModel = new MakeReservViewModel(hotel); // hard coded
        }
    }
}
