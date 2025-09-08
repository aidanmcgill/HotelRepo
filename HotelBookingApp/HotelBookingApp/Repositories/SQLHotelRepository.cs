using HotelBookingApp.Data;
using HotelBookingApp.Model.Domain;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingApp.Repositories
{
    public class SQLHotelRepository : IHotelRepository
    {
        private readonly HotelBookingDbContext dbContext;
        public SQLHotelRepository(HotelBookingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Hotel?> GetHotelAsync(string name)
        {
            return await dbContext.Hotels.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
