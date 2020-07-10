using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Data.Entities;

namespace SaddleStore___Project.Resources
{
    public class AccessoryResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }

    }

    public static class SaddleResourceExtensions
    {
        public static Accessory MapToEntity(this AccessoryResource accessory)
        {
            return new Accessory
            {
                Brand = accessory.Brand,
                Name = accessory.Name,
                Weight = accessory.Weight,
                Id = accessory.Id
            };
        }

        public static AccessoryResource MapToResource(this Accessory accessory)
        {
            return new AccessoryResource
            {
                Brand = accessory.Brand,
                Name = accessory.Name,
                Weight = accessory.Weight,
                Id = accessory.Id
            };
        }

    }
}