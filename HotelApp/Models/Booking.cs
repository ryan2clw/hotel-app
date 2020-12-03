using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelApp.Models
{
    public class Booking
    {
        [Key, ForeignKey("Room")]
        public int RoomId { get; set; }

        public string Guest { get; set; }

    }
}
