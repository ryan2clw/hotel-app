using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace HotelApp.Models
{
    public class Booking // like Address
    {
        [Key, ForeignKey("Room")]
        public int RoomId { get; set; }

        public string Guest { get; set; }

    }
}
