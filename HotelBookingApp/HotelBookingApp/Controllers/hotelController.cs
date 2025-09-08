using HotelBookingApp.Data;
using HotelBookingApp.Model.DTOs;
using HotelBookingApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelBookingDbContext dbcontext;
        private readonly IHotelRepository hotelRepository;
        public HotelController(HotelBookingDbContext dbContext, IHotelRepository hotelRepository)
        {
            this.dbcontext = dbContext;
            this.hotelRepository = hotelRepository;
        }

        [HttpGet]
        [Route("{name}")]
        public async Task<IActionResult> GetHotels([FromRoute] string name)
        {
            var hotelDomain = await hotelRepository.GetHotelAsync(name);

            if (hotelDomain == null)
            {
                return NotFound();
            }

            var hotelDto = new HotelDto
            {
                Name = hotelDomain.Name,
                NumberOfSingleRooms = hotelDomain.NumberOfSingleRooms,
                NumberOfDoubleRooms = hotelDomain.NumberOfDoubleRooms,
                NumberOfDeluxRooms = hotelDomain.NumberOfDeluxRooms
            };

            return Ok(hotelDto);
           
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
    }
}
