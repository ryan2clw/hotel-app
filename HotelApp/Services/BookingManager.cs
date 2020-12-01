using System;
using System.Threading.Tasks;
using HotelApp.Models;

namespace HotelApp.Services
{
    public class BookingManager : IBookingManager
    {
        public void AddBooking(string guest, int room, DateTime date)
        {
            var booking = new Booking()
            {
                Guest = guest,
                Room = room,
                Date = date
            };
            // STUB FOR SAVING TO DB
            Task<Booking> asyncBookingTask = Task.FromResult(booking);
            Console.WriteLine(asyncBookingTask.Result);
            return;
        }
        public bool IsRoomAvailable(int room, DateTime date)
        {
            // MARK TO DO: CHECK DB
            return true;
        }
    }
}
