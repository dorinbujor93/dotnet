using System.Collections.Generic;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Accessory> Accessories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData
            (
                new Category { Id = 1, Name = "Road Bike" },
                new Category { Id = 2, Name = "Mountain Bike" },
                new Category { Id = 3, Name = "Touring Bike" }
            );

            builder.Entity<User>().HasData
            (
                new User
                {
                    Id = 1,
                    FirstName = "Mike",
                    LastName = "Ekim",
                    Gender = EGender.Male,
                    Role = EUserRoles.Staff,
                    Email = "mike@mail.com",
                    Username = "mike.ekim"
                },
                new User
                {
                    Id = 2,
                    FirstName = "Sally",
                    LastName = "Harry",
                    Gender = EGender.Female,
                    Role = EUserRoles.Customer,
                    Email = "sally@mail.com",
                    Username = "sally.harry"
                },
                new User
                {
                    Id = 3,
                    FirstName = "Harry",
                    LastName = "Sally",
                    Gender = EGender.Male,
                    Role = EUserRoles.Customer,
                    Email = "harry@mail.com",
                    Username = "harry.sally"
                }
            );

            builder.Entity<Bike>().HasData
            (
                new Bike
                {
                    Id = 1,
                    FrameType = EFrameType.Aluminum,
                    FrameSize = EFrameSize.Medium,
                    Color = "Red",
                    BikeOwnerId = 2,
                    CategoryId = 1
                },
                new Bike
                {
                    Id = 2,
                    FrameType = EFrameType.Steel,
                    FrameSize = EFrameSize.Medium,
                    Color = "Yellow",
                    BikeOwnerId = 2,
                    CategoryId = 2
                },
                new Bike
                {
                    Id = 3,
                    FrameType = EFrameType.Carbon,
                    FrameSize = EFrameSize.Medium,
                    Color = "Gray",
                    BikeOwnerId = 3,
                    CategoryId = 3
                }
            );


            builder.Entity<Accessory>().HasData
            (
                new Accessory()
                {
                    Id = 1,
                    Brand = "Shimano",
                    Name = "Altus",
                    Weight = 100,
                    BikeId = 1,
                    AccessoryType = EAccessoryType.Cyclocomputer
                },
                new Accessory()
                {
                    Id = 2,
                    Brand = "Kring",
                    Name = "Lighting",
                    Weight = 10,
                    BikeId = 2,
                    AccessoryType = EAccessoryType.FrontLight
                },
                new Accessory()
                {
                    Id = 3,
                    Brand = "Smith",
                    Name = "Ringer",
                    Weight = 15,
                    BikeId = 2,
                    AccessoryType = EAccessoryType.Bell
                }
            );
        }
    }
}