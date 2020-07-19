using System.ComponentModel.DataAnnotations;
using BikeStore___Project.Domain.Enums;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Resources
{
    public class AccessoryResource
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public BikeResource Bike { get; set; }
        public EAccessoryType AccessoryType { get; set; }

    }
}