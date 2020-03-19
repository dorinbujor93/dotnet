using System;
using System.Collections.Generic;
using System.Text;

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
        public void PlaceOrder(string model, int price, Person customer)
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
                        Console.WriteLine("*** Congruatulations you have ordered a beautifull car! ***");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("You do not have enough money!");
            }
    
        }

        //Cancell existing order
        public void CancelOrder(Person person, string model)
        {
            foreach(Order order in orders)
            {
                if(order.Vehicle.Model == model && order.Status != "Cancelled")
                {
                    order.Status = "Cancelled";
                    person.Networth += order.Vehicle.Price;
                    Console.WriteLine("Your Order Has Been Cancelled!");
                }
                break;
            }
        }

        //Deliver car to the happy customer
        public void DeliverCarToCustomer(Person person, Vehicle vehicle)
        {
            availableVehicles.Remove(vehicle);
            person.Vehicles.Add(vehicle);
        }
    
        //Display some information about our store and it's partners
        public void ShowStoreInformation()
        {
            Console.WriteLine($"Hi, we are glad to meet you at {name}");
            Console.WriteLine($"Here you can buy vehicles  produced by {affiliateProducer.Name}");
            //Display some info about producer that store is working with
            affiliateProducer.Display();
            Console.WriteLine("------------------");
        }

        //Will display details of vehicles from producers warehouse and available nr
        public void ShowAvailableVehicles()
        {
            //Display available vehicles
            Console.WriteLine($"Available vehicles that can be bought from {name}:");
            foreach (Vehicle car in availableVehicles)
            {
                car.Display();
            }
            Console.WriteLine("------------------");
            Console.WriteLine($"*** Please note that vehicles are in producer's warehouse, it will take {affiliateProducer.WeeksForDelivery} weeks to deliver them ***");
            Console.WriteLine("------------------");
            Console.WriteLine($"Some info about {affiliateProducer.Name}:");
            affiliateProducer.Display();
        }

    }
}
