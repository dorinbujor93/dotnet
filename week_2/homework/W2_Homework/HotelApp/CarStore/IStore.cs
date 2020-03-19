using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    public interface IStore
    {
        void ShowStoreInformation();
        void ShowAvailableVehicles();
        void DeliverCarToCustomer(Person person, Vehicle vehicle);
        void PlaceOrder(string model, int price, Person customer);
        void CancelOrder(Person person, string model)
    }
}
