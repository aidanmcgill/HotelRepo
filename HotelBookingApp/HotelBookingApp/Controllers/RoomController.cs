using HotelBookingApp.Data;
using HotelBookingApp.Model.DTOs;
using HotelBookingApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly HotelBookingDbContext dbcontext;
        private readonly IHotelRepository hotelRepository;
        public RoomController(HotelBookingDbContext dbContext, IHotelRepository hotelRepository)
        {
            this.dbcontext = dbContext;
            this.hotelRepository = hotelRepository;
        }

        [HttpGet]
        [Route("{NumberOfGuests}/{CheckInDate}/{CheckOutDate}")]
        public async Task<IActionResult> GetRooms([FromRoute] int NumberOfGuests, DateOnly CheckInDate, DateOnly CheckOutDate)
        {
            var room = new RoomDto
            {
                NumberOfGuests = NumberOfGuests,
                CheckInDate = CheckInDate,
                CheckOutDate = CheckOutDate
            };
            var hotelDomain = await hotelRepository.GetAllRooms(room);

            return Ok(hotelDomain);
        }
    }
}
