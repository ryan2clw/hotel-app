using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelApp.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public int RoomNumber { get; set; }

        public Booking Booking { get; set; }

    }
}
