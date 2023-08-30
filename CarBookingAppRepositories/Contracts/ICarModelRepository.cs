using CarBookingAppData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppRepositories.Contracts
{
    public interface ICarModelRepository : IGenericRepository<CarModel>
    {
        Task<List<CarModel>> GetCarModelsByMake(int makeId);
        Task<CarModel> GetCarModelWithDetails(int id);
        

        
    }
}
