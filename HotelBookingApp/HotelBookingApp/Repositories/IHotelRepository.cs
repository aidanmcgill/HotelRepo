using HotelBookingApp.Model.Domain;
using HotelBookingApp.Model.DTOs;

namespace HotelBookingApp.Repositories
{
    public interface IHotelRepository
    {
        Task<Hotel?> GetHotelAsync(string hotelName);
        Task<Booking?> GetBookingAsync(Guid id);

        Task<Booking?> CreateBookingAsync(Booking newBooking);

        Task<List<Room>> GetAllRooms(RoomDto room);

        Task<Hotel> CreateHotel(Hotel hotel);

        Task<bool> CleareHotel();
    }
}
