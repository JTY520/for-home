using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ForHouseApplication.Comment;
using ForHouseApplication.House;
using ForHouseApplication.User;
using ForHouseEntity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ForHouseSystem.Controllers
{
    [Produces("application/json")]
	[Route("api/[controller]/[action]")]
	[EnableCors("any")]
	public class UserController : Controller
    {
		private readonly IUserApplication _userApplication;
		private readonly ICommentApplication _commentApplication;
		private readonly IHouseApplication _houseApplication ;
		public IConfiguration _configuration;
		public UserController(IUserApplication userApplication, ICommentApplication commentApplication, IHouseApplication houseApplication, IConfiguration configuration)
		{
			_userApplication = userApplication;
			_commentApplication = commentApplication;
			_houseApplication = houseApplication;
			_configuration = configuration;
		}

		#region 公共
		[HttpPost]
		public JsonResult Login(string userName, string password)
		{
			UserTable user = _userApplication.Login(userName, password);
			if (user == null)
				return Json(false);
			else
			{
				//var result = new
				//{
				//	userInfo = new
				//	{
				//		id = user.UserId,
				//		account = user.UserAccount,
				//		nikename = user.UserNickName,
				//	},
				//	//token = Token(userName, password).Result.Value
				//};
				return Json(user);
			}
		}

		[HttpPost]
		public JsonResult Register(string phone,string account,string password)
		{
			bool result = _userApplication.Register(phone, account, password);
			string message = null;
			if (result == false)
			{
				message = "失败";
				return Json(message);
			}
			else
			{
				message = "成功";
				return Json(message);
			}
		}
		#endregion

		#region 个人信息
		//[Authorize]
		[HttpGet]
		public JsonResult GetUserMessage(int userId)
		{
			UserTable user = _userApplication.GetUserMessage(userId);
			return Json(user);
		}
		//[Authorize]
		[HttpPut]
		public JsonResult ModifyPassword(int userId, string newPassword, string oldPassword)
		{
			bool result = _userApplication.ModifyPassword(userId, newPassword, oldPassword);
			string message = null;
			if (result == false)
			{
				message = "失败";
				return Json(message);
			}
			else
			{
				message = "成功";
				return Json(message);
			}
		}
		//[Authorize]
		[HttpPut]
		public JsonResult ModifyInformation(int userId, string userNickName, string userPhone, string UserMail)
		{
			bool result = _userApplication.ModifyInformation(userId, userNickName, userPhone,UserMail);
			string message = null;
			if (result == false)
			{
				message = "失败";
				return Json(message);
			}
			else
			{
				message = "成功";
				return Json(message);
			}
		}
		//[Authorize]
		[HttpPut]
		public JsonResult ModifyHeadPhoto(int userId, string photo)
		{
			bool result = _userApplication.ModifyHeadPhoto(userId, photo);
			string message = null;
			if (result == false)
			{
				message = "失败";
				return Json(message);
			}
			else
			{
				message = "成功";
				return Json(message);
			}
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetPassedOrder(int userId)
		{
			var result = _userApplication.GetPassedOrder(userId);
			return Json(result);
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetUnPassedOrder(int userId)
		{
			var result = _userApplication.GetPassedOrder(userId);
			return Json(result);
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetMyPassOrder(int userId)
		{
			var result = _userApplication.GetPassedOrder(userId);
			return Json(result);
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetMyUnPassedOrder(int userId)
		{
			var result = _userApplication.GetMyUnPassedOrder(userId);
			return Json(result);
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetMyHouses(int userId)
		{
			var result = _userApplication.GetMyHouses(userId);
			return Json(result);
		}
		#endregion

		#region 后台
		//[Authorize]
		[HttpDelete]
		public JsonResult DeleteUser(int userId)
		{
			var result = _userApplication.DeleteUser(userId);
			return Json(result);
		}


		#endregion


		//#region Token
		//[HttpPost]
		//public async Task<JsonResult> Token(string userName, string password)
		//{
		//	var context = HttpContext;
		//	var userClaims = await GetTokenClaims(userName, password);
		//	if (userClaims == null)
		//	{
		//		context.Response.StatusCode = 500;
		//		await context.Response.WriteAsync(JsonConvert.SerializeObject("账号或密码错误!"));
		//		return Json("");
		//	}
		//	var audienceConfig = _configuration.GetSection("TokenAuthentication:Audience").Value;
		//	var symmetricKeyAsBase64 = _configuration.GetSection("TokenAuthentication:SecretKey").Value;
		//	var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
		//	var signingKey = new SymmetricSecurityKey(keyByteArray);
		//	var jwtToken = new JwtSecurityToken(
		//		issuer: audienceConfig,
		//		audience: audienceConfig,
		//		claims: userClaims,
		//		expires: DateTime.UtcNow.AddMinutes(10),
		//		signingCredentials: new SigningCredentials(
		//			signingKey,
		//			SecurityAlgorithms.HmacSha256)
		//	   );
		//	var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
		//	var token_bearer = "Bearer " + token;
		//	var response = new
		//	{
		//		IsSuccess = true,
		//		Data = new
		//		{
		//			token = token_bearer,
		//			expiration = jwtToken.ValidTo
		//		}
		//	};
		//	//context.Response.ContentType = "application/json";
		//	//await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings
		//	//{
		//	//    Formatting = Formatting.Indented
		//	//}));
		//	return Json(response);
		//}
		
		//[HttpGet]
		//private async Task<IEnumerable<Claim>> GetTokenClaims(string account, string password)
		//{
		//	if (_userApplication.Login(account, password) != null)
		//		return new List<Claim>
		//			{
		//				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
		//				new Claim(JwtRegisteredClaimNames.Sub, account)
		//			};
		//	return null;
		//}

		//[HttpGet]

		//[Authorize]

		//public async Task<JsonResult> Values()
		//{
		//	return Json(new List<string> { "values1", "values2" });
		//}
		//#endregion
	}
}
