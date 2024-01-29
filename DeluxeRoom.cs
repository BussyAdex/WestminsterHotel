using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestminsterHotel
{
    class DeluxeRoom : Room
    {
        private decimal balcony;
        private View view;

        public DeluxeRoom(decimal fl, Size s, decimal p, DateTime d, string t, decimal bal, View vw)
             :base(fl, s, p, d, t)
        {
            balcony = bal;
            view = vw;
            base.SetRoomType("Deluxe Room");
        }

        public DeluxeRoom(decimal fl, Size s, decimal p, DateTime d, decimal bal, View vw)
             : base(fl, s, p, d)
        {
            balcony = bal;
            view = vw;
            base.SetRoomType("Deluxe Room");
        }

        public decimal GetBalcony()
        {
            return balcony;
        }

        public void SetBalcony(decimal d)
        {
            balcony = d;    
        }

        public View GetView()
        {
            return view;
        }

        public void SetView(View vw) 
        {
            view = vw; 
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Number of balcony : {balcony}");
            Console.WriteLine($"Type of view : {balcony}");
        }
    }
}
