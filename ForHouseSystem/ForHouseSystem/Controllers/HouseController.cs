using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForHouseApplication.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ForHouseSystem.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]/[action]")]
	[EnableCors("any")]
	public class HouseController : Controller
    {
		private readonly IHouseApplication _houseApplication;

		public HouseController(IHouseApplication houseApplication)
		{
			_houseApplication = houseApplication;
		}

		#region 公共
		[HttpGet]
		public JsonResult GetAllCharacteristic()
		{
			var reasult = _houseApplication.GetAllCharacteristic();
			return Json(reasult);
		}
		[HttpGet]
		public JsonResult GetRecommandHouseList()
		{
			var reasult = _houseApplication.GetRecommandHouseList();
			return Json(reasult);
		}
		[HttpGet]
		public JsonResult GetAllHouse(int houseType, string Characteristic, string keyword)
		{
			var reasult = _houseApplication.GetAllHouse(houseType,Characteristic,keyword);
			return Json(reasult);
		}
		#endregion

		#region 前台
		//[Authorize]
		[HttpGet]
		public JsonResult GetMyFeel(int houseId, int userId)
		{
			var reasult = _houseApplication.GetMyFeel(houseId,userId);
			return Json(reasult);
		}
		//[Authorize]
		[HttpPut]
		public JsonResult PassOrder(string contactWay, int userId, int houseId)
		{
			bool reasult = _houseApplication.PassOrder(contactWay,userId,houseId);
			string message = null;
			if (reasult == false)
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
		public JsonResult CancelOrder(int userId, int houseId)
		{
			bool reasult = _houseApplication.CancelOrder(userId,houseId);
			string message = null;
			if (reasult == false)
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
		[HttpPost]
		public JsonResult ExpressFeel(int houseId, int userId, int feelType)
		{
			bool reasult = _houseApplication.ExpressFeel(houseId,userId ,feelType);
			string message = null;
			if (reasult == false)
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
		[HttpPost]
		public object AddCharacteristic(string content)
		{
			bool reasult = _houseApplication.AddCharacteristic(content);
			string message = null;
			if (reasult == false)
			{
				message = "失败";
				return message;
			}
			else
			{
				message = "成功";
				return message;
			}
		}
		//[Authorize]
		[HttpPost]
		public JsonResult AddHouse(int userId, string title,int type, int[] characteristic, decimal money, string summary, string place, string bargainContent, string images)
		{
			bool reasult = _houseApplication.AddHouse(userId,title,type,characteristic,money,summary,place,bargainContent, images);
			string message = null;
			if (reasult == false)
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
		#region 后台
		[Authorize]
		[HttpGet]
		public JsonResult GetAllPublicHouse()
		{
			var reasult = _houseApplication.GetAllPublicHouse();
			return Json(reasult);
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetAllUnPublishHouse()
		{
			var reasult = _houseApplication.GetAllUnPublishHouse();
			return Json(reasult);
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetAllDeletedHouse()
		{
			var reasult = _houseApplication.GetAllDeletedHouse();
			return Json(reasult);
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetAllOrder()
		{
			var reasult = _houseApplication.GetAllOrder();
			return Json(reasult);
		}

		//[Authorize]
		[HttpPut]
		public JsonResult PublishHouse(int houseId)
		{
			bool reasult = _houseApplication.PublishHouse(houseId);
			string message = null;
			if (reasult == false)
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
		[HttpDelete]
		public JsonResult DeleteHouse(int houseId,string reason)
		{
			bool reasult = _houseApplication.DeleteHouse(houseId,reason);
			string message = null;
			if (reasult == false)
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
		public JsonResult CancelDeleteHouse(int houseId)
		{
			bool reasult = _houseApplication.CancelDeleteHouse(houseId);
			string message = null;
			if (reasult == false)
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

	}
}