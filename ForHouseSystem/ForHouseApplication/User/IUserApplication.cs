using ForHouseEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForHouseApplication.User
{
    public interface IUserApplication
    {
		UserTable Login(string userName, string password);
		bool Register(string phone, string account, string password);
		bool ModifyPassword(int userId,string newPassword,string oldPassword);
		bool ModifyInformation(int userId,string userNickName, string userPhone, string UserMail);
		bool ModifyHeadPhoto(int userId, string photo);
		UserTable GetUserMessage(int UserId);
		object GetPassedOrder(int userId);
		object GetUnPassedOrder(int userId);
		object GetMyPassOrder(int userId);
		object GetMyUnPassedOrder(int userId);
		object GetMyHouses(int userId);
		bool DeleteUser(int userId);

	}
}
