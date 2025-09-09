using HotelBookingApp.Data;
using HotelBookingApp.Model.Domain;
using HotelBookingApp.Model.DTOs;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories
{
    public class SQLHotelRepository : IHotelRepository
    {
        private readonly HotelBookingDbContext dbContext;
        public SQLHotelRepository(HotelBookingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Booking> CreateBookingAsync(Booking newBooking)
        {
            await dbContext.Bookings.AddAsync(newBooking);
            await dbContext.SaveChangesAsync();
            return newBooking;
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            
            await dbContext.Hotels.AddAsync(hotel);
            Guid guid = hotel.Id;

            for (int i = 0; i < hotel.NumberOfSingleRooms; i++)
            {
                Room room = new Room()
                {
                    Id = Guid.NewGuid(),
                    HotelId = hotel.Id,
                    RoomCapacity = 1,
                    RoomType = "Single"
                };
                await dbContext.Rooms.AddAsync(room);
            }

            for (int i = 0; i < hotel.NumberOfDoubleRooms; i++)
            {
                Room room = new Room()
                {
                    Id = Guid.NewGuid(),
                    HotelId = hotel.Id,
                    RoomCapacity = 2,
                    RoomType = "Double"
                };
                await dbContext.Rooms.AddAsync(room);
            }

            for (int i = 0; i < hotel.NumberOfDeluxRooms; i++)
            {
                Room room = new Room()
                {
                    Id = Guid.NewGuid(),
                    HotelId = hotel.Id,
                    RoomCapacity = 3,
                    RoomType = "Deluxe"
                };
                await dbContext.Rooms.AddAsync(room);
            }

            await dbContext.SaveChangesAsync();

            return hotel;
        }

        public Task<List<Booking>> GetAllRooms(RoomDto room)
        {
            throw new NotImplementedException();
        }

        public async Task<Booking?> GetBookingAsync(Guid id)
        {
            return await dbContext.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Hotel?> GetHotelAsync(string name)
        {
            return await dbContext.Hotels.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
