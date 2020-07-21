namespace OpenClosedShoppingCartBefore
{
    public class OrderItem
    {
        public string Sku { get; set; }
        public abstract decimal TotalAmount();
        public int Quantity { get; set; }
    }
}