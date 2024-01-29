using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestminsterHotel;

namespace WestminsterHotel
{
    public interface IHotelManager
    {
        public bool AddRoom(Room rm);

        public bool DeleteRoom(int n);

        public void ListRooms();

        public void ListRoomsOrderByPrice();

        public void GenerateReport(string s);
    }
}

