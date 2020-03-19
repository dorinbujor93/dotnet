using System;
using System.Collections.Generic;
using System.Text;
using static CarStore.Logging.LogHelper;

namespace CarStore
{
    public class Store : IStore
    {
        private string city;
        private string name;
        private Producer affiliateProducer;
        private List<Vehicle> availableVehicles = new List<Vehicle>();
        private List<Order> orders = new List<Order>();

        public string City { get => city; set => city = value; }
        public string Name { get => name; set => name = value; }
        public List<Vehicle> AvailableVehicles { get => availableVehicles; set => availableVehicles = value; }
        public Producer AffiliateProducer { get => affiliateProducer; set => affiliateProducer = value; }
        public List<Order> Orders { get => orders; set => orders = value; }

        //Order a car
        public bool PlaceOrder(string model, int price, Person customer)
        {
            if (customer.Networth > price)
            {
                foreach (Vehicle car in availableVehicles)
                {
                    if (car.Model == model && car.Price == price)
                    {

                        Order order = new Order();
                        order.FillOrderData(this, customer, car);
                        Orders.Add(order);
                        order.Display();
                        customer.Networth -= car.Price;
                        customer.TimeToWait = affiliateProducer.WeeksForDelivery;
                        Log(LogTarget.File, "*** Congruatulations you have ordered a beautifull car! ***");
                        return true;
                    }
                }
            }
            else
            {
                Log(LogTarget.File, "You do not have enough money!");
            }
            return false;
        }

        //Cancell existing order
        public bool CancelOrder(Person person, string model)
        {
            foreach (Order order in orders)
            {
                if (order.Vehicle.Model == model && order.Status != "Cancelled")
                {
                    order.Status = "Cancelled";
                    person.Networth += order.Vehicle.Price;
                    Log(LogTarget.File, "Your Order Has Been Cancelled!");
                    return true;
                }
            }
            return false;
        }

        //Deliver car to the happy customer
        public void DeliverCarToCustomer(Person person)
        {
            foreach (Order order in orders)
            {
                if (order.CustomerName == person.Name)
                {
                    Vehicle car = order.Vehicle;
                    availableVehicles.Remove(car);
                    person.Vehicles.Add(car);
                    Log(LogTarget.File, "Your Order Has Been Delivered!");
                    break;
                }
            }
        }

        //Display some information about our store and it's partners
        public void ShowStoreInformation()
        {
            Log(LogTarget.File, $"Hi, we are glad to meet you at {name}");
            Log(LogTarget.File, $"Here you can buy vehicles  produced by {affiliateProducer.Name}");
            //Display some info about producer that store is working with
            affiliateProducer.Display();
            Log(LogTarget.File, "------------------");
        }

        //Will display details of vehicles from producers warehouse and available nr
        public void ShowAvailableVehicles()
        {
            //Display available vehicles
            Log(LogTarget.File, $"Available vehicles that can be bought from {name}:");
            foreach (Vehicle car in availableVehicles)
            {
                car.Display();
            }
            Log(LogTarget.File, "------------------");
            Log(LogTarget.File, $"*** Please note that vehicles are in producer's warehouse, it will take {affiliateProducer.WeeksForDelivery} weeks to deliver them ***");
            Log(LogTarget.File, "------------------");
            Log(LogTarget.File, $"Some info about {affiliateProducer.Name}:");
            affiliateProducer.Display();
        }

    }
}
