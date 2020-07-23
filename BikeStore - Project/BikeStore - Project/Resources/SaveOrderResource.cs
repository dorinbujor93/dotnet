using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Enums;

namespace BikeStore___Project.Resources
{
    public class SaveOrderResource
    {
        [Required]
        public int ShopId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BikeId { get; set; }
    }
}
