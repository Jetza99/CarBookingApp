using CarBookingAppData;
using CarBookingAppRepositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppRepositories.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly CarBookingAppDbContext _context;
        public CarRepository(CarBookingAppDbContext _context) : base(_context)
        {
            this._context = _context;
        }

        public async Task<List<Car>> GetCarListWithDetails()
        {
            return await _context.Cars
                        .Include(q => q.Make)
                        .Include(q => q.Color)
                        .Include(q => q.CarModel)
                        .ToListAsync();
                        }

        public async Task<Car> GetCarWithDetail(int id)
        {
            return await _context.Cars
                        .Include(q => q.Make)
                        .Include(q => q.Color)
                        .Include(q => q.CarModel)
                        .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
