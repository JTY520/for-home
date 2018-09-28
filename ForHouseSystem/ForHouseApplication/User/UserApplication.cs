using ForHouseCore.User;
using ForHouseEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForHouseApplication.User
{
	public class UserApplication : IUserApplication
	{
		private readonly UserManage _userManage = new UserManage();
		public bool DeleteUser(int userId)
		{
			return _userManage.DeleteUser(userId);
		}

		public object GetMyHouses(int userId)
		{
			return _userManage.GetMyHouses(userId);
		}

		public object GetMyPassOrder(int userId)
		{
			return _userManage.GetMyPassOrder(userId);
		}

		public object GetMyUnPassedOrder(int userId)
		{
			return _userManage.GetMyUnPassedOrder(userId);
		}

		public object GetPassedOrder(int userId)
		{
			return _userManage.GetPassedOrder(userId);
		}

		public object GetUnPassedOrder(int userId)
		{
			return _userManage.GetUnPassedOrder(userId);
		}

		public object GetUserMessage(int userId)
		{
			return _userManage.GetUserMessage(userId);
		}
		public UserTable Login( string userName, string password)
		{
			return _userManage.Login( userName, password);
		}

		public bool ModifyHeadPhoto(int userId, string photo)
		{
			return _userManage.ModifyHeadPhoto(userId, photo);
		}

		public bool ModifyInformation(int userId, string userNickName, string userPhone, string UserMail)
		{
			return _userManage.ModifyInformation(userId, userNickName, userPhone, UserMail);
		}

		public bool ModifyPassword(int userId, string newPassword, string oldPassword)
		{
			return _userManage.ModifyPassword(userId, newPassword, oldPassword);
		}

		public bool Register(string phone, string account, string password)
		{
			return _userManage.Register(phone, account, password);
		}

		UserTable IUserApplication.GetUserMessage(int UserId)
		{
			throw new NotImplementedException();
		}
	}
}
