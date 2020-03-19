using System;
using System.Collections.Generic;
using System.Text;
using static CarStore.Logging.LogHelper;

namespace CarStore
{
    public class Order : IOrder
    {
        private int id;
        private string status;
        private int weeksToDeliver;
        private string customerName;
        private Vehicle vehicle;
        private Store store;

        public int Id { get => id; set => id = value; }
        public int WeeksToDeliver { get => weeksToDeliver; set => weeksToDeliver = value; }
        public string Status { get => status; set => status = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public Vehicle Vehicle { get => vehicle; set => vehicle = value; }
        public Store Store { get => store; set => store = value; }

    
        //Display order information
        public void Display()
        {
            Log(LogTarget.File, $"\n-----------------ORDER---------------------");
            Log(LogTarget.File, $"\n*** Order information: ***");
            Log(LogTarget.File, $"Order ID: {id}");
            Log(LogTarget.File, $"Status: {status}");
            Log(LogTarget.File, $"Weeks till delivery: {weeksToDeliver}");
            Log(LogTarget.File, $"Customer Name: {customerName}");
            Log(LogTarget.File, $"Product bought:{vehicle.Model}");
            vehicle.Display();
            Log(LogTarget.File, $"\n-----------------ORDER---------------------");
        }

        //Fill order information
        public void FillOrderData(Store store,Person customer, Vehicle car)
        {
            this.store = store;
            status = "Pending";
            weeksToDeliver = store.AffiliateProducer.WeeksForDelivery;
            vehicle = car;
            customerName = customer.Name;
            id = GenerateIdentifier();
        }

        //Generate an identifier for the order
        private int GenerateIdentifier()
        {
            Random random = new Random();
            return random.Next(10000, 999999999);
        }
    }
}
