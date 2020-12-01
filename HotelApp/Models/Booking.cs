using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApp.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public string Guest { get; set; }

        public DateTime Date { get; set; }

        public Room Room { get; set; }
    }
}
