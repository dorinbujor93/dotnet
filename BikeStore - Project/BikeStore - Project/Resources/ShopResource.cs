using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BikeStore___Project.Domain.Enums;
using BikeStore___Project.Domain.Models;

namespace BikeStore___Project.Resources
{
    public class ShopResource
    {
        public int Id { get; set; }

        public string Address { get; set; }
        public string Name { get; set; }
    }
}