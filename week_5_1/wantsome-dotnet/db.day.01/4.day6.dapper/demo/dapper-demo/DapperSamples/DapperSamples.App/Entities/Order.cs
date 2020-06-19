﻿using System;

namespace DapperSamples.App.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
