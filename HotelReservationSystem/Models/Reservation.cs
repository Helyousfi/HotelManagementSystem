using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; }
        public DateTime StartTime { get; }
        public DateTime EndTime { get; }
        public string Username { get; }

        public Reservation(RoomID roomID, DateTime startTime, DateTime endTime, string username)
        {
            RoomID = roomID;
            StartTime = startTime;
            EndTime = endTime;
            Username = username;
        }

        public bool Conflict(Reservation reservation)
        {
            if (reservation.RoomID == RoomID)
            {
                return false;
            }
            if (reservation.StartTime >= StartTime && reservation.StartTime <= EndTime ||
                reservation.EndTime <= EndTime && reservation.EndTime >= StartTime)
            {
                return true;
            }
            return false;
        }
        
    }
}
