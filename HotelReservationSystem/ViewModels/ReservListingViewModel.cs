using HotelReservationSystem.Commands;
using HotelReservationSystem.Models;
using HotelReservationSystem.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelReservationSystem.ViewModels
{
    public class ReservListingViewModel : ViewModelBase
    {
		private ObservableCollection<ReservationViewModel> _reservations;
		public IEnumerable<ReservationViewModel> Reservations => _reservations;
        public ICommand MakeReservationCommand { get; }
        public ICommand DeleteCommand { get; }
        private Hotel _hotel;

        private ReservationViewModel? _selectedReservation;
        public ReservationViewModel? SelectedReservation { 
            get => _selectedReservation;
            set
            {
                _selectedReservation = value;
            }
        }

        public void RemoveSelectedReservation()
        {
            _hotel.DeleteReservation(_selectedReservation?.Reservation);
            UpdateReservations();
        }

        public void UpdateReservations()
        {
            _reservations.Clear();
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

            foreach (var reservation in _hotel?.GetAllReservations())
            {
                _reservations.Add(new ReservationViewModel(reservation));
            }
            
            _reservations.CollectionChanged += ReservationsCollectionChanged;
        }

        public ReservListingViewModel(Hotel hotel,NavigationStore navigationStore)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();
            _hotel = hotel;
            UpdateReservations();
            MakeReservationCommand = new NavigateCommand(navigationStore, _reservations);
            DeleteCommand = new DeleteCommand(this);
        }

        private void ReservationsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Notify the UI about changes in the Reservations collection
            OnPropertyChanged(nameof(Reservations));
        }



    }
}
