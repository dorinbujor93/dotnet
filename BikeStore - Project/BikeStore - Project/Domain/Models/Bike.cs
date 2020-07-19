﻿using System.ComponentModel.DataAnnotations;
using BikeStore___Project.Domain.Enums;

namespace BikeStore___Project.Domain.Models
{
    public class Bike
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public EFrameType FrameType { get; set; }
        public EFrameSize FrameSize { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
