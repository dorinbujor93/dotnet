using BikeStore___Project.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BikeStore___Project.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
    }
}