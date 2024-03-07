using HotelReservationSystem.Models;
using HotelReservationSystem.Stores;
using HotelReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Commands
{
    /// <summary>
    /// The command used when we click the button "Make reservation" in reservaation listing view
    /// </summary>
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly ObservableCollection<ReservationViewModel> _reservations;
        public NavigateCommand(NavigationStore navigationStore, ObservableCollection<ReservationViewModel> Reservations )
        {
            _navigationStore = navigationStore;
            _reservations = Reservations;
        }
        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = 
                new MakeReservViewModel(new Models.Hotel("", ""), 
                _navigationStore);
        }

        public override bool CanExecute(object? parameter)
        {
            return _reservations.Count() < 15;
        }
    }
}
