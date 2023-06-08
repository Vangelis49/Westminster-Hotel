using System;
using System.IO;

namespace HotelManagement
{
	//inherits from parent class Rooms
	public class StandardRoom : Rooms
	{
		//a standard room has a given number of windows
		private int numberOfWindows;

		public StandardRoom(int roomNumber, int floorNumber, string roomSize, double roomPrice,int numberOfWindows)
			:base(roomNumber,floorNumber,roomSize,roomPrice)
		{
			this.numberOfWindows = numberOfWindows;
		}

		public int GetNumberOfWindows()
		{
			return numberOfWindows;
		}

        public override void Display()
        {
            base.Display();
			Console.WriteLine($"The number of windows for the the standard room: {numberOfWindows}");
        }

		//westminster class line 354
        public override void WriteToFile(StreamWriter streamwriter)
        {
            base.WriteToFile(streamwriter);
            streamwriter.WriteLine($"The number of windows for the the standard room: {numberOfWindows}");
        }
    }
}

