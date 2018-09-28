using ForHouseCore.House;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForHouseApplication.House
{
	public class HouseApplication : IHouseApplication
	{
		private readonly HouseManage _commentManage = new HouseManage();
		public bool AddCharacteristic(string content)
		{
			return _commentManage.AddCharacteristic(content);
		}

		public bool AddHouse(int userId, string title,int type, int[] characteristic, decimal money, string summary, string place, string bargainContent, string images)
		{
			return _commentManage.AddHouse(userId, title,type, characteristic, money, summary, place, bargainContent, images);
		}

		public bool CancelDeleteHouse(int houseId)
		{
			return _commentManage.CancelDeleteHouse(houseId);
		}

		public bool CancelOrder(int userId, int houseId)
		{
			return _commentManage.CancelOrder(userId, houseId);
		}

		public bool DeleteHouse(int houseId, string reason)
		{
			return _commentManage.DeleteHouse(houseId,reason);
		}

		public bool ExpressFeel(int houseId, int userId, int feelType)
		{
			return _commentManage.ExpressFeel(houseId, userId, feelType);
		}

		public object GetAllCharacteristic()
		{
			return _commentManage.GetAllCharacteristic();
		}

		public object GetAllDeletedHouse()
		{
			return _commentManage.GetAllDeletedHouse();
		}

		public object GetAllHouse(int houseType, string Characteristic, string keyword)
		{
			return _commentManage.GetAllHouse(houseType, Characteristic, keyword);
		}

		public object GetAllOrder()
		{
			return _commentManage.GetAllOrder();
		}

		public object GetAllPublicHouse()
		{
			return _commentManage.GetAllPublicHouse();
		}

		public object GetAllUnPublishHouse()
		{
			return _commentManage.GetAllUnPublishHouse();
		}

		public object GetMyFeel(int houseId, int userId)
		{
			return _commentManage.GetMyFeel(houseId, userId);
		}

		public object GetRecommandHouseList()
		{
			return _commentManage.GetRecommandHouseList();
		}

		public bool OrderHouse(int userId, int houseId, string place, DateTime time, int type, string contactWay)
		{
			return _commentManage.OrderHouse(userId, houseId, place, time, type, contactWay);
		}

		public bool PassOrder(string contactWay, int userId, int houseId)
		{
			return _commentManage.PassOrder(contactWay, userId, houseId);
		}

		public bool PublishHouse(int houseId)
		{
			return _commentManage.PublishHouse(houseId);
		}
	}
}
