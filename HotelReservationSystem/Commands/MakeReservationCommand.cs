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
                MessageBox.Show("Success", "Added succusfully!", MessageBoxButton.OK);
            }
            catch ( ReservationConflictException ) 
            {
                MessageBox.Show("This room is already taken!");
            }
        }

        public MakeReservationCommand(MakeReservViewModel makeReservViewModel,
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
                e.PropertyName == nameof(_makeReservViewModel.RoomNumber))
            {
                OnCanExecuteChanged();
            }
        }

    }
}
