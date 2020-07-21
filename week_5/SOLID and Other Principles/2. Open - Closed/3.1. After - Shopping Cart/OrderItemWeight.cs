namespace OpenClosedShoppingCartBefore
{
    class OrderItemWeight : OrderItem
    {
        public override decimal TotalAmount()
        {

            decimal total;
            total = this.Quantity * 5m;

            return total;
        }
    }
}