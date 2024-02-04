using HotelReservationSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    public class Hotel
    {
        public string Name { get; }
        public string Addresss { get; }

        // This is readonly because we'll have some functions to modify it
        private readonly ReservationBook _reservationBook;
        public Hotel(string name, string address)
        {
            Name = name;
            Addresss = address;
            _reservationBook = new ReservationBook();
        }

        public IEnumerable<Reservation>? GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }

        public void AddReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            _reservationBook.DeleteReservation(reservation);
        }
    }
}
