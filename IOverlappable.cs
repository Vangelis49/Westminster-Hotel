using System;
namespace HotelManagement
{
	//IOverlappable interface is been used to prevent two same booking dates for a particular room (overlapping)
	public interface IOverlappable
	{
		public bool Overlap(Booking other);
	}
}

