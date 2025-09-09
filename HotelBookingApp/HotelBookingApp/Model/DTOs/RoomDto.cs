
namespace HotelBookingApp.Model.DTOs
{
    public class RoomDto
    {
        public int NumberOfGuests { get; set; }
        public DateOnly CheckInDate { get; set; }
        public DateOnly CheckOutDate { get; set; }
    }
}
