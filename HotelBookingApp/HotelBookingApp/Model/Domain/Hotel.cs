namespace HotelBookingApp.Model.Domain
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int NumberOfSingleRooms { get; set; }

        public int NumberOfDoubleRooms { get; set; }

        public int NumberOfDeluxRooms { get; set; }
    }
}
