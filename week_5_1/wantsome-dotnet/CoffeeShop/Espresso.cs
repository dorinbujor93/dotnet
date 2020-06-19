namespace Decorator
{
    using System;

    internal class Espresso : LibraryItem
    {
        private readonly string description;
        private readonly decimal price;

        public Espresso(string description, decimal price)
        {
            this.description = description;
            this.price = price;
        }


        public override void Display()
        {
            System.Console.WriteLine($"Espresso price is: {this.price}");
            System.Console.WriteLine($"Espresso description is: {this.description}");
        }

    }
}
