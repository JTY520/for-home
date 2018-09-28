using ForHouseEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForHouseCore.House
{
    public class HouseManage
    {
		private readonly ForHouseContext forHouseContext = new ForHouseContext();
		public bool AddHouse(int userId,string title, int type, int[] characteristic,decimal money,string summary,string place,string bargainContent,string images) 
		{
			HouseTable house = new HouseTable()
			{
				Title = title,
				HouseBargainContent = bargainContent,
				HouseSummary = summary,
				HouseType = type,
				HousePlace = place,
				HouseMoney = money,
				NumberOfLike = 0,
				NumberOfDiss = 0,
				IsDone = false,
				IsPublic = false,
				IsDelete = false,
				MasterId = userId,
				PublicTime = DateTime.Now,
				Images = images
			};
			house.Characteristic = AddHouseCharacter(characteristic);
			forHouseContext.SaveChanges();
			return true;
		}
		public string AddHouseCharacter(int[] characteristic)
		{
			string cha = null;
			if (characteristic != null)
			{
				foreach (int a in characteristic)
				{
					cha = cha + "_" + forHouseContext.CharacteristicTable.Find(a).CharacteristicName;
				}
			}
			return cha ?? null;
		}
		public bool PublishHouse(int houseId)
		{
			var house = forHouseContext.HouseTable.Find(houseId);
			house.IsPublic = true;
			house.IsDelete = false;
			house.PublicTime = DateTime.Now;
			forHouseContext.SaveChanges();
			return true;
		}
		public bool DeleteHouse(int houseId,string reason)
		{
			var house = forHouseContext.HouseTable.Find(houseId);
			house.IsPublic = false;
			house.IsDelete = true;
			if (reason != null)
			{
				house.DeleteReason = reason;
			}
			forHouseContext.SaveChanges();
			return true;
		}
		public bool CancelDeleteHouse(int houseId)
		{
			var house = forHouseContext.HouseTable.Find(houseId);
			house.IsPublic = true;
			house.IsDelete = false;
			forHouseContext.SaveChanges();
			return true;
		}
		public List<CharacteristicTable> GetAllCharacteristic()
		{
			List<CharacteristicTable> list = forHouseContext.CharacteristicTable.ToList();
			return list ?? null;
		}
		public List<HouseTable> GetRecommandHouseList()
		{
			List<HouseTable> list = (List<HouseTable>)forHouseContext.HouseTable.ToList().OrderByDescending(m=>m.NumberOfLike).Take(4);
			return list??null;
		}
		//点赞,踩及取消
		public bool ExpressFeel(int houseId,int userId,int feelType)
		{
			var feel = forHouseContext.FeelOfHouse.SingleOrDefault(f => f.HouseId == houseId && f.UserId == userId);
			if(feel == null)
			{
				FeelOfHouse myFeel = new FeelOfHouse()
				{
					UserId = userId,
					HouseId = houseId,
					FeelType = feelType
				};
				forHouseContext.FeelOfHouse.Add(myFeel);
				var house = forHouseContext.HouseTable.Find(houseId);
				if(feelType == 1)
				{
					house.NumberOfLike = house.NumberOfLike ++;
				}
				else
				{
					house.NumberOfDiss = house.NumberOfDiss++;
				}
				forHouseContext.SaveChanges();
				return true;
			}
			else if(feel.FeelType == feelType)
			{
				feel.FeelType = 0;
				var house = forHouseContext.HouseTable.Find(houseId);
				if (feelType == 1)
				{
					house.NumberOfLike = house.NumberOfLike--;
				}
				else
				{
					house.NumberOfDiss = house.NumberOfDiss--;
				}
				forHouseContext.SaveChanges();
				return true;
			}
			else if(feel.FeelType == 0)
			{
				feel.FeelType = feelType;
				var house = forHouseContext.HouseTable.Find(houseId);
				if (feelType == 1)
				{
					house.NumberOfLike = house.NumberOfLike++;
				}
				else
				{
					house.NumberOfDiss = house.NumberOfDiss++;
				}
				forHouseContext.SaveChanges();
				return true;
			}
			return false;
		}
		public FeelOfHouse GetMyFeel(int houseId, int userId)
		{
			var feel = forHouseContext.FeelOfHouse.SingleOrDefault(f => f.HouseId == houseId && f.UserId == userId);
			return feel ?? null;
		}

		public object GetAllPublicHouse()
		{
			var list = (from h in forHouseContext.HouseTable
						where h.IsDelete == false && h.IsPublic == true
						join m in forHouseContext.UserTable on h.MasterId equals m.UserId
						select new
						{
							title = h.Title,
							type = h.HouseType,
							publiciTime = h.PublicTime,
							summary = h.HouseSummary,
							bargin = h.HouseBargainContent,
							houseId = h.HouseId,
							masterAccount = m.UserAccount,
							place = h.HousePlace,
							masterNick = m.UserNickName,
							character = h.Characteristic
						}).OrderByDescending(x => x.publiciTime).ToList();
			return list ?? null;
		}

		public object GetAllUnPublishHouse()
		{
			var list = (from h in forHouseContext.HouseTable
						where h.IsDelete == false && h.IsPublic == false
						join m in forHouseContext.UserTable on h.MasterId equals m.UserId
						select new
						{
							title = h.Title,
							type = h.HouseType,
							publiciTime = h.PublicTime,
							summary = h.HouseSummary,
							bargin = h.HouseBargainContent,
							houseId = h.HouseId,
							masterAccount = m.UserAccount,
							place = h.HousePlace,
							masterNick = m.UserNickName,
							character = h.Characteristic
						}).OrderByDescending(x => x.publiciTime).ToList();
			return list ?? null;
		}
		public object GetAllDeletedHouse()
		{
			var list = (from h in forHouseContext.HouseTable
						where h.IsDelete == true
						join m in forHouseContext.UserTable on h.MasterId equals m.UserId
						select new
						{
							title = h.Title,
							type = h.HouseType,
							publiciTime = h.PublicTime,
							summary = h.HouseSummary,
							bargin = h.HouseBargainContent,
							houseId = h.HouseId,
							masterAccount = m.UserAccount,
							place = h.HousePlace,
							masterNick = m.UserNickName,
							character = h.Characteristic
						}).OrderByDescending(x => x.publiciTime).ToList();
			return list ?? null;
		}
		public object GetAllOrder()
		{
			var list = (from m in forHouseContext.OrderTable
						join h in forHouseContext.HouseTable on m.HouseId equals h.HouseId
						join u in forHouseContext.UserTable on m.MasterId equals u.UserId
						select new
						{
							master = u.UserAccount,
							house = h.Title,
							time = m.OrderTime,
							type = m.OrderType,
							place = m.OrderPlace,
							contactWay = m.ContactWay,
							houseId = m.HouseId,
							masterId = m.MasterId,
						}).ToList();
			return list ?? null;
		}
		public bool OrderHouse(int userId,int houseId,string place,DateTime time,int type,string contactWay)
		{
			var isExit = forHouseContext.OrderTable.SingleOrDefault(o => o.UserId == userId && o.HouseId == houseId);
			if(isExit == null)
			{
				OrderTable order = new OrderTable()
				{
					UserId = userId,
					OrderCreateTime = DateTime.Now,
					OrderPlace = place,
					OrderTime = time,
					OrderType = type,
					IsAccepted = false,
					ContactWay = contactWay,
					HouseId = houseId,
					MasterId = forHouseContext.HouseTable.SingleOrDefault(h=>h.HouseId == houseId).MasterId,
				};
				forHouseContext.OrderTable.Add(order);
				forHouseContext.SaveChanges();
				return true;
			}
			else if(isExit.IsAccepted == false)
			{
				isExit.OrderCreateTime = DateTime.Now;
				isExit.OrderPlace = place;
				isExit.OrderTime = time;
				isExit.OrderType = type;
				isExit.IsAccepted = false;
				//isExit.ContactWay = contactWay
				forHouseContext.SaveChanges();
				return true;
			}
			else if(isExit.OrderTime < DateTime.Now)
			{
				isExit.OrderCreateTime = DateTime.Now;
				isExit.OrderPlace = place;
				isExit.OrderTime = time;
				isExit.OrderType = type;
				isExit.IsAccepted = false;
				//isExit.ContactWay = contactWay
				forHouseContext.SaveChanges();
				return true;
			}
			return false;
		}
		public bool AddCharacteristic(string content)
		{
			var cha = forHouseContext.CharacteristicTable.SingleOrDefault(c => c.CharacteristicName == content);
			if (cha == null)
			{
				CharacteristicTable characteristic = new CharacteristicTable()
				{
					CharacteristicName = content,
					IsDelete = false,
				};
				forHouseContext.CharacteristicTable.Add(characteristic);
				forHouseContext.SaveChanges();
				return true;
			}
			return false;
		}
		public bool PassOrder(string contactWay,int userId,int houseId)
		{
			var order = forHouseContext.OrderTable.SingleOrDefault(o => o.UserId == userId && o.HouseId == houseId);
			order.IsAccepted = true;
			order.ContactWay = order.ContactWay +"/"+ contactWay;
			forHouseContext.SaveChanges();
			return true;
		}
		public bool CancelOrder(int userId, int houseId)
		{
			var order = forHouseContext.OrderTable.SingleOrDefault(o => o.UserId == userId && o.HouseId == houseId);
			order.IsAccepted = false;
			forHouseContext.SaveChanges();
			return true;
		}
		public bool DeleteCharacteristic(int characteristicId)
		{
			var characteristic = forHouseContext.CharacteristicTable.Find(characteristicId);
			characteristic.IsDelete = true;
			forHouseContext.SaveChanges();
			return true;
		}
		public object GetAllHouse(int houseType,string Characteristic, string keyword)
		{
			var list = (from h in forHouseContext.HouseTable
						join m in forHouseContext.UserTable on h.MasterId equals m.UserId
						where h.IsDelete == false && h.IsPublic == true
						select new
						{
							title = h.Title,
							type = h.HouseType,
							publiciTime = h.PublicTime,
							summary = h.HouseSummary,
							bargin = h.HouseBargainContent,
							houseId = h.HouseId,
							masterAccount = m.UserAccount,
							place = h.HousePlace,
							masterNick = m.UserNickName,
							character = h.Characteristic
						}).OrderByDescending(x=>x.publiciTime).ToList();
			if (houseType == 0 && Characteristic == "" && keyword == "")
			{
				return list;
			}
			if(list != null)
			{
				if (Characteristic != "" && Characteristic != null && list != null)
				{
					 list = list.Where(c => c.character.Contains(Characteristic)).ToList();
				}
				if(houseType != 0 && houseType != null && list != null){
					list = list.Where(t => t.type == houseType).ToList();
				}
				if(keyword != "" && keyword != null && list != null)
				{
					list = list.Where(h => h.place.Contains(keyword) == true || h.title.Contains(keyword) == true).ToList();
				}
				return list??null;
			}
			return null;
		}
		public object GetHouseDetial(int houseId)
		{
			var house = (from h in forHouseContext.HouseTable
						 where h.HouseId == houseId
						 join m in forHouseContext.UserTable on h.MasterId equals m.UserId
						 select new
						 {
							 title = h.Title,
							 type = h.HouseType,
							 publiciTime = h.PublicTime,
							 summary = h.HouseSummary,
							 bargin = h.HouseBargainContent,
							 houseId = h.HouseId,
							 place = h.HousePlace,
							 masterAccount = m.UserAccount,
							 masterNick = m.UserNickName,
							 character = h.Characteristic
						 }).ToList()[0];
			return house;
		}
	}
}
