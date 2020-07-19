using System.ComponentModel.DataAnnotations;
using BikeStore___Project.Domain.Enums;

namespace BikeStore___Project.Domain.Models
{
    public class Accessory
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public Bike Bike { get; set; }
        public int BikeId { get; set; }

        public EAccessoryType AccessoryType { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
