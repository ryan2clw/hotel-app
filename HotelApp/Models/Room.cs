using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HotelApp.Models
{
    public class Room // like Person
    {
        [JsonIgnore]
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }

        public DateTime Date { get; set; }

        public Booking Booking { get; set; }

    }
}
