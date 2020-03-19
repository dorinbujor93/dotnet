using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    public class Person : IPerson
    {
        private string name;
        private int age;
        private decimal netWorth;
        private List<Vehicle> vehicles = new List<Vehicle>();


        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public decimal Networth { get => netWorth; set => netWorth = value; }
        public List<Vehicle> Vehicles { get => vehicles; set => vehicles = value; }


        public void DisplayOwnedVehicles()
        {
            if (Vehicles.Count > 0)
            {
                Console.WriteLine($"Vehicles owned by {name}:");
                foreach (Vehicle vehicle in Vehicles)
                {
                    vehicle.Display();
                }
            }
            else
            {
                Console.WriteLine($"{name} has no vehicles.");
            }
        }

        public void BuyACar(Store store, string model)
        {
           store.ShowStoreInformation();
           store.ShowAvailableVehicles();
           store.PlaceOrder(model, 15000, this);
           store.CancelOrder(this, model);
        }

        public void CancelCarOrder(Store store, string model)
        {
            store.CancelOrder(this, model);
        }
        public void PassTime(int weeks)
        {

        }
    }
}
