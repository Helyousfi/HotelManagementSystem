using HotelReservationSystem.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    /// <summary>
    /// A class that contains all the reservations 
    /// </summary>
    public class ReservationBook
    {
        public List<Reservation>? reservations { get; }
        public ReservationBook() 
        {
            reservations = new List<Reservation>();
        }

        /// <summary>
        /// Function to get all the reservations 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return reservations;
        }

        /// <summary>
        /// Add a reservation to the reservation list
        /// </summary>
        /// <param name="reservation"></param>
        public void AddReservation(Reservation reservation)
        {
            if(reservation.StartTime > reservation.EndTime)
            {
                throw new InvalidReservationTimeRangeException(reservation);
            }
            reservations?.Add(reservation);
        }
    }
}
