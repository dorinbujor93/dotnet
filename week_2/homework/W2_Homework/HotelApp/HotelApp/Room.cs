using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp
{

    class Room
    {
        private string name;
        private Rate rate;
        private byte adults;
        private byte children;

        public string Name { get => name; set => name = value; }
        public Rate Rate { get => rate; set => rate = value; }
        public byte Children { get => children; set => children = value; }
        public byte Adults { get => adults; set => adults = value; }


        public decimal GetStayCosts(int numberOfDays)
        {
            return rate.Ammount * numberOfDays;
        }

        public decimal GetRateAmount()
        {
            return Rate.Ammount;
        }

        public void Print()
        {
            Console.WriteLine($"\nRoom Name: {Name}");
            Console.WriteLine($"Adults: {Adults}");
            Console.WriteLine($"Children: {Children}");
            Rate.Print();
        }


    }
}
