using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelApp.Helpers;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

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
            var room = _context.Rooms.Where(r =>
                r.RoomNumber == roomNumber
                && r.Date.Date == date.Date
                && r.Booking == null).FirstOrDefault();
            if(room == null)
            {
                throw new Exception("We could not find an available room for that date");
            }
            var booking = new Booking()
            {
                Guest = guest,
                RoomId = room.RoomId
            };
            _context.Bookings.Add(booking);
            room.Booking = booking;
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
            return "OK";
        }
        public bool IsRoomAvailable(int room, DateTime date)
        {
            var roomInQuestion = _context.Rooms.Where(r =>
                    r.RoomNumber == room
                    && r.Date.Date == date.Date
                    && r.Booking == null
                ).FirstOrDefault();
            return roomInQuestion != null;
        }
        private void SeedDataBase()
        {
            // 3 floors with 32 rooms, set to todays date
            for(var i = 1; i < 4; i++)
            {
                var roomNumber = 100 * i;
                for(var j = 1; j < 33; j++)
                {
                    Room room = new Room() { RoomNumber = roomNumber + j, Date = DateTime.Now };
                    _context.Rooms.Add(room);
                }
            }
            _context.SaveChanges();
        }
        public IEnumerable<int> GetAvailableRooms(DateTime date)
        {

            List<Room> rooms = _context.Rooms
                                    .Include(a => a.Booking)
                                        .Where(r => r.Booking == null && r.Date.Date == date.Date)
                                            .OrderBy(r => r.RoomNumber).ToList();
            var availableRooms = rooms.Select(r => r.RoomNumber).ToList();
            if(availableRooms.Count == 0)
            {
                SeedDataBase();
                rooms = _context.Rooms
                            .Include(a => a.Booking)
                                .Where(r => r.Booking == null && r.Date.Date == date.Date)
                                    .OrderBy(r => r.RoomNumber).ToList();
            }
            return rooms.Select(r => r.RoomNumber).ToList();
        }
    }
}
