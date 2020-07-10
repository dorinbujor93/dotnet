using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Data.Entities;

namespace BikeStore___Project.Resources
{
    public class BikeResource
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }
        public string Color { get; set; }
    }

    public static class BikeResourceExtensions
    {
        public static Bike MapToEntity(this BikeResource bike)
        {
            return new Bike
            {
                Color = bike.Color,
                Type = bike.Type,
                Id = bike.Id
            };
        }

        public static BikeResource MapToResource(this Bike bike)
        {
            return new BikeResource
            {
                Color = bike.Color,
                Type = bike.Type,
                Id = bike.Id
            };
        }

    }
}

