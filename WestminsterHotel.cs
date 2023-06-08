using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HotelManagement
{
    //is the class that contains the implementation of the logic , inherits its methods from 3 interfaces
    //the implementation starts with IHotelCustomer cause when it runs the first menu is for the customer
    //before the user adds a new booking the programme stops him if the user trys to book a room for the dates that is already booked
    //look overlappable interface checks whether two booking objects overlap
    //To implement the logic for the adminstrator of the hotel , the programme uses IHotelManager interface that contains the methods an admin uses to manage the rooms
    public class WestminsterHotel : IHotelCustomer, IOverlappable, IHotelManager
    {
        //3.the deleted rooms (look the delete rooms method from the i hotel manager interface)
       private Rooms takeIT;
        //1.a List with the first 10 rooms is been created , and its called roomList
       private  List<Rooms> roomList = new List<Rooms>();
        //2. a Dictionary with Rooms as Keys and Booking a values is been made for that have been booked not to be shown in the available rooms list
       private  Dictionary<Rooms, Booking> bookedRooms = new Dictionary<Rooms, Booking>();


        // added the theRoomList() method to the constructor for the list to work 
        public WestminsterHotel()
        {
            theRoomList();
        }

        //a premade list of rooms for the logic to work 5 standard 5 deluxe total of 10 objects 
        private void theRoomList()
        {
            Rooms room1 = new StandardRoom(1, 0, "Single", 55, 2);
            Rooms room2 = new StandardRoom(2, 0, "Single", 50, 2);
            Rooms room3 = new StandardRoom(3, 0, "Double", 60, 2);
            Rooms room4 = new StandardRoom(4, 1, "Double", 65, 3);
            Rooms room5 = new StandardRoom(5, 1, "Double", 65, 3);

            Rooms room6 = new DeluxeRoom(6, 1, "Double", 70, 10, "landmark view");
            Rooms room7 = new DeluxeRoom(7, 1, "Double", 70, 10, "landmark view");
            Rooms room8 = new DeluxeRoom(8, 1, "Triple", 90, 20, "mountain view");
            Rooms room9 = new DeluxeRoom(9, 2, "Double", 80, 10, "seaview");
            Rooms room10 = new DeluxeRoom(10, 2, "Double", 80, 10, "seaview");

            roomList.Add(room1);
            roomList.Add(room2);
            roomList.Add(room3);
            roomList.Add(room4);
            roomList.Add(room5);
            roomList.Add(room6);
            roomList.Add(room7);
            roomList.Add(room8);
            roomList.Add(room9);
            roomList.Add(room10);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //The customer
        //ok
        //the first method of the IHotelCustomer interface that list the rooms
        public void ListAvailableRooms(Booking wantedBooking, string roomSize)
        {
            //** the list with the rooms that have been booked
            List<int> alreadyBooked = new List<int>();

            //if the dictionary is not empty 
            if (bookedRooms.Count != 0)
            {
                //for each of the booked rooms with the corresponding booking in the collection 
                foreach (KeyValuePair<Rooms,Booking>bookrooms in bookedRooms)
                {
                    //if the rooms size is equal to the room size the customer inserts and 
                    if (bookrooms.Key.GetRoomSize()==roomSize)

                    {
                        //and the compare the checkin  date of the wantedbooking with the checkout date of the room that is booked
                        int checkDates = DateTime.Compare(wantedBooking.GetCheckIn(), bookrooms.Value.GetCheckOut());
                        //the wantedbooking precedes the bookrooms , the programme adds this to the list with the rooms that are already been booked **
                        if (checkDates < 0)
                        {
                            alreadyBooked.Add (bookrooms.Value.GetRoomNumber());
                        }

                    }

                }
                //for each room in the list that the the size is equal to the size the user wants to display and its not inside the already booked list , then display them
                foreach (Rooms r in roomList)
                {
                    if (r.GetRoomSize() == roomSize && !alreadyBooked.Contains(r.GetRoomNumber()))
                    {
                        r.Display();

                    }

                }
            }
            else
            {
                foreach (Rooms r in roomList)
                {
                    if (r.GetRoomSize() == roomSize)
                    {
                        r.Display();

                    }

                }

            }
        }

        // ok
        //this is the same implementation as above but has a plus , the programme takes a max price integer number from the user
        //this price is the maximum the user is willing to pay for a room and the programme prints the rooms that are less than the max price 
        public void ListAvailableRooms(Booking wantedBooking, string roomSize, int maxPrice)
        {
            // a list with rooms that have already been booked
            List<int> alreadyBooked = new List<int>();

            //checks if the dictionary with booked rooms is not empty
            if (bookedRooms.Count != 0)
            {
                //for each room with its booking inside the dicionary
                foreach (KeyValuePair<Rooms, Booking> bookrooms in bookedRooms)
                {
                    //if the size is equal to the size the user inserts 
                    if (bookrooms.Key.GetRoomSize() == roomSize)

                    {
                        //compare the date if the checkin day of the room that is wanted  preceds the checkout of the room in the dictionary
                        //add this room to the alreadybooked rooms
                        int checkDates = DateTime.Compare(wantedBooking.GetCheckIn(), bookrooms.Value.GetCheckOut());
                        if (checkDates < 0)
                        {
                            alreadyBooked.Add(bookrooms.Value.GetRoomNumber());
                        }

                    }

                }

                //sort the room with the price ,  list with rooms sorted by price , displays them if the proper size and not already booked
                List<Rooms> sortPrice = roomList.OrderBy(room => room.GetRoomPrice()).ToList();
                foreach (Rooms r in sortPrice)
                {
                    //if the room size typed by user is the same as the roomsize from the list and the the room price is less than the max price the user adds and is not been booked display it
                    if (r.GetRoomSize() == roomSize && r.GetRoomPrice() < maxPrice && !alreadyBooked.Contains(r.GetRoomNumber()))
                    {
                        r.Display();

                    }

                }
            }
            else
            {
                List<Rooms> sortPrice = roomList.OrderBy(room => room.GetRoomPrice()).ToList();
                foreach (Rooms r in sortPrice)
                {
                    //displays if correct size and sorted price
                    if (r.GetRoomSize() == roomSize && r.GetRoomPrice() < maxPrice)
                    {
                        r.Display();

                    }

                }

            }

        }

        //ok
        //checks whether two booking objects overlap
        public bool Overlap(Booking other)
        {
            bool overLap = false;

            foreach (KeyValuePair<Rooms,Booking> bookrooms in bookedRooms)
            {
                if (bookrooms.Key.GetRoomNumber()==other.GetRoomNumber())

                {
                    int checkDates = DateTime.Compare(other.GetCheckIn(), bookrooms.Value.GetCheckOut());
                    if (checkDates < 0 )
                    {
                        overLap = true;
                        break;
                    }

                }

            }
            return overLap;
        }

        //ok
        //the user can book a room only if is not already been booked for the same dates the user wants 
        public bool BookRoom(Booking wantedBooking, int roomNumber)
        {
            
            bool isBooked = Overlap(wantedBooking);
            //if the dates are the same the room cannot been booked for theses dates
            if (isBooked)
            {
                Console.WriteLine("This room is not available for these dates.");
                return false;

            }
            //if not
            else
            {
                foreach (Rooms  r in roomList)
                {
                    //if the roomnumber the customer wants is inside the list of the rooms then the key and the value are been added to the dictionary booked rooms.
                    if (r.GetRoomNumber()==roomNumber)
                    {
                        //we are passing the room size from the room of the list and passing it in the wantedbooking 
                        wantedBooking.SetRoomSize(r.GetRoomSize());//
                        bookedRooms.Add( r,wantedBooking);
                        Console.WriteLine("Congratulations, your room is been booked.");
                    }

                }
            }

            return true;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //The Admin

        //ok
        //to add a new room in the list of rooms
        public bool AddRoom(Rooms room)
        {
           

            bool isPresent = false;

            //the room must not exist in the list
            foreach (Rooms r in roomList)
            {
                if (r.GetRoomNumber() == room.GetRoomNumber())
                {
                    isPresent = true;
                }
            }

            //if not exist the room can be added to the list 
            if (isPresent == false)
            {
                roomList.Add(room);
                Console.WriteLine("Room added");
            }
            else
            {
                Console.WriteLine("this Room already exists");
            }
           
         
            return true;
        }

        //ok
        //to delete a room, the programme takes the room number from the user if its in the roomlist
        public bool DeleteRoom(int roomNumber)
        {
           //checks the roomlist
            foreach (Rooms r in roomList)
            {
                //stores the room numbers
                int roomnumber3 = r.GetRoomNumber();
                //checks if any of them is equal with the roomnumber user wants and stores it in a variable
                if (roomnumber3 == roomNumber)
                {
                    takeIT = r;
                }
            }

            //removes the room from the list
            roomList.Remove(takeIT);
            //prints the information of the room that has been deleted
            Console.WriteLine("Information of Room deleted: ");
            takeIT.Display();

            return true;
        }

        //ok
        //the admin can print all the rooms in the system and if the rooms a booked 
        public void ListRooms()
        {
           bool alreadybooked = false;

            foreach (Rooms r  in roomList)
            {
                //display all rooms from the list
                Console.WriteLine();
                r.Display();
                //displays their details if a room/rooms is/are booked
                Console.WriteLine("Booking Details: ");

                foreach (KeyValuePair<Rooms, Booking> bookrooms in bookedRooms)
                {
                    if (bookrooms.Key.Equals(r))
                    {
                        bookrooms.Value.GetBooking();
                         alreadybooked = true;
                    }

                }
                //if not then displays the message "No bookings"
                if (alreadybooked == false)
                {
                    Console.WriteLine("No bookings");
                }
            }


        }

        //ok
        //lists the room ordered by price
        public void ListRoomsOrderedByPrice()
        {
            //use build in sort method to sort the roomlist
            //the rest is same implementation as above
            roomList.Sort();//
            bool alreadybooked = false;

            foreach (Rooms r in roomList)
            {
                Console.WriteLine();
                r.Display();
                Console.WriteLine("Booking Details: ");

                foreach (KeyValuePair<Rooms, Booking> bookrooms in bookedRooms)
                {
                    if (bookrooms.Key.Equals(r))
                    {
                        bookrooms.Value.GetBooking();
                        alreadybooked = true;
                    }

                }

                if (alreadybooked == false)
                {
                    Console.WriteLine("No bookings");
                }
            }
        }

        //ok
        // to make a .txt file with all the infos of the existing in the system rooms 
        public void GenerateReport(string file)
        {
            bool alreadybooked = false;
            //streamwriter -> textwriter //lecture week12 page 68 and after // implement the streamwriter.writeline to the other methods display() as well
            StreamWriter streamwriter = new StreamWriter(file);

            foreach (Rooms r in roomList)
            {
                Console.WriteLine();
                //write the rooms from roomlist to file
                r.WriteToFile(streamwriter);
                //print their booking details if any
                streamwriter.WriteLine("Booking Details: ");
                //the booking details if any (checks dictionary)
                foreach (KeyValuePair<Rooms, Booking> bookrooms in bookedRooms)
                {
                    if (bookrooms.Key.Equals(r))
                    {
                        bookrooms.Value.BookinToFile(streamwriter);
                        alreadybooked = true;
                    }

                }
                //if no bookings 
                if (alreadybooked == false)
                {
                    streamwriter.WriteLine("No bookings");
                }
            }
            streamwriter.Dispose();
        }
    }

}


