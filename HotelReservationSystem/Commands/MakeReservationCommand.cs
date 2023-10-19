using HotelReservationSystem.Exceptions;
using HotelReservationSystem.Models;
using HotelReservationSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelReservationSystem.Commands
{
    class MakeReservationCommand : CommandBase
    {
        private Hotel _hotel;
        private MakeReservViewModel _makeReservViewModel;

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeReservViewModel.Username) && 
                _makeReservViewModel.FloorNumber > 0 &&
                _makeReservViewModel.RoomNumber > 0 &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            // Create a reservation from the inputs we have in the MakeReservViewModel
            Reservation reservation = new Reservation(
                new RoomID(_makeReservViewModel.RoomNumber,
                            _makeReservViewModel.FloorNumber),
                _makeReservViewModel.StartDate,
                _makeReservViewModel.EndDate,
                _makeReservViewModel.Username
                );
            try
            {
                _hotel.AddReservation(reservation);
                MessageBox.Show("Success", "Added succusfully!", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch ( ReservationConflictException ) 
            {
                MessageBox.Show("This room is already taken!", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch ( InvalidReservationTimeRangeException )
            {
                MessageBox.Show("Invalide dates!", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public MakeReservationCommand(
            MakeReservViewModel makeReservViewModel,
            Hotel hotel)
        {
            _hotel = hotel;
            _makeReservViewModel = makeReservViewModel;
            _makeReservViewModel.PropertyChanged += OnViewModelPropertyChanged; 
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_makeReservViewModel.Username) || 
                e.PropertyName == nameof(_makeReservViewModel.FloorNumber) ||
                e.PropertyName == nameof(_makeReservViewModel.RoomNumber) ||
                e.PropertyName == nameof(_makeReservViewModel.StartDate) ||
                e.PropertyName == nameof(_makeReservViewModel.EndDate))
            {
                OnCanExecuteChanged();
            }
        }

    }
}
