using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WestminsterHotel
{
    public class Room : IComparable<Room>
    {
        private int number;
        private decimal floor;
        private Size size;
        private decimal price;
        private DateTime roomDate;
        private string roomtype;
        static private int roomCount = 0;

        public Room(decimal fl, Size s, decimal p, DateTime d, string t)
        {
            floor = fl;
            size = s;
            price = p;
            roomDate = d;
            roomtype = t;
            number = roomCount + 1;
            roomCount++;
        }

        public Room(decimal fl, Size s, decimal p, DateTime d)
        {
            floor = fl;
            size = s;
            price = p;
            roomDate = d;
            roomtype = "";
            number = roomCount + 1;
            roomCount++;
        }

        public int GetNumber() 
        { 
            return number;
        }

        public void SetNumber( int d) 
        {
            number = d;
        }

        public decimal GetFloor()
        {
            return floor;
        }

        public void SetFloor(decimal fl)
        {
            floor = fl;
        }

        public Size GetSize()
        {
            return size;
        }

        public void SetSize(Size sz)
        {
            size = sz;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public void SetPrice(decimal p)
        {
            price = p;
        }

        public DateTime GetRoomDate()
        {
            return roomDate;
        }

        public void SetRoomDate(DateTime t)
        {
            roomDate = t;
        }

        public string GetRoomType()
        {
            return roomtype;
        }

        public void SetRoomType(string ty)
        {
            roomtype = ty;
        }
        
        public virtual void Display()
        {
            Console.WriteLine($"Room number: {number}");
            Console.WriteLine($"Floor: {floor}");
            Console.WriteLine($"Size: {size}");
            Console.WriteLine($"Floor: {price}");
            Console.WriteLine($"Room date: {roomDate}");
            Console.WriteLine($"Room type: {roomtype}");
        }

        public int CompareTo(Room other)
        {
            if (this.price < other.price)
                return -1;
            else if (this.price > other.price)
                return 1;
            else
                return 0;
        }

        public void WriteToFile(StreamWriter sw)
        {
            sw.WriteLine($"{number}{" "}{" "}{floor}{" "}{" "}{size}{" "}{" "}{price}{" "}{" "}{roomDate}{" "}{" "}{roomtype}");
        }

	
	}
}
