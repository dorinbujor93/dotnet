using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore___Project.Data.Entities
{
    public class Bike
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Type { get; set; }
        public string Color { get; set; }
        public IList<Accessory> Accessories { get; set; }

    }
}
