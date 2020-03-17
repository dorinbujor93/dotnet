using System;
using System.Collections.Generic;
using System.Text;

namespace HotelApp
{
    class Rate
    {
        private decimal ammount;
        private string currency;

        public decimal Ammount
        {
            get
            {
                return ammount; 
            }
            set
            {
                ammount = value;
            }
        }

        public string Currency { get => currency; set => currency = value; }


        public void Print()
        {
            Console.WriteLine($"Rate Price {Ammount}, {Currency}");
        }

    }
}
