using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HotelApp.Models
{
    public class Booking
    {
        [JsonIgnore]
        public int BookingId { get; set; }

        public string Guest { get; set; }

        public DateTime Date { get; set; }

        public Room Room { get; set; }
    }
}
