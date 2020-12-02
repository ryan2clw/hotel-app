using System;
namespace HotelApp.Models
{
    public class RoomRequest
    {
        public int RoomNumber { get; set; }

        public string Guest { get; set; }

        public DateTime Date { get; set; }
    }
}
