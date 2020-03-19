using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore
{
    public interface IStore
    {
        void ShowStoreInformation();
        void ShowAvailableVehicles();
        void DeliverCarToCustomer(Person person);
        bool PlaceOrder(string model, int price, Person customer);
        bool CancelOrder(Person person, string model);
    }
}
