using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingAppData
{
    public class CarBookingAppDbContext : DbContext
    {
       
        public CarBookingAppDbContext(DbContextOptions<CarBookingAppDbContext> options) 
            : base(options)
        {
        }
        
            
        public DbSet<Car> Cars { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Color> Colors { get; set; }


    }
    public class CarBookingAppDbContextFactory : IDesignTimeDbContextFactory<CarBookingAppDbContext>
    {
        public CarBookingAppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarBookingAppDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new CarBookingAppDbContext(optionsBuilder.Options);
        }
    }

}
