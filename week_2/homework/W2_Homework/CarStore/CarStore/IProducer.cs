using System;
using System.Collections.Generic;
using System.Text;
namespace CarStore
{
    public interface IProducer
    {
        void ProduceAVehicle(string model, string collor);
        void Display();
    }
}
