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

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasOne<Room>()
                        .WithOne(r => r.Booking)
                        .HasForeignKey<Booking>(a => a.RoomId);
            });
        }

    }
}
