using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelApp.Models;

namespace HotelApp.Services
{
    public interface IBookingManager
    {
        /**
         * Return true if there is no booking for the given room on the date,
         * otherwise false
         */
        bool IsRoomAvailable(int room, DateTime date);
        /**
        * Add a booking for the given guest in the given room on the given * date. If the room is not available, throw a suitable Exception. */
        public Task<string> AddBooking(string guest, int room, DateTime date);

        /**
         * Return a list of all the available room numbers for the given date
         */
        IEnumerable<Room> GetAvailableRooms(DateTime date);

        /**
         * Since I'm not using SQL SERVER I'll use an endpoint to check my work
         */
        IEnumerable<Booking> GetAllBookings();

        public IEnumerable<Room> GetAllRooms();

    }
}
