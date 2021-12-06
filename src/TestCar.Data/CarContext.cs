using Microsoft.EntityFrameworkCore;
using TestCar.Data.Models;

namespace TestCar.Data
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {
        }

        public DbSet<CarEntity> Cars { get; set; }
    }
}