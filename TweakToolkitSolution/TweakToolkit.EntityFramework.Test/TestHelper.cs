using System.Collections.Generic;

namespace TweakToolkit.EntityFramework.Test
{
    public class TestHelper
    {
        public static AddressType GetAddress()
        {
            return new AddressType {City = "Zurich", PostalCode = 8000, Street = "Idastreet", StreetNumber = "49a"};
        }

        public static House GetHouse()
        {
            var rooms = new List<Room> {new Room {Size = "20qm"}};
            var door = new Door();
            return new House {Address = GetAddress(), Door = door, Room = rooms};
        }
    }
}