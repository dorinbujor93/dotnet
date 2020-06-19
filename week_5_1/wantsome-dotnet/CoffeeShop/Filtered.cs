namespace Decorator
{
    using System;

    internal class Filtered
    {
        private readonly string description;
        private readonly decimal price;

        public Filtered(string description, decimal price)
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
