using System.Collections.Generic;
using HotelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelApp.Helpers
{
    public class HotelContext: DbContext
    {
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=hotel.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>()
                .HasOne(r => r.Booking)
                .WithOne(b => b.Room)
                .HasForeignKey<Booking>( e => e.BookingId);
        }

    }
}
