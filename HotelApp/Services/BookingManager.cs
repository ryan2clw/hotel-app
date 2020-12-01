using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApp.Helpers;
using HotelApp.Models;

namespace HotelApp.Services
{
    public class BookingManager : IBookingManager
    {
        private HotelContext _context;

        public BookingManager(HotelContext context)
        {
            _context = context;
        }
        public void AddBooking(string guest, int room, DateTime date)
        {
            var booking = new Booking()
            {
                Guest = guest,
                Room = room,
                Date = date
            };
            // STUB FOR SAVING TO DB
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return;
        }
        public bool IsRoomAvailable(int room, DateTime date)
        {
            // MARK TO DO: CHECK DB
            return true;
        }
        public IEnumerable<Booking> GetAllBookings()
        {
            Booking[] bookings = _context.Bookings.ToArray();
            return bookings;
        }

    }
}
