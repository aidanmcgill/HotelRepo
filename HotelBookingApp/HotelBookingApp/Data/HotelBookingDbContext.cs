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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model here if needed
            base.OnModelCreating(modelBuilder);

            var hotel = new List<Hotel>()
            {
                new Hotel
                {
                    Id = Guid.Parse("727c5798-5771-43ca-9401-0ff3aed2d8c5"),
                    Name = "Glasgow Hotel",
                    NumberOfSingleRooms = 2,
                    NumberOfDoubleRooms = 2,
                    NumberOfDeluxRooms = 2
                }
            };

            modelBuilder.Entity<Hotel>().HasData(hotel);

            var room = new List<Room>()
            {
                new Room
                {
                    Id = Guid.Parse("6528d02b-23de-4eba-8321-26321614394d"),
                    HotelId = Guid.Parse("727c5798-5771-43ca-9401-0ff3aed2d8c5"),
                    RoomType = "Single",
                    RoomCapacity =1
                },
                new Room
                {
                    Id = Guid.Parse("959d8519-e10f-4c83-81a4-b4849878d51c"),
                    HotelId = Guid.Parse("727c5798-5771-43ca-9401-0ff3aed2d8c5"),
                    RoomType = "Single",
                    RoomCapacity =1
                },
                new Room
                {
                    Id = Guid.Parse("bc4af3da-8e0b-49b1-9b00-8503ba54d4e1"),
                    HotelId = Guid.Parse("727c5798-5771-43ca-9401-0ff3aed2d8c5"),
                    RoomType = "Double",
                    RoomCapacity = 2
                },
                new Room
                {
                    Id = Guid.Parse("c2bc905b-b3ef-4c1f-a53d-68ec36c00840"),
                    HotelId = Guid.Parse("727c5798-5771-43ca-9401-0ff3aed2d8c5"),
                    RoomType = "Double",
                    RoomCapacity = 2
                },
                new Room
                {
                    Id = Guid.Parse("b30a4802-1e53-437c-9ec9-0e135769b0fa"),
                    HotelId = Guid.Parse("727c5798-5771-43ca-9401-0ff3aed2d8c5"),
                    RoomType =  "Deluxe",
                    RoomCapacity = 3
                },
                new Room
                {
                    Id = Guid.Parse("f8d4b0ad-157a-4b7c-83b9-625a0c7f5e4b"),
                    HotelId = Guid.Parse("727c5798-5771-43ca-9401-0ff3aed2d8c5"),
                    RoomType =  "Deluxe",
                    RoomCapacity = 3
                }
            };

            modelBuilder.Entity<Room>().HasData(room);
        }
    }
}
