using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestminsterHotel
{
    public class StandardRoom : Room
    {
        private int windows;

        public StandardRoom(decimal fl, Size s, decimal p, DateTime d, string t, int wd) 
            :base(fl, s, p, d, t)      
        {
            windows = wd;
            base.SetRoomType("Standard Room");
        }

        public StandardRoom(decimal fl, Size s, decimal p, DateTime d, int wd)
            : base(fl, s, p, d)
        {
            windows = wd;
            base.SetRoomType("Standard Room");
        }

        public int GetWindows()
        {
            return windows;
        }

        public void SetWindows(int n)
        {
            windows = n;
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Number of windows : {windows}");
        }
    }
}
