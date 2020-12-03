using System;
using Newtonsoft.Json;

namespace HotelApp.Models
{
    public class Room
    {
        [JsonIgnore]
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }

        public DateTime Date { get; set; }

        public Booking Booking { get; set; }

    }
}
