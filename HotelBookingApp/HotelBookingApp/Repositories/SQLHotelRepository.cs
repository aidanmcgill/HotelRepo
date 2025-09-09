using HotelBookingApp.Data;
using HotelBookingApp.Model.Domain;
using HotelBookingApp.Model.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HotelBookingApp.Repositories
{
    public class SQLHotelRepository : IHotelRepository
    {
        private readonly HotelBookingDbContext dbContext;
        public SQLHotelRepository(HotelBookingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CleareHotel()
        {
            var booking = await dbContext.Bookings.ToListAsync();
            dbContext.Bookings.RemoveRange(booking);

            var rooms = await dbContext.Rooms.ToListAsync();
            dbContext.Rooms.RemoveRange(rooms);

            var hotels = await dbContext.Hotels.ToListAsync();
            dbContext.Hotels.RemoveRange(hotels);

            await dbContext.SaveChangesAsync();
            return true;


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

        public async Task<List<Room>> GetAllRooms(RoomDto newRoom)
        {
            var bookings = await dbContext.Bookings.Where(x =>
                (newRoom.CheckInDate >= x.CheckInDate && newRoom.CheckInDate < x.CheckOutDate) ||
                (newRoom.CheckOutDate > x.CheckInDate && newRoom.CheckOutDate <= x.CheckOutDate)
            ).ToListAsync();

            List<Guid> BookingRoomIds = bookings
                .Select(b => b.RoomId)
                .Distinct()
                .ToList();
            List<Room> roooms = await dbContext.Rooms.ToListAsync();
            List<Room> avalableRooms = new List<Room>();

            foreach(Room room in roooms)
            {
                if(!BookingRoomIds.Contains(room.Id) && newRoom.NumberOfGuests <= room.RoomCapacity)
                {
                    avalableRooms.Add(room);
                }
            }

            return avalableRooms;
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
