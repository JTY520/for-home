using ForHouseEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForHouseCore.User
{
    public class UserManage
    {
		private readonly ForHouseContext forHouseContext = new ForHouseContext();
		public UserTable Login(string userName, string password)
		{
			string[] type = userName.Split("_");
			UserTable user = new UserTable();
			if (type[0].Contains("account"))
			{
				 user= forHouseContext.UserTable.SingleOrDefault(u => u.UserAccount.Equals(type[1]) && u.UserPassword.Equals(password) && u.IsDelete == false);
			}
			else{
				user = forHouseContext.UserTable.SingleOrDefault(u => u.UserPhone.Equals(type[1]) && u.UserPassword.Equals(password) && u.IsDelete == false);
			}
			return user ?? null;
		}
		public bool Register(string phone,string account, string password)
		{
			var isUser = forHouseContext.UserTable.Where(u => u.UserAccount == account || u.UserPhone == phone).ToList();
			if(isUser != null)
			{
				UserTable user = new UserTable()
				{
					UserPhone = phone,
					UserAccount = account,
					UserPassword = password,
					IsDelete = false
				};
				forHouseContext.UserTable.Add(user);
				forHouseContext.SaveChanges();
				return true;
			}
			return false;
		}
		public bool ModifyPassword(int userId,string newPassword,string oldPassword)
		{
			UserTable user = forHouseContext.UserTable.Find(userId);
			if (user.UserPassword == oldPassword)
			{
				user.UserPassword = newPassword;
				forHouseContext.SaveChanges();
				return true;
			}
			return false;
		}
		public bool ModifyInformation(int userId, string userNickName, string userPhone, string UserMail)
		{
			UserTable user = forHouseContext.UserTable.Find(userId);
			if (user != null)
			{
				if(userNickName != " ")
				{
					user.UserNickName = userNickName;
				}
				if(userPhone != " ")
				{
					user.UserPhone = userPhone;
				}
				if(UserMail != " ")
				{
					user.UserMail = UserMail;
				}
				forHouseContext.SaveChanges();
				return true;
			}
			return false;
		}
		public bool ModifyHeadPhoto(int userId,string photo)
		{
			UserTable user = forHouseContext.UserTable.Find(userId);
			user.UserPhoto = photo;
			forHouseContext.SaveChanges();
			return true;
		}
		public UserTable GetUserMessage(int UserId)
		{
			UserTable user = forHouseContext.UserTable.Find(UserId);
			return user;
		}
		public object GetPassedOrder(int userId)//myhouse
		{
			var list = (from m in forHouseContext.OrderTable
						where m.MasterId == userId && m.IsAccepted == true
						join h in forHouseContext.HouseTable on m.MasterId equals h.MasterId
						join u in forHouseContext.UserTable on m.MasterId equals u.UserId
						select new
						{
							houseTitle = h.Title,
							houseMasterPhone = u.UserPhone,
							orderPlace = m.OrderPlace,
							orderTime = m.OrderPlace,
							type = m.OrderType,
							orderIsPass = m.IsAccepted,
							houseId = m.HouseId,
							masterId = m.MasterId,
							contactWay = m.ContactWay,
						}).ToList();
			return list ?? null;
		}
		public object GetUnPassedOrder(int userId)
		{
			var list = (from m in forHouseContext.OrderTable
						where m.MasterId == userId && m.IsAccepted == false
						join h in forHouseContext.HouseTable on m.MasterId equals h.MasterId
						join u in forHouseContext.UserTable on m.MasterId equals u.UserId
						select new
						{
							houseTitle = h.Title,
							houseMasterPhone = u.UserPhone,
							orderPlace = m.OrderPlace,
							orderTime = m.OrderPlace,
							type = m.OrderType,
							orderIsPass = m.IsAccepted,
							houseId = m.HouseId,
							masterId = m.MasterId,
							contactWay = m.ContactWay,
						}).ToList();
			return list ?? null;
		}
		public object GetMyPassOrder(int userId)
		{
			var list = (from m in forHouseContext.OrderTable
						where m.UserId == userId && m.IsAccepted == true
						join h in forHouseContext.HouseTable on m.MasterId equals h.MasterId
						join u in forHouseContext.UserTable on m.MasterId equals u.UserId
						select new
						{
							houseTitle = h.Title,
							houseMasterPhone = u.UserPhone,
							orderPlace = m.OrderPlace,
							orderTime = m.OrderPlace,
							type = m.OrderType,
							orderIsPass = m.IsAccepted,
							houseId = m.HouseId,
							masterId = m.MasterId,
							contactWay = m.ContactWay,
						}).ToList();
			return list ?? null;
		}
		public object GetMyUnPassedOrder(int userId)
		{
			var list = (from m in forHouseContext.OrderTable
						where m.UserId == userId && m.IsAccepted == false
						join h in forHouseContext.HouseTable on m.MasterId equals h.MasterId
						join u in forHouseContext.UserTable on m.MasterId equals u.UserId
						select new
						{
							houseTitle = h.Title,
							houseMasterPhone = u.UserPhone,
							orderPlace = m.OrderPlace,
							orderTime = m.OrderPlace,
							type = m.OrderType,
							orderIsPass = m.IsAccepted,
							houseId = m.HouseId,
							masterId = m.MasterId,
							contactWay = m.ContactWay,
						}).ToList();
			return list ?? null;
		}
		public List<HouseTable> GetMyHouses(int userId)
		{
			List<HouseTable> list = forHouseContext.HouseTable.Where(h => h.MasterId == userId).ToList();
			return list ?? null;
		}
		public bool DeleteUser(int userId)
		{
			UserTable user = forHouseContext.UserTable.Find(userId);
			user.IsDelete = true;
			return true;
		}
	}

}
