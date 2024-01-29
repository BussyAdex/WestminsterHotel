using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WestminsterHotel
{
    public class WestminsterHotel : IHotelManager, IHotelCustomer
    {
        private Users user;
        private List<Room> rooms;
        private List<Booking> bookings;

        public WestminsterHotel(Users user, List<Room> rooms)
        {
            this.user = user;
            this.rooms = rooms;
            this.bookings = new List<Booking>();
        }
        public WestminsterHotel(Users user, List<Booking> bookings)
        {
            this.user = user;
            this.bookings = bookings;
            this.rooms = new List<Room>();
        }

        public bool AddRoom(Room rm)
        {
            if (user.GetUserType() == "Admin")
            {
                try
                {
                    rooms.Add(rm);
                    return true;
                }
                catch (SystemException ex)
                {
                    Console.WriteLine("Execepetion Message: " + ex.Message);
                    return false;
                }
                finally
                {
                    Console.WriteLine("Adding Room Operation Completed");
                }
            }
            else
            {
                Console.WriteLine("Admin right required to carry out this operation");
                return false;
            }
        }

        //The BookRoom will get Input from the user and validate
        //BookRoom check if overlap 
        public bool BookRoom(int d, List<Room> rom)
        {
            if (user.GetUserType() == "Customer")
            {
                foreach (Room rm in rom)
                {
                    DateOnly dateOut;
                    DateOnly dateIn;
                    int j = 0;
                    while (j == 0)
                    {
                        Console.WriteLine("Input Check-In Date in Format (yyyy/MM/dd): ");
                        string checkDtIn = Console.ReadLine();
                        if (checkDtIn != null && checkDtIn.Length == 10)
                        {
                            dateIn = DateOnly.Parse(checkDtIn);
                            j++;
                        }
                        else
                        {
                            Console.WriteLine("Please follow the date format for CheckIn Date");
                            j = 0;
                        }
                    };

                    int i = 0;
                    while (i == 0)
                    {
                        Console.WriteLine("Input Check-Out Date in Format (yyyy/dd/MM): ");
                        string checkDtOut = Console.ReadLine();
                        if (checkDtOut != null && checkDtOut.Length == 10)
                        {
                            dateOut = DateOnly.Parse(checkDtOut);
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Please follow the date format for CheckOut Date");
                            i = 0;
                        }
                    };
                    try
                    {
                        if (bookings.Count > 0) 
                        {
                            foreach (Booking bk in bookings)
                            {
                                if (bk.GetRoomNumber() == d)
                                {
                                    //Room Booked 
                                    if (bk.Overlaps(dateIn))
                                    {
                                        return false;
                                        Console.WriteLine("Booking Date Overlaps");
                                    }
                                    else
                                    {
                                        Booking booking = new Booking(dateIn, dateOut, rm);
                                        bookings.Add(booking);
                                        return true;
                                    }

                                }
                                else
                                {
                                    if (dateOut > dateIn)
                                    {
                                        Booking booking = new Booking(dateIn, dateOut, rm);
                                        bookings.Add(booking);
                                        return true;
                                    }
                                }
                                return false;
                            }
                        }
                        else
                        {
                            Booking booking = new Booking(dateIn, dateOut, rm);
                            bookings.Add(booking);
                            return true;
                        }
                        
                        
                        return false;
                    }
                    catch (SystemException ex)
                    {
                        Console.WriteLine("Execepetion Message: " + ex.Message);
                        return false;
                    }
                    finally
                    {
                        Console.WriteLine("Booking Room Operation Completed");
                    }
                }
                return false;
            }
            else
            {
                Console.WriteLine("Customer only to carry out this operation");
                return false;
            }
        }
  

        public bool DeleteRoom(int n)
        {
            if (user.GetUserType() == "Admin") 
            {
                try
                {
                    foreach (Room rm in rooms)
                    {
                        int numb = rm.GetNumber();
                        if (numb == n)
                        {
                            rooms.Remove(rm);
                            return true;
                        }
                    }
                }
                catch (SystemException ex)
                {
                    Console.WriteLine("Execepetion Message: " + ex.Message);
                    return false;
                }
                finally
                {
                    Console.WriteLine("Deleting Room Operation Completed");
                }
                return false;
            }
            else
            {
                Console.WriteLine("Admin right required to carry out this operation");
                return false;
            }
        }
      
        public void GenerateReport(string s)
        {
            if (user.GetUserType() == "Admin")
            {
                StreamWriter streamWriter = new StreamWriter(s);
                streamWriter.WriteLine("Room Information");
                if (rooms.Count > 0)
                {
                    streamWriter.WriteLine("No Floor Size   Price     RoomDate         RoomType");

                    foreach (Room rm in rooms)
                    {
                        rm.WriteToFile(streamWriter);
                    }
                    streamWriter.WriteLine("");
                    streamWriter.WriteLine("");
                    streamWriter.WriteLine("Booking Information");

                }
                else
                {
                    streamWriter.WriteLine("No Information for room is available yet");
                }

                if (bookings.Count > 0)
                {
                    streamWriter.WriteLine("BookngDate   RoomNumber   Check-In   Check-Out");

                    foreach (Booking bk in bookings)
                    {
                        bk.WriteToFile(streamWriter);
                    }
                }
                else
                {
                    streamWriter.WriteLine("No Information for bookings is available yet");
                }

                streamWriter.Dispose();
            }
            else
            {
                Console.WriteLine("Admin right required to carry out this operation");
            }
        }

        public void ListAvailableRooms(List<Room> rom, Size sz)
        {
            if (user.GetUserType() == "Customer")
            {
                foreach (Room rm in rom)
                {
                    if (rm.GetSize() == sz)
                    {
                        Console.WriteLine("Room Information");
                        Console.WriteLine($"Room Number : {rm.GetNumber()}");
                        Console.WriteLine($"Room Floor : {rm.GetFloor()}");
                        Console.WriteLine($"Room Size : {rm.GetSize()}");
                        Console.WriteLine($"Room Price : {rm.GetPrice()}");
                        Console.WriteLine($"Room Available : {rm.GetRoomDate()}");
                        Console.WriteLine($"Room Type: {rm.GetType()}");
                        Console.WriteLine(" ");
                    }
                }
            }
            else
            {
                Console.WriteLine("Customer only to carry out this operation");
            }
        }

        public void ListAvailableRooms(List<Room> rom, Size sz, decimal d)
        {
            if (user.GetUserType() == "Customer")
            {
                rooms.Sort();
                foreach (Room rm in rom)
                {
                    if (rm.GetSize() == sz && rm.GetPrice() < d)
                    {
                        Console.WriteLine("Room Information");
                        Console.WriteLine($"Room Number : {rm.GetNumber()}");
                        Console.WriteLine($"Room Floor : {rm.GetFloor()}");
                        Console.WriteLine($"Room Size : {rm.GetSize()}");
                        Console.WriteLine($"Room Price : {rm.GetPrice()}");
                        Console.WriteLine($"Room Available : {rm.GetRoomDate()}");
                        Console.WriteLine($"Room Type: {rm.GetType()}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Customer only to carry out this operation");
            }
        }

        public void ListRooms()
        {
            if (user.GetUserType() == "Admin") 
            {
                foreach (Room rm in rooms) 
                {
                    Console.WriteLine("Room Information");
                    Console.WriteLine($"Room Number : {rm.GetNumber()}");
                    Console.WriteLine($"Room Floor : {rm.GetFloor()}");
                    Console.WriteLine($"Room Size : {rm.GetSize()}");
                    Console.WriteLine($"Room Price : {rm.GetPrice()}");
                    Console.WriteLine($"Room Available : {rm.GetRoomDate()}");
                    Console.WriteLine($"Room Type: {rm.GetType()}");
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.WriteLine("Admin right required to carry out this operation");
            }
        }

        public void ListRoomsOrderByPrice()
        {
            if (user.GetUserType() == "Admin")
            {
                rooms.Sort();
                foreach (Room rm in rooms)
                {
                    Console.WriteLine("Room Information");
                    Console.WriteLine($"Room Number : {rm.GetNumber()}");
                    Console.WriteLine($"Room Floor : {rm.GetFloor()}");
                    Console.WriteLine($"Room Size : {rm.GetSize()}");
                    Console.WriteLine($"Room Price : {rm.GetPrice()}");
                    Console.WriteLine($"Room Available : {rm.GetRoomDate()}");
                    Console.WriteLine($"Room Type: {rm.GetType()}");
                    Console.WriteLine(" ");
                }
            }
            else
            {
                Console.WriteLine("Admin right required to carry out this operation");
            }
        }
    }
}
