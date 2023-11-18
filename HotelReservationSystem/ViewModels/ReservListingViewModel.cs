using HotelReservationSystem.Commands;
using HotelReservationSystem.Models;
using HotelReservationSystem.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelReservationSystem.ViewModels
{
    public class ReservListingViewModel : ViewModelBase
    {
		private readonly ObservableCollection<ReservationViewModel> _reservations;
		public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }

        public ReservListingViewModel(NavigationStore navigationStore)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            _reservations.Add(new ReservationViewModel(
                new Reservation(new RoomID(1, 2), DateTime.Now, DateTime.Now, "hamza")));
            _reservations.Add(new ReservationViewModel(
                new Reservation(new RoomID(1, 2), DateTime.Now, DateTime.Now, "hamza")));
            _reservations.Add(new ReservationViewModel(
                new Reservation(new RoomID(2, 5), DateTime.Now, DateTime.Now, "EL Yousfi")));
            _reservations.Add(new ReservationViewModel(
                new Reservation(new RoomID(1, 2), DateTime.Now, DateTime.Now, "hamza")));
            _reservations.Add(new ReservationViewModel(
                new Reservation(new RoomID(1, 2), DateTime.Now, DateTime.Now, "hamza")));
            _reservations.Add(new ReservationViewModel(
                new Reservation(new RoomID(2, 5), DateTime.Now, DateTime.Now, "EL Yousfi")));

            MakeReservationCommand = new NavigateCommand(navigationStore);
        }

    }
}
