using System;
using System.Collections.Generic;

namespace HotelManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //print a message to the console with the basic of the information
            Console.WriteLine("\t\t**Welcome to Westminster Hotel**\t\t");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please find the room list: ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Standard rooms:\t\t\t\tDeluxe rooms:");
            Console.WriteLine("Floor: 0,1\t\t\t\tFloor: 1,2");
            Console.WriteLine("Size: single,double,triple\t\tSize: single,double,triple");
            Console.WriteLine("Price: £50-£65\t\t\t\tPrice: £70-£100");
            Console.WriteLine("Number of Windows: 1-3\t\t        Balcony sizes: 5-10m2 & View: seaview,landmark view or mountain view");

        /*Rooms[] rooms = new Rooms[5];
        rooms[0] = new StandardRoom("1", 0, "Single", 50,  2);
        rooms[1] = new StandardRoom("2", 0, "Single", 50,  1);
        rooms[2] = new StandardRoom("3", 0, "Double", 65,  2);
        rooms[3] = new StandardRoom("4", 1,"Single", 55 ,  2);
        rooms[4] = new StandardRoom("5", 1, "Double", 50,  2);
        foreach (var r in rooms)
        {
           r.Display();

        }*/

        //DateTime checkinDate = new DateTime(2022, 12, 20);
        //DateTime checkoutDate = new DateTime(2022,12,25);

        //Console.WriteLine("**");
        //Booking booking1 = new Booking(checkinDate,checkoutDate, rooms[0]);
        //booking1.GetBooking();
        //Console.WriteLine("**");

            
            //will be used and change value 
            DateTime checkin = new DateTime();
            DateTime checkout = new DateTime();
            string roomSize = " ";
            int maxPrice = 0;
            int roomNumber = 0;
            
            //starts by making an instance of the westminsterhotel class 
            WestminsterHotel westminster = new WestminsterHotel();

        Restart:
            //information of the customer menu how to use and what to use 
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Please enter your choice: ");
            Console.WriteLine();
            Console.WriteLine("1. List of all available rooms (Dates/Room size)");
            Console.WriteLine("2. List of all availabe rooms (Dates/Room size/Price)");
            Console.WriteLine("3. Book a room");
            Console.WriteLine("4. Continue as Admin");
            Console.WriteLine("5. Exit");//
            Console.WriteLine();
            int choice = Convert.ToInt32(Console.ReadLine());
            bool correctInfo = false;

           // int test =0;

            //switch statement with all the customer options +plus an option to continue as admin 
            switch (choice)
            {
                // ok
                //option 1 list all available rooms regarding the wantedbooking and room size
                case 1:
                    while (!correctInfo)
                    {
                        //prompts the user to insert the correct values 
                        Console.WriteLine("Please insert the desired Check-In date: DAY/MONTH/YEAR");
                        checkin = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Please insert the desired Check-Out date: DAY/MONTH/YEAR");
                        checkout = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Please insert the desired Room size: Single/Double/Triple");
                        roomSize = Console.ReadLine();

                        //if not correct dates prints incorrect dates please try again and the user has to type again the dates 
                        int correctDates = DateTime.Compare(checkin, checkout);
                        if (correctDates>=0)
                        {
                            Console.WriteLine("Incorrect Dates. Please try again.");
                        }
                        else
                        {
                            correctInfo = true;
                        }
                    }
                    //if the information are correct goes outside the loop and makes the wantedbooking instance, with these infos the programme calls the method and list the available rooms regarding the booking dates and the size 
                    Booking wantedBooking = new Booking(checkin, checkout,roomSize);
                    westminster.ListAvailableRooms(wantedBooking, roomSize);

                    goto Restart;
                    break;

                //same case as above , the difference is in the price , now the programme prompts the user to add the max price the user is willing to pay 
                case 2:
                    while (!correctInfo)
                    {
                        Console.WriteLine("Please insert the desired Check-In date: DAY/MONTH/YEAR");
                        checkin = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Please insert the desired Check-Out date: DAY/MONTH/YEAR");
                        checkout = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Please insert the desired Room size: Single/Double/Triple");
                        roomSize = Console.ReadLine();
                        Console.WriteLine("Please insert the max price for the room you want to book: ");
                        maxPrice = Convert.ToInt32( Console.ReadLine() );

                        int correctDates = DateTime.Compare(checkin, checkout);
                        if (correctDates >= 0)
                        {
                            Console.WriteLine("Incorrect Dates. Please try again.");
                        }
                        else
                        {
                            correctInfo = true;
                        }
                        //same as case 1 but this time also list the rooms up to the max price the user is willing to pay
                      
                    }
                    Booking wantedBoooking = new Booking(checkin, checkout, roomSize);
                    westminster.ListAvailableRooms(wantedBoooking, roomSize, maxPrice);
                    goto Restart;
                    break;

                //the case three is the option when the customer books a room 
                case 3:
                    while (!correctInfo)
                    {
                        //the programme prompts the user to insert the necessary info for the booking to be made 
                        Console.WriteLine("Please insert the desired Check-In date: DAY/MONTH/YEAR");
                        checkin = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Please insert the desired Check-Out date: DAY/MONTH/YEAR");
                        checkout = Convert.ToDateTime(Console.ReadLine());
                        Console.WriteLine("Please insert the Room Number for the room you wish to book: ");
                        roomNumber = Convert.ToInt32(Console.ReadLine());

                        //the user has to insert the correct dates to do the booking
                        //if not will get the message "incorrect dates"
                        int correctDates = DateTime.Compare(checkin, checkout);
                        if (correctDates >= 0)
                        {
                            Console.WriteLine("Incorrect Dates. Please try again.");
                        }
                        else
                        {
                            correctInfo = true;
                        }
                        
                    }
                    //the wanted booking contains check in , check out dates and the room number
                    Booking wantedBoookingv2 = new Booking(checkin, checkout, roomNumber);
                    westminster.BookRoom(wantedBoookingv2, roomNumber);
                    goto Restart;
                    break;

                    //option 4 has contains the admimns menu - a nested switch statement with all the admins options 
                case 4:
                    AdminRestart:
                    //admin menu
                    Console.WriteLine();
                    Console.WriteLine("Welcome Admin");
                    Console.WriteLine();
                    Console.WriteLine("Please enter your choice: ");
                    Console.WriteLine();
                    Console.WriteLine("1. Add a new room");
                    Console.WriteLine("2. Delete a room");
                    Console.WriteLine("3. Print a list of all rooms");
                    Console.WriteLine("4. Print all rooms ordered by price");
                    Console.WriteLine("5. Generate a report");
                    Console.WriteLine("6. Exit back to the customer menu");
                    int adminchoice = Convert.ToInt32(Console.ReadLine());

                    //nested switch statement with all the cases for the admin
                    switch (adminchoice)
                    {
                        //option 1 is for the admin to add a new room , the programme starts by prompting the user to add the proper infos for a room
                        //+ some extra infos depend of the type of room
                        case 1:
                            Console.WriteLine("Please add the room type (Standard/Delux)");
                            string roomtype = Console.ReadLine();

                            Console.WriteLine("Specify Room Number");
                            int roomnumberadd = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Specify Floor Number");
                            int floornumberadd = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Specify Room Size (Single/Double/Triple)");
                            string roomSize2 = Console.ReadLine();

                            Console.WriteLine("Specify Price Per Night");
                            double priceperday = Convert.ToDouble(Console.ReadLine());

                            if (roomtype == "Standard")
                            {
                                Console.WriteLine("Specify No. of Windows");
                                int win = Convert.ToInt32(Console.ReadLine());
                                Rooms room = new StandardRoom(roomnumberadd, floornumberadd, roomSize2, priceperday, win);
                                westminster.AddRoom(room);
                            }
                            else
                            {
                                Console.WriteLine("Specify Size of Balcony in Square meters");
                                int sob = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Specify View from the room (Landmark/Mountain/SeaView)");
                                string roomView = Console.ReadLine();
                                Rooms room = new DeluxeRoom(roomnumberadd, floornumberadd, roomSize2, priceperday,sob,roomView);
                                westminster.AddRoom(room);
                            }

                            goto AdminRestart;
                            break;

                            //option 2 is for the admin to delete a room , by choosing the corresponding room number
                        case 2:
                            Console.WriteLine("Please add the number of the room you want to delete");
                            //program takes the room number and by calling the delete room method is passing the number as argument
                            //then the room is been deleted from the list
                            int roomNumber2 = Convert.ToInt32( Console.ReadLine());
                            westminster.DeleteRoom(roomNumber2);
                            goto AdminRestart;
                            break;
                            //option 3 for admin is to list the rooms and their bookings if any
                        case 3:
                            westminster.ListRooms();

                            goto AdminRestart;
                            break;
                            //option 4 is the same as option 3 but is been ordered by price from cheaper to the most expensive one
                        case 4:
                            westminster.ListRoomsOrderedByPrice();
                            goto AdminRestart;
                            break;
                        //option 5 the admin should type a name for a .txt file 
                        //to save in the information on all the rooms existing in the system, together with their complete related information
                        case 5:
                            Console.WriteLine("Please insert the file name: ");

                           string filename = Console.ReadLine();
                            westminster.GenerateReport(filename);
                            goto AdminRestart;
                            break;
                        case 6:
                            goto Restart;
                            break;
                        default:
                            break;
                    }
                    break;
                case 5:
                    //Console.ReadKey();
                    //return;
                    //Environment.Exit(1);
                    break;
                default:
                    break;


            }

        }
    }
}

