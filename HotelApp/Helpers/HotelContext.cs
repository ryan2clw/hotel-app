using System.Collections.Generic;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Helpers
{
    public class HotelContext: DbContext
    {
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=hotel.db");

    }
}
