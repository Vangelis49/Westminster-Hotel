using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
namespace HotelManagement
{
	//inherits the build in system IComparable interface 
	public class Rooms : IComparable<Rooms>
	{
		//unique room number
		private int roomNumber;
		//floor number
		private int floorNumber;
		//room size: single,double,triple
		private string roomSize;
		//price per night
		private double roomPrice;
		//status: available , booked
		//private string roomStatus;


		//constructor
		public Rooms(int roomNumber,int floorNumber, string roomSize,double roomPrice)//,string roomStatus
        {
			this.roomNumber = roomNumber;
			this.floorNumber = floorNumber;
			this.roomSize = roomSize;
			this.roomPrice = roomPrice;
			//this.roomStatus = roomStatus;

		}


		//methods
		public int GetRoomNumber()
		{
			return roomNumber;
		}

		public int GetFloorNumber()
		{
			return floorNumber;
		}

		public string GetRoomSize()
		{
			return roomSize;
		}

		public double GetRoomPrice()
		{
			return roomPrice;
		}

		//public string GetRoomStatus()
		//{
			//return roomStatus;
		//}


		//is virtual because Standard and Deluxe will inherit from Rooms and will need to overridde this method
		public virtual void Display()
		{
			//Console.WriteLine("Please find the rooms information.");
			Console.WriteLine($"The Room Number is: {roomNumber} ");
			Console.WriteLine($"Located in floor number: {floorNumber} ");
			Console.WriteLine($"The room size is: {roomSize} ");
			Console.WriteLine($"The price for the room per night is £{roomPrice} ");
			//Console.WriteLine($"The room status: {roomStatus} ");
			
		}

		//this to compare the rooms based on their room price it takes the room price that was initialy given to the constructor
		//and compares it to the arguments room price and then is sorting from cheaper to more expansive
        public int CompareTo( Rooms other)
        {
			return this.roomPrice.CompareTo(other.roomPrice);
        }

		//check westminster class line 356
        public virtual void WriteToFile(StreamWriter streamWriter)
        {
            //Console.WriteLine("Please find the rooms information.");
            streamWriter.WriteLine($"The Room Number is: {roomNumber} ");
            streamWriter.WriteLine($"Located in floor number: {floorNumber} ");
            streamWriter.WriteLine($"The room size is: {roomSize} ");
            streamWriter.WriteLine($"The price for the room per night is £{roomPrice} ");
            //Console.WriteLine($"The room status: {roomStatus} ");

        }
    }
}

