using System.Collections.Generic;
using BikeStore___Project.Data.Entities;
using BikeStore___Project.Domain.Enums;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData
            (
                new Category {Id = 1, Name = "Road Bike"},
                new Category {Id = 2, Name = "Mountain Bike"},
                new Category {Id = 3, Name = "Touring Bike"}
            );


            builder.Entity<Bike>().HasData
            (
                new Bike
                {
                    Id = 1,
                    FrameType = EFrameType.Aluminum,
                    FrameSize = EFrameSize.Medium,
                    Color = "Red",
                    CategoryId = 1
                },
                new Bike
                {
                    Id = 2,
                    FrameType = EFrameType.Steel,
                    FrameSize = EFrameSize.Medium,
                    Color = "Yellow",
                    CategoryId = 2
                },
                new Bike
                {
                    Id = 3,
                    FrameType = EFrameType.Carbon,
                    FrameSize = EFrameSize.Medium,
                    Color = "Gray",
                    CategoryId = 3
                }
            );
        }
    }
}