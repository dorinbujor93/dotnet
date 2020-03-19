using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    public class Producer : IProducer
    {
        private string country;
        private string name;
        private int founded;
        private float stockValue;
        private int weeksForDelivery;
        private List<Vehicle> availableVehicles = new List<Vehicle>();
        private Dictionary<string, Dictionary<string, int>> vehicleSpecs;


        public string Country { get => country; set => country = value; }
        public string Name { get => name; set => name = value; }
        public int Founded { get => founded; set => founded = value; }
        public float StockValue { get => stockValue; set => stockValue = value; }
        public int WeeksForDelivery { get => weeksForDelivery; set => weeksForDelivery = value; }
        public List<Vehicle> AvailableVehicles { get => availableVehicles; set => availableVehicles = value; }
        public Dictionary<string, Dictionary<string, int>> VehicleSpecs { get => vehicleSpecs; set => vehicleSpecs = value; }

        public void ProduceAVehicle(string model, string collor)
        {
            if (vehicleSpecs.ContainsKey(model))
            {
                Vehicle vehicle = new Vehicle();
                vehicle.SerialNumber = this.GenerateSerialNumber();
                vehicle.Model = model;
                vehicle.Collor = collor;
                vehicle.Year = DateTime.Now.Year.ToString();
                vehicle.HorsePower = vehicleSpecs[model]["horsePower"];
                vehicle.MaxSpeed = vehicleSpecs[model]["maxSpeed"];
                vehicle.Price = vehicleSpecs[model]["price"];
                vehicle.ProducerName = name;

                availableVehicles.Add(vehicle);
            }
            else
            {
                throw new Exception("Can't produce this model of car!");
            }

        }

        public void Display()
        {
            Console.WriteLine($"\nProducer info:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Country: {country}");
            Console.WriteLine($"Founded: {founded}");
            Console.WriteLine($"Stock value: {stockValue}");
        }

        //Will generate a serial number for produced car
        private string GenerateSerialNumber()
        {
            StringBuilder serial = new StringBuilder("FORD", 13);
            Random random = new Random();
            serial.Append(random.Next(10000, 99999));
            serial.Append(DateTime.Now.Year.ToString());

            return serial.ToString();
        }

    }
}
