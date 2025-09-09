using HotelBookingApp.Data;
using HotelBookingApp.Model.Domain;
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
        public async Task<IActionResult> GetHotel([FromRoute] string name)
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
        public async Task<IActionResult> GetRooms()
        {
            var room = new RoomDto
            {
                NumberOfGuests = 2,
                CheckInDate = new DateOnly(2025,10,1),
                CheckOutDate = new DateOnly(2025, 10, 4)
            };

            return Ok();
        }

        
        
        
    }
}
