using HotelBookingApp.Data;
using HotelBookingApp.Model.DTOs;
using HotelBookingApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClearController : ControllerBase
    {

        private readonly HotelBookingDbContext dbcontext;
        private readonly IHotelRepository hotelRepository;
        public ClearController(HotelBookingDbContext dbContext, IHotelRepository hotelRepository)
        {
            this.dbcontext = dbContext;
            this.hotelRepository = hotelRepository;
        }



        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            await hotelRepository.CleareHotel();


            return Ok();
        }


    }
}
