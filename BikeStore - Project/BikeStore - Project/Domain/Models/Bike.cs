using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Enums;
using BikeStore___Project.Domain.Models;

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
        public EFrameType FrameType { get; set; }
        public EFrameSize FrameSize { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
