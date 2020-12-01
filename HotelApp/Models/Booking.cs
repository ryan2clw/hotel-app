using System;
namespace HotelApp.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public string Guest { get; set; }

        public int RoomNumber { get; set; }

        public DateTime Date { get; set; }

        public Room BookingRoom { get; set; }
    }
}
