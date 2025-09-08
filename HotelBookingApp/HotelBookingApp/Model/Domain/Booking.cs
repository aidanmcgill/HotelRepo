
namespace HotelBookingApp.Model.Domain
{
    public class Booking
    {
        public Guid Id { get; set; }
        public required string Hotel { get; set; }
        public Guid RoomId { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public required string NameOnBooking { get; set; }

    }
}
