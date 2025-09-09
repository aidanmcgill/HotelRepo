using HotelBookingApp.Data;
using HotelBookingApp.Model.Domain;
using HotelBookingApp.Model.DTOs;
using HotelBookingApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly HotelBookingDbContext dbcontext;
        private readonly IHotelRepository hotelRepository;
        public BookingController(HotelBookingDbContext dbContext, IHotelRepository hotelRepository)
        {
            this.dbcontext = dbContext;
            this.hotelRepository = hotelRepository;
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBooking([FromRoute] Guid id)
        {
            var bookingDomain = await hotelRepository.GetBookingAsync(id);

            if (bookingDomain == null)
            {
                return NotFound();
            }

            var hotelDto = new BookingDto
            {
                Hotel = bookingDomain.Hotel,
                CheckInDate = bookingDomain.CheckInDate,
                CheckOutDate = bookingDomain.CheckOutDate,
                RoomId = bookingDomain.RoomId,
                NumberOfGuests = bookingDomain.NumberOfGuests,
                NameOnBooking = bookingDomain.NameOnBooking,
            };

            return Ok(hotelDto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody] CreateBookingDto createBookingDto)
        {
            var BookingDomain = new Booking
            {
                Hotel = createBookingDto.Hotel,
                RoomId = createBookingDto.RoomId,
                CheckInDate = createBookingDto.CheckInDate,
                CheckOutDate = createBookingDto.CheckOutDate,
                NumberOfGuests = createBookingDto.NumberOfGuests,
                NameOnBooking = createBookingDto.NameOnBooking,
            };

            BookingDomain = await hotelRepository.CreateBookingAsync(BookingDomain);
            if (BookingDomain == null) { return NotFound(); }
            var BookingDto = new BookingDto
            {
                Id = BookingDomain.Id,
                Hotel = BookingDomain.Hotel,
                RoomId = BookingDomain.RoomId,
                CheckInDate = BookingDomain.CheckInDate,
                CheckOutDate = BookingDomain.CheckOutDate,
                NameOnBooking = BookingDomain.NameOnBooking,
                NumberOfGuests = BookingDomain.NumberOfGuests,
            };
            return CreatedAtAction(nameof(GetBooking), new { id = BookingDomain.Id }, BookingDto);
        }
    }
}
