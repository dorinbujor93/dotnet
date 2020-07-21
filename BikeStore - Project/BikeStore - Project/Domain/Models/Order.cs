using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Enums;
using BikeStore___Project.Resources;

namespace BikeStore___Project.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public int UserId { get; set; }
        public int BikeId { get; set; }

        public DateTime LastModified { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}