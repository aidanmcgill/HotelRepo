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
    public class HotelDevController : ControllerBase
    {
        private readonly HotelBookingDbContext dbcontext;
        private readonly IHotelRepository hotelRepository;
        public HotelDevController(HotelBookingDbContext dbContext, IHotelRepository hotelRepository)
        {
            this.dbcontext = dbContext;
            this.hotelRepository = hotelRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDto createHotelDto)
        {
            var hotelDomain = new Hotel
            {
                Name = createHotelDto.Name,
                NumberOfDeluxRooms = createHotelDto.NumberOfDeluxRooms,
                NumberOfDoubleRooms = createHotelDto.NumberOfDoubleRooms,
                NumberOfSingleRooms = createHotelDto.NumberOfSingleRooms,
            };

            hotelDomain = await hotelRepository.CreateHotel(hotelDomain);

            var hotelDto = new HotelDto
            {

                Name = hotelDomain.Name,
                NumberOfSingleRooms = hotelDomain.NumberOfSingleRooms,
                NumberOfDoubleRooms = hotelDomain.NumberOfDoubleRooms,
                NumberOfDeluxRooms = hotelDomain.NumberOfDeluxRooms

            };
            return Ok(hotelDto);

        }
    }
}
