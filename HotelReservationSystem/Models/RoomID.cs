using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelReservationSystem.Models
{
    public class RoomID
    {
        public int RoomNumber { get; }
        public int FloorNumber { get; }

        public RoomID(int floorNumber, int roomNumber)
        {
            RoomNumber = floorNumber;
            FloorNumber = roomNumber;
        }

        public override string ToString()
        {
            return $"{FloorNumber}_{RoomNumber}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RoomNumber, FloorNumber);
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return ((RoomID)obj).RoomNumber == RoomNumber
                && ((RoomID)obj).FloorNumber == FloorNumber;
        }

        public static bool operator ==(RoomID roomID1, RoomID roomID2)
        {
            if (ReferenceEquals(roomID1, roomID2))
            {
                return true;
            }

            if (roomID1 is null || roomID2 is null)
            {
                return false;
            }

            return roomID1.Equals(roomID2);
        }

        public static bool operator !=(RoomID roomID1, RoomID roomID2)
        {
            return !(roomID1 == roomID2);
        }

    }
}
