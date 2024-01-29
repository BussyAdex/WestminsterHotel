using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestminsterHotel
{
    public class Booking : IOverlappable 
    {
        private DateOnly checkIn;
        private DateOnly checkOut;
        private DateTime bookingDate;
        private Room room; 
        public Booking(DateOnly chkin, DateOnly chkot, Room rm)
        {
            checkIn = chkin;
            checkOut = chkot;
            room = rm;
            bookingDate = DateTime.Now;

        }

        public void SetCheckIn(DateOnly d)
        {
            checkIn = d;
        }

        public DateOnly GetCheckIn()
        {
            return checkIn;
        }

        public void SetCheckOut(DateOnly d)
        {
            checkOut = d;
        }

        public DateOnly GetCheckOut()
        {
            return checkOut;
        }

        public DateTime GetBookingDate()
        {
            return bookingDate;
        }

        public bool Overlaps(DateOnly other)
        {
            if (this.checkOut > other)
                return true;
            else if (this.checkOut < other)
                return false;
            else
                return false;
        }

        public int GetRoomNumber()
        {
            return room.GetNumber();
        }

        public void WriteToFile(StreamWriter sw)
        {
            sw.WriteLine($"{bookingDate}{" "}{" "}{room.GetNumber()}{" "}{" "}{checkIn}{" "}{" "}{checkOut}");
        }
    }
}
