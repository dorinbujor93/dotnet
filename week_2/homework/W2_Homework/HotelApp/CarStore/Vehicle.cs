using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    public class Vehicle : IVehicle
    {
        private string model;
        private string serialNumber;
        private string collor;
        private string year;
        private int horsePower;
        private int maxSpeed;
        private decimal price;
        private string producerName;

        public string Model { get => model; set => model = value; }
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        public string Collor { get => collor; set => collor = value; }
        public string Year { get => year; set => year = value; }
        public int HorsePower { get => horsePower; set => horsePower = value; }
        public int MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
        public decimal Price { get => price; set => price = value; }
        public string ProducerName { get => producerName; set => producerName = value; }

        public void Display()
        {
            Console.WriteLine($"\nVehicle model: {model}");
            Console.WriteLine($"Produced in: {year}");
            Console.WriteLine($"Collor: {collor}");
            Console.WriteLine($"Serial Number: {serialNumber}");
            Console.WriteLine($"With {horsePower} horse powers");
            Console.WriteLine($"Can reach a maximum of {maxSpeed} km/h");
            Console.WriteLine($"Costs: {price}");
        }

    }
}
