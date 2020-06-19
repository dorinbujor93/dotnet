namespace CoffeeShop
{

    internal abstract class Decorator
    {
        protected Decorator(ShopItem shopItem)
        {
            this.ShopItem = shopItem;
        }

        protected ShopItem ShopItem { get; private set; }

        public override void Display()
        {
            this.ShopItem.Display();
        }
    }
}
