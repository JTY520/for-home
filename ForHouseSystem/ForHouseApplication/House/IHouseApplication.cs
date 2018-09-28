using System;
using System.Collections.Generic;
using System.Text;

namespace ForHouseApplication.House
{
    public interface IHouseApplication
    {
		bool AddHouse(int userId, string title, int type, int[] characteristic, decimal money, string summary, string place, string bargainContent, string images);
		bool PublishHouse(int houseId);
		bool DeleteHouse(int houseId, string reason);
		bool CancelDeleteHouse(int houseId);
		object GetAllCharacteristic();
		object GetRecommandHouseList();
		bool ExpressFeel(int houseId, int userId, int feelType);
		object GetMyFeel(int houseId, int userId);
		object GetAllPublicHouse();
		object GetAllUnPublishHouse();
		object GetAllDeletedHouse();
		object GetAllOrder();
		bool OrderHouse(int userId, int houseId, string place, DateTime time, int type, string contactWay);
		bool AddCharacteristic(string content);
		object GetAllHouse(int houseType, string Characteristic, string keyword);

		bool PassOrder(string contactWay, int userId, int houseId);
		bool CancelOrder(int userId, int houseId);
	}
}
