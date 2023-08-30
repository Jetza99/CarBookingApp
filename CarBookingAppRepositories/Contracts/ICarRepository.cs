using CarBookingAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppRepositories.Contracts
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        public Task<Car> GetCarWithDetail(int id);
        public Task<List<Car>> GetCarListWithDetails();
    }
}
