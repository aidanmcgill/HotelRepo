using HotelBookingApp.Model.Domain;

namespace HotelBookingApp.Repositories
{
    public interface IHotelRepository
    {
        Task<Hotel?> GetHotelAsync(string hotelName);
        Task<Booking?> GetBookingAsync(Guid id);

        Task<Booking> CreateBookingAsync(Booking newBooking);
    }
}
