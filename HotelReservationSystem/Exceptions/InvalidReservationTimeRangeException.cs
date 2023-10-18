using HotelReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Exceptions
{
    public class InvalidReservationTimeRangeException : Exception
    {
        public Reservation _reservation { get; }
        public InvalidReservationTimeRangeException(Reservation reservation) 
        {
            _reservation = reservation;
        }

    }
}
