namespace WestminsterHotel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Westminster Hotel Booking Application");
            Console.WriteLine("");
            
            Console.WriteLine("please enter name: ");
            string userName = Console.ReadLine();
            
            Console.WriteLine("please enter Surname");
            string surName = Console.ReadLine();
            
            
            Users newUser = new Users(userName, surName);
            //Users newUser = new Admin(userName, surName);
            DateTime newD = new DateTime(2022,01,01);
            
            List<Room> westministerRoom = new List<Room>();
            Room wstRoom = new StandardRoom(245, Size.Single, 5000, newD , 2);
            westministerRoom.Add(wstRoom);
            Room wstRoom1 = new DeluxeRoom(245, Size.Tripple, 1000, newD, 20, View.seaView );
            Room wstRoom2 = new DeluxeRoom(245, Size.Single, 1200, newD, 20, View.seaView);
            westministerRoom.Add(wstRoom1);
            westministerRoom.Add(wstRoom2);
            WestminsterHotel myaccount = new WestminsterHotel(newUser, westministerRoom);
            
            Console.WriteLine($"Welcome {userName}... Please go ahead with your booking by type the number respectively");
            Console.WriteLine("");

            int value = 0;
            int i = 0; 
            
            while (i == 0)
            {
                Console.WriteLine("Press 1 to Book Room \n" +
                "Press 2 to List All Available Rooms \n" +
                "Press 3 to List All Available Rooms order by price \n" +
                "Press 0 to access Admin page");
                string val = Console.ReadLine();
                
                if (val != null)
                {
                    try
                    {
                        value = int.Parse(val);
                        if (value < 4 && value > -1)
                        {
                            Console.WriteLine($"Good Input -> You input {value}");
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Enter a number within range");
                            i = 0;
                        }
                    }
                    catch (SystemException ex)
                    {
                        Console.WriteLine("Execepetion Message: " + ex.Message);
                        Console.WriteLine("please input a valid value");
                        i = 0;
                    }
                }
                else
                {
                    Console.WriteLine("please input a value");
                    i = 0;
                }
            }


            //Check if value is 0
            //Admin Page
            if (value == 0)
            {
                Console.WriteLine("Administrator Page");
                Console.WriteLine("");

                int value1 = 0;
                int j = 0;
                
                //Admin Page Checks
                while (j == 0)
                {
                    Console.WriteLine("Press 1 to Add Room \n" +
                    "Press 2 to Delete Room \n" +
                    "Press 3 to List Rooms \n" +
                    "Press 4 to List Rooms Ordered By Price \n" +
                    "Press 5 to Generate Report");
                    string val = Console.ReadLine();
                    
                    if (val != null)
                    {
                        try
                        {
                            value1 = int.Parse(val);
                            if (value1 > 0 && value1 < 6)
                            {
                                Console.WriteLine($"Good Input -> You input {value1}");
                                j++;
                            }
                            else
                            {
                                Console.WriteLine("Enter a number within range");
                                j = 0;
                            }
                        }
                        catch (SystemException ex)
                        {
                            Console.WriteLine("Execepetion Message: " + ex.Message);
                            Console.WriteLine("please input a valid value");
                            j = 0;
                        }
                    }
                    else
                    {
                        Console.WriteLine("please input a value");
                        i = 0;
                    }
                }


                //Admin page Check if value1 is 1
                if (value1 == 1)
                {
                    Console.WriteLine("Add Room Operation");
                    Console.WriteLine(" ");
                    Console.WriteLine("Adding Room begins");
                    
                    bool result = myaccount.AddRoom(wstRoom2);
                    
                    if (result)
                    {
                        Console.WriteLine("Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Error while Adding");
                    }
                }
                
                //Admin Page Check if value1 is 2
                else if (value1 == 2)
                {
                    Console.WriteLine("Delete Room Operation");
                    Console.WriteLine(" ");
                    Console.WriteLine("Deleting Room begins");

                    bool result = myaccount.DeleteRoom(2);
                    
                    if (result)
                    {
                        Console.WriteLine("Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Error while Deleting");
                    }

                }
                
                //Admin Page Check if value1 is 3
                else if (value1 == 3)
                {
                    Console.WriteLine("List Room Operation");
                    Console.WriteLine(" ");
                    
                    myaccount.ListRooms();
                }
                
                //Admin Page Check if value1 is 4
                else if (value1 == 4)
                {
                    Console.WriteLine("List Room Ordered by Price Operation");
                    Console.WriteLine(" ");
                    
                    myaccount.ListRoomsOrderByPrice();

                }
                
                //Admin Page Check if value1 is 5
                else if (value1 == 5)
                {
                    Console.WriteLine("Generate Report Operation");
                    Console.WriteLine(" ");
                    Console.WriteLine("Enter File Name...-> test.txt: )");
                    
                    string inFileName = Console.ReadLine();
                    
                    myaccount.GenerateReport(inFileName);
                }
                else
                {
                    Console.WriteLine("Please restart");
                }
            }
            //Done with Admin Page
            
            //Check if value is 1
            else if (value == 1) 
            {
                Console.WriteLine("Booking Room Page");
                Console.WriteLine("please enjoy you booking");
                
                bool result = myaccount.BookRoom(1 , westministerRoom);
                
                if (result)
                {
                    Console.WriteLine("Booking Successful");
                }
                else
                {
                    Console.WriteLine("Room not available for now");
                }   
            }

            // Check if value is 2
            else if (value == 2)
            {
                Console.WriteLine("List All Available Rooms");
                
                myaccount.ListAvailableRooms(westministerRoom, Size.Single);
            }

            // Check if value is 3
            else if (value == 3)
            {
                Console.WriteLine("List All Available Rooms order by price");
                Console.WriteLine("Input max price");
                
                decimal inPrice = decimal.Parse(Console.ReadLine());
                
                myaccount.ListAvailableRooms(westministerRoom, Size.Single, inPrice);
            }
            else
            {
                Console.WriteLine("Please close and restart");
            }
        }   
    }
}