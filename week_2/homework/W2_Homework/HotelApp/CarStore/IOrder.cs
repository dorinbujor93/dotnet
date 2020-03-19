namespace CarStore
{
    public interface IOrder
    {
        void Display();
        void FillOrderData(Store store, Person customer, Vehicle car);
    }
}
