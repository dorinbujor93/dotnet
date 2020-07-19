using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Data.Entities
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

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
