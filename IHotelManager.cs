using System;
namespace HotelManagement
{
	//the implementation of the IHotelManager interface: WestminsterHotel class inherits from it all the methods
	//and the logic of the programme is implemented there
	public interface IHotelManager
	{
		public bool AddRoom(Rooms room);

		public bool DeleteRoom(int roomNumber);

		public void ListRooms();

		public void ListRoomsOrderedByPrice();

		public void GenerateReport(string fileName);


	}
}

