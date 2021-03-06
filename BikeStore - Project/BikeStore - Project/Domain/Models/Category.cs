﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore___Project.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Bike> Bikes { get; set; } = new List<Bike>();
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
