using System;
using System.Collections.Generic;

namespace CarStore
{
    class Program
    {
        static void Main(string[] args)
        {
            //Alex intended to buy a Ford Focus 2015 model.
            //He walked to the FordStore in Bucuresti and agreed to buy one for *15000Euro.
            //They informed him it will take 4 weeks for delivery.
            //He then decided to visit another store SkodaStore and agreed to buy one * for 14000Euro and 3 weeks delivery.
            //He then canceled his original order from the FordStore.
            //After 3 weeks, he received the model.

            // Create Ford producer
            Producer producerFord = new Producer();
            producerFord.Country = "USA";
            producerFord.Founded = 1903;
            producerFord.Name = "Ford";
            producerFord.StockValue = 5.01f;
            producerFord.WeeksForDelivery = 4;
            producerFord.VehicleSpecs = new Dictionary<string, Dictionary<string, int>>() {
                {
                "Focus", new Dictionary<string,int>() {
                    { "horsePower", 90 },
                    { "maxSpeed", 200 },
                    { "price", 15000}
                }
            },
                {
                "Mustang", new Dictionary<string,int>() {
                    { "horsePower", 300 },
                    { "maxSpeed", 290 },
                    { "price", 25000}
                }
            },
                {
                "GTR", new Dictionary<string,int>() {
                    { "horsePower", 300 },
                    { "maxSpeed", 290 },
                    { "price", 25000}
                } }
            };

            // Create Skoda producer
            Producer producerSkoda = new Producer();
            producerSkoda.Country = "Czech Republic";
            producerSkoda.Founded = 1895;
            producerSkoda.Name = "Skoda";
            producerSkoda.StockValue = 4.98f;
            producerSkoda.WeeksForDelivery = 3;
            producerSkoda.VehicleSpecs = new Dictionary<string, Dictionary<string, int>>() {
                {
                "Superb", new Dictionary<string,int>() {
                    { "horsePower", 150 },
                    { "maxSpeed", 260 },
                    { "price", 16000}
                }
            },
                {
                "Fabia", new Dictionary<string,int>() {
                    { "horsePower", 100 },
                    { "maxSpeed", 220 },
                    { "price", 15000}
                }
            }
            };

            //Produce some vehicles
            producerFord.ProduceAVehicle("Focus", "Green");
            producerFord.ProduceAVehicle("Mustang", "Red");
            producerFord.ProduceAVehicle("GTR", "Yellow");
            producerSkoda.ProduceAVehicle("Superb", "Yellow");
            producerSkoda.ProduceAVehicle("Fabia", "Black");

            //Add Alex to the battlefield :))
            Person alex = new Person();
            alex.Age = 25;
            alex.Name = "Alex";
            alex.Networth = 20000;


            //Create Stores
            Store fordStore = new Store();
            fordStore.AffiliateProducer = producerFord;
            fordStore.City = "Bucuresti";
            fordStore.Name = "Ford Bucuresti";
            fordStore.AvailableVehicles = producerFord.AvailableVehicles;

            Store skodaStore = new Store();
            skodaStore.AffiliateProducer = producerSkoda;
            skodaStore.City = "Bucuresti";
            skodaStore.Name = "Skoda Bucuresti";
            skodaStore.AvailableVehicles = producerSkoda.AvailableVehicles;


            //Show Alex details 
            alex.DisplayOwnedVehicles();
            alex.BuyACar(fordStore, "Focus");
            alex.BuyACar(skodaStore, "Fabia");


        }
    }
}
