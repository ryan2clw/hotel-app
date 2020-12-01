using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HotelApp.Models
{
    public class Room
    {
        [JsonIgnore]
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }

        [JsonIgnore]
        public Booking Booking { get; set; }

    }
}
