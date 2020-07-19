using BikeStore___Project.Data.Entities;
using BikeStore___Project.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStore___Project.Data.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
    }
}