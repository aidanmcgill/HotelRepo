using HotelBookingApp.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Data
{
    public class HotelBookingDbContext: DbContext
    {
        public HotelBookingDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings {  get; set; }

        public DbSet<Room> Rooms { get; set; } 
    }
}
