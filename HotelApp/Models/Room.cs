using System;
namespace HotelApp.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }
    }
}
