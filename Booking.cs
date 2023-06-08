using System;
using System.IO;

namespace HotelManagement
{
	public class Booking
	{
		private DateTime checkIn;
		private DateTime checkOut;
		private string roomSize;
		private int roomNumber;

		public Booking(DateTime checkIn, DateTime checkOut, string roomSize) //Rooms rooms
		{
			this.checkIn = checkIn;
			this.checkOut = checkOut;
			this.roomSize = roomSize;
			//this.roomNumber = roomNumber;
		}

		//constructor overloading
		public Booking(DateTime checkIn,DateTime checkOut, int roomNumber)
		{
			this.checkIn = checkIn;
			this.checkOut = checkOut;
			this.roomNumber = roomNumber;
		}

		//or set and get methods?

		//get and return checkin
		public DateTime GetCheckIn()
		{
			return checkIn;
		}

		//get and return checkout
		public DateTime GetCheckOut()
		{
			return checkOut;
		}
		public void SetRoomSize(string roomSize)
		{
			this.roomSize = roomSize;
		}
		public string GetRoomSize()
		{
			return roomSize;
		}

		public int GetRoomNumber()
		{
			return roomNumber;
		}

		public void GetBooking()
		{
			Console.WriteLine($"Check In date: {checkIn}");
			Console.WriteLine($"Check Out date: {checkOut}");
			Console.WriteLine($"Room size: {roomSize}");
			Console.WriteLine($"Room number: {roomNumber}");
			//Console.WriteLine($"Booked room: {rooms}");
		}

        //westminster class line 354
        public void BookinToFile(StreamWriter streamwriter) //writeToFile
        {

            streamwriter.WriteLine($"Check In date: {checkIn}");
            streamwriter.WriteLine($"Check Out date: {checkOut}");
            streamwriter.WriteLine($"Room size: {roomSize}");
            streamwriter.WriteLine($"Room number: {roomNumber}");
            //Console.WriteLine($"Booked room: {rooms}");
        }
    }
}

