using System;
using System.Collections.Generic;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Hotel hotel = new Hotel();
            hotel.City = "Frankfurt";
            hotel.Name = "Moldova";
            hotel.Rooms = new List<Room>();

            hotel.Rooms.Add(new Room());
            hotel.Rooms[0].Name = "King";
            hotel.Rooms[0].Adults = 2;
            hotel.Rooms[0].Children = 1;
            hotel.Rooms[0].Rate = new Rate();
            hotel.Rooms[0].Rate.Ammount = 500;
            hotel.Rooms[0].Rate.Currency = "USD";

            Room room = new Room();
            room.Name = "Single";
            room.Adults = 1;
            room.Children = 0;
            room.Rate = new Rate();
            room.Rate.Ammount = 200;
            room.Rate.Currency = "USD";

            hotel.Rooms.Add(room);

            hotel.Print();

            Console.WriteLine("Please insert number of rooms:");
            if (int.TryParse(Console.ReadLine(), out int roomsNR))
            {
                var price = hotel.GetPriceForNumberOfRooms(roomsNR);
                Console.WriteLine($"The price is:{price}");
            }
            else
            {
                Console.WriteLine("Invalid number of rooms!");
            }

            Console.WriteLine("Please insert stay length:");

            if (int.TryParse(Console.ReadLine(), out int daysNr))
            {
                Console.WriteLine("Prices for rooms are:");
                foreach (Room r in hotel.Rooms)
                {
                    Console.WriteLine($"\n{r.Name} - {r.GetStayCosts(daysNr)} {r.Rate.Currency}");
                }
            }
            else
            {
                Console.WriteLine("Invalid number of days!");
            }
        }
    }
}
