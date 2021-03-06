﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Enums;
using BikeStore___Project.Resources;

namespace BikeStore___Project.Domain.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}