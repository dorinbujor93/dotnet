using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Enums;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Resources
{
    public class SaveBikeResource
    {
        [Required]
        [MaxLength(30)]
        public string Color { get; set; }
        [Required]
        public EFrameType FrameType { get; set; }
        [Required]
        public EFrameSize FrameSize { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int BikeOwnerId { get; set; }
    }
}
