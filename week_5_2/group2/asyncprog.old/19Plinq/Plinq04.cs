﻿namespace _19Plinq
{
    using System;
    using System.Linq;

    public class Plinq04
    {
        public static void Run()
        {
            var orders = PlinqDataSample.GetOrders();
            var orderDetails = PlinqDataSample.GetOrderDetails();

            var q2 = orders.AsParallel()
                .Where(o => o.OrderDate < DateTime.Parse("07/04/1997"))
                .Select(o => o)
                .OrderBy(o => o.CustomerID)     // Preserve original ordering for Take operation.
                .Take(20)
                .AsUnordered()                  // Remove ordering constraint to make join faster.
                .Join(
                    orderDetails.AsParallel(),
                    ord => ord.OrderID,
                    od => od.OrderID,
                    (ord, od) =>
                        new
                        {
                            ID = ord.OrderID,
                            Customer = ord.CustomerID,
                            Product = od.ProductID
                        }
                )
                .OrderBy(i => i.Product); // Apply new ordering to final result sequence.

            foreach (var v in q2)
                Console.WriteLine("{0} {1} {2}", v.ID, v.Customer, v.Product);
        }
    }
}