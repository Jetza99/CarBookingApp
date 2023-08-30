using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBookingAppData;


namespace CarBookingAppRepositories.Contracts
{
    public interface IGenericRepository<TEntity> where TEntity : BaseDomainEntity
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task<bool> Exists(int id);
        Task Insert(TEntity entity);
        Task Delete(int id);
        Task Update(TEntity entity);
        Task<int> SaveChanges();
    }
}
