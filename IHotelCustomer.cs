using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestminsterHotel
{
    internal interface IHotelCustomer
    {
        public void ListAvailableRooms(List<Room> rm, Size sz);

        public void ListAvailableRooms(List<Room> rm, Size sz, decimal d);

        public bool BookRoom(int i, List<Room> rm);
    }
}

