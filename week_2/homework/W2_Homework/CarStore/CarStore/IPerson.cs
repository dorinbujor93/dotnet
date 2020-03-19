namespace CarStore
{
    public interface IPerson
    {
        void DisplayOwnedVehicles();
        void BuyACar(Store store, string model, int ammount);
    }
}
