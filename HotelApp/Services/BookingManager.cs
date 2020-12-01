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
        public async Task<string> AddBooking(string guest, int roomNumber, DateTime date)
        {
            var room = _context.Rooms.Where(r => r.RoomNumber == roomNumber).FirstOrDefault();

            var booking = new Booking()
            {
                Guest = guest,
                Room = room,
                Date = date
            };
            _context.Bookings.Add(booking);
            room.Booking = booking;
            await _context.SaveChangesAsync();
            return "OK";
        }
        public bool IsRoomAvailable(int room, DateTime date)
        {
            // MARK TO DO: CHECK DB
            return true;
        }
        private void SeedDataBase()
        {
            //List<Room> rooms = new List<Room>();
            for(var i = 1; i < 100; i++)
            {
                Room room = new Room() { RoomNumber = i };
                //rooms.Add(room);
                _context.Rooms.Add(room);
            }
            //_context.Rooms.AddRange(rooms);
            _context.SaveChanges();
        }
        public IEnumerable<Booking> GetAllBookings()
        {
            Booking[] bookings = _context.Bookings.ToArray();
            List<Room> rooms = _context.Rooms.ToList();
            if (rooms.Count == 0)
            {
                SeedDataBase();
            }
            return bookings;
        }
        public IEnumerable<Room> GetAllRooms()
        {
            List<Room> rooms = _context.Rooms.OrderBy(r=>r.RoomNumber).ToList();
            if (rooms.Count == 0)
            {
                SeedDataBase();
            }
            return rooms;
        }

    }
}
