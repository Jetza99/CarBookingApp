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
    public class CarModelRepository : GenericRepository<CarModel>, ICarModelRepository
    {
        private readonly CarBookingAppDbContext _context;
        public CarModelRepository(CarBookingAppDbContext _context) : base(_context)
        {
               this._context = _context;
        }
        public async Task<List<CarModel>> GetCarModelsByMake(int makeId)
        {
            var models = await _context.CarModels
                .Where(q => q.MakeId == makeId)
                .ToListAsync();
            return models;
        }

        public Task<CarModel> GetCarModelWithDetails(int id)
        {
            return _context.CarModels.Include(q => q.Make).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
