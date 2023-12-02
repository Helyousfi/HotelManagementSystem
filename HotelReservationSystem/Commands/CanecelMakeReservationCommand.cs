using HotelReservationSystem.Models;
using HotelReservationSystem.Stores;
using HotelReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Commands
{
    public class CanecelMakeReservationCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Hotel _hotel;
        public CanecelMakeReservationCommand(NavigationStore 
            navigationStore,
            Hotel hotel)
        {
            _navigationStore = navigationStore;
            _hotel = hotel;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = new ReservListingViewModel(_hotel, _navigationStore);
        }
    }
}
