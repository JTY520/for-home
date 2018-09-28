using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForHouseApplication.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForHouseSystem.Controllers
{
	[Produces("application/json")]
	[Route("api/[controller]/[action]")]
	[EnableCors("any")]
	public class CommentController : Controller
    {
		private readonly ICommentApplication _commentApplication ;
		public CommentController(ICommentApplication commentApplication)
		{
			_commentApplication = commentApplication;
		}
		//[Authorize]
		[HttpPost]
		public JsonResult AddComment(string content, int houseId, int userId)
		{
			bool reasult = _commentApplication.AddComment(content, houseId,userId );
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
		public JsonResult PublishComment(int commentId)
		{
			bool reasult = _commentApplication.PublishComment(commentId);
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
		public JsonResult DeleteComment(int commentId)
		{
			bool reasult = _commentApplication.DeleteComment(commentId);
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
		[HttpGet]
		public JsonResult GetAllComment(int houseId)
		{
			var reasult = _commentApplication.GetAllComment(houseId);
			return Json(reasult);
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetAllPublicComments()
		{
			var reasult = _commentApplication.GetAllPublicComments();
			return Json(reasult);
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetAllUnPublicComments()
		{
			var reasult = _commentApplication.GetAllUnPublicComments();
			return Json(reasult);
		}
		//[Authorize]
		[HttpGet]
		public JsonResult GetAllDeleteComment()
		{
			var reasult = _commentApplication.GetAllDeleteComment();
			return Json(reasult);
		}
		//[Authorize]
		[HttpPut]
		public JsonResult CancelDeleteComment(int commentId)
		{
			bool reasult = _commentApplication.CancelDeleteComment(commentId);
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
	}
}