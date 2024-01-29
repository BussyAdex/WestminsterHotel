using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestminsterHotel
{
    public class Users
    {
        private string name;
        private string surname;
        private double userId;
        private string userType;
        static private double userCount = 0;

        public Users(string n, string sur, string type)
        {
            name = n;
            surname = sur;
            userType = type;
            userId = userCount + 1;
            userCount ++; 
        }
        public Users(string n, string sur)
        {
            name = n;
            surname = sur;
            userType = "Customer";
            userId = userCount + 1;
            userCount++;
        }

        public string GetName()
        {
            return name;
        }
        
        public void SetName(string n)
        {
           name = n;
        }

        public string GetSurname() 
        {
            return surname;
        }

        public void SetSurname(string sur)
        {
            surname = sur;
        }

        public double GetUserId()
        {
            return userId;
        }

        public string GetUserType()
        {
            return userType;
        }

        protected void SetUserType(string n)
        {
            userType = n; 
        }

        public virtual void Display()
        {
            Console.WriteLine($"User Name: {name}");
            Console.WriteLine($"User Surname: {surname}");
            Console.WriteLine($"User Id: {userId}");
            Console.WriteLine($"User Type: {userType}");
        }

    }
}
