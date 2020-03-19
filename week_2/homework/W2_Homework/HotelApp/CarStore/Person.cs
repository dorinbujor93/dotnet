using System;
using System.Collections.Generic;
using System.Text;
using static CarStore.Logging.LogHelper;

namespace CarStore
{
    public class Person : IPerson
    {
        private string name;
        private int age;
        private decimal netWorth;
        private int timeToWait;
        private List<Vehicle> vehicles = new List<Vehicle>();


        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
        public int TimeToWait { get => timeToWait; set => timeToWait = value; }
        public decimal Networth { get => netWorth; set => netWorth = value; }
        public List<Vehicle> Vehicles { get => vehicles; set => vehicles = value; }

        //Display all vehicles owned by person
        public void DisplayOwnedVehicles()
        {
            if (Vehicles.Count > 0)
            {
                Log(LogTarget.File, $"Vehicles owned by {name}:");
                foreach (Vehicle vehicle in Vehicles)
                {
                    vehicle.Display();
                }
            }
            else
            {
                Log(LogTarget.File, $"{name} has no vehicles.");
            }
        }

        //Buy a car with given specs
        public void BuyACar(Store store, string model, int ammount)
        {
            store.ShowStoreInformation();
            store.ShowAvailableVehicles();

            //Try to place an order in the store
            if (store.PlaceOrder(model, ammount, this))
            {
                if (timeToWait > 3)
                {
                    //Cancell order since it takes too long to deliver
                    CancelCarOrder(store, model);
                }
                else
                {
                    //Wait for the car to be delivered
                    PassTime(timeToWait);
                    store.DeliverCarToCustomer(this);
                }
            }
            else
            {
                Log(LogTarget.File, "Something went wrong!");
            }
        }

        //Go to store and cancell a order for the car
        private void CancelCarOrder(Store store, string model)
        {
            store.CancelOrder(this, model);
        }

        //Wait for x weeks
        private void PassTime(int weeks)
        {
            while (weeks > 0)
            {
                weeks--;
                Log(LogTarget.File, "A week have passed!");
            }
        }
    }
}
