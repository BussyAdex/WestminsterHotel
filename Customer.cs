using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestminsterHotel
{
    public class Customer : Users
    {
        private List<string> bookingRef;
        private double noOfBooking = 0;

        public Customer(string n, string sur, string type)
            : base(n, sur, type)
        {
            base.SetUserType("Customer");
            bookingRef = new List<string>();
        }

        public Customer(string n, string sur) 
            : base(n, sur)
        {
            base.SetUserType("Customer");
            bookingRef = new List<string>();
        }

        public override void Display()
        {
            base.Display();
            DisplayBooking();
        }

        public void DisplayBooking()
        {
            Console.WriteLine("Booking Ref: ");
            foreach (string s in bookingRef)
            {
                Console.Write(s);
            }
        }

        public List<string> GetBookingRef()
        {
            return bookingRef;
        }

        public void SetBookingRef(string s)
        {
            bookingRef.Add(s);
        }
        
        public double GetNoOfBooking()
        {
            return noOfBooking;
        }

        public void SetNoOfBooking(double d)
        {
            noOfBooking = d;
        }
    }
}
