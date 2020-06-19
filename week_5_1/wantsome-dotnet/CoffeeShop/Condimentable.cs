namespace CoffeeShop
{
    using System;

    internal class Condimentable : Decorator
    {
        private readonly List<string> condiments = new List<string>();

        public Condimentable(ShopItem shopItem)
            : base(shopItem)
        {
        }

        public void CondimentDrink(string condimentType)
        {
            this.condiments.Add(condimentType);
        }


        public override void Display()
        {
            base.Display();
            System.Console.WriteLine("Added Condiments: ");
            foreach (var condiments in this.condiments)
            {
                Console.WriteLine(borrower + "; " );
            }
        }
    }
}
