using System;
using System.Collections.Generic;
using System.Text;
using static CarStore.Logging.LogHelper;

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

        //Will display vehicle information
        public void Display()
        {
            Log(LogTarget.File, $"\nVehicle model: {model}");
            Log(LogTarget.File, $"Produced in: {year}");
            Log(LogTarget.File, $"Collor: {collor}");
            Log(LogTarget.File, $"Serial Number: {serialNumber}");
            Log(LogTarget.File, $"With {horsePower} horse powers");
            Log(LogTarget.File, $"Can reach a maximum of {maxSpeed} km/h");
            Log(LogTarget.File, $"Costs: {price}");
        }

    }
}
