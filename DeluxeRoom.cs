using System;
using System.IO;

namespace HotelManagement
{
	//inherits from parent class Rooms
	public class DeluxeRoom : Rooms
	{
		private double sizeOfBalcony;
		private string view;

		public DeluxeRoom(int roomNumber, int floorNumber, string roomSize, double roomPrice,double sizeOfBalcony,string view)
			:base(roomNumber,floorNumber,roomSize,roomPrice)
		{
			this.sizeOfBalcony = sizeOfBalcony;
			this.view = view;
		}

		public double GetSizeOfBalcony()
		{
			return sizeOfBalcony;
		}

		public string GetView()
		{
			return view;
		}

        public override void Display()
        {
            base.Display();
			Console.WriteLine($"The size of the balcony in squere meters: {sizeOfBalcony}");
            Console.WriteLine($"And for a Deluxe room the view is: {view}");

        }
        //westminster class line 354
        public override void WriteToFile(StreamWriter streamwriter)
        {
            base.WriteToFile(streamwriter);
            streamwriter.WriteLine($"The size of the balcony in squere meters: {sizeOfBalcony}");
            streamwriter.WriteLine($"And for a Deluxe room the view is: {view}");
        }
    }
}

