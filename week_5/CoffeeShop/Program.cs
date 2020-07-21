namespace CoffeeShop
{
    using System;
    using Filtered;
    public static class Program
    {
        public static void Main()
        {
            var filtered = new Filtered("Filtered Stuff", 100);
            filtered.Display();

        
            var espresso = new Espresso("Espresso Cup", 92);
            espresso.Display();


         
        }
    }
}
