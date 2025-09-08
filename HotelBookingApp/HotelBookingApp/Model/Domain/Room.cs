namespace HotelBookingApp.Model.Domain
{
    public class Room
    {
        public int Id { get; set; }
        public Guid HotelId { get; set; }

        public string RoomType { get; set; }

        public int RoomCapacity { get; set; }
    }
}
