using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestminsterHotel
{
    class Admin : Users
    {
        private DateTime dateCreated = new DateTime();

        public Admin(string n, string sur, string type)
            : base(n, sur, type)
        {
            dateCreated = DateTime.Now;
            base.SetUserType("Admin");
        }

        public Admin(string n, string sur)
           : base(n, sur)
        {
            dateCreated = DateTime.Now;
            base.SetUserType("Admin");
        }

        public DateTime GetDateCreated()
        {
            return dateCreated;
        }
        
        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Date Created: {dateCreated.ToShortDateString()}");
        }

    }
}
