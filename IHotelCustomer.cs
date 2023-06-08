using System;
namespace HotelManagement
{
	//the implementation of the logic starts with this interface in the class WestminsterHotel
	public interface IHotelCustomer
	{
		public void ListAvailableRooms(Booking wantedBooking, string roomSize);

		public void ListAvailableRooms(Booking wantedBooking, string roomSize, int maxPrice);

		public bool BookRoom( Booking wantedBooking, int roomNumber);
	}
}

