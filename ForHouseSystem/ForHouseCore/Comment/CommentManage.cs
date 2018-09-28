using ForHouseEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ForHouseCore.Comment
{
    public class CommentManage
    {
		private readonly ForHouseContext forHouseContext = new ForHouseContext();
		//Nullable<int> parentId
		public bool AddComment( string content, int houseId, int userId)
		{
			CommentTable comment = new CommentTable()
			{
				CommentContent = content,
				IsDelete = false,
				HouseId = houseId,
				UserId = userId,
				CommentTime = DateTime.Now,
				IsUpdata = false,
			};
			forHouseContext.CommentTable.Add(comment);
			forHouseContext.SaveChanges();
			return true;
		}
		public bool PublishComment(int commentId)
		{
			var comment = forHouseContext.CommentTable.Find(commentId);
			comment.IsUpdata = true;
			comment.IsDelete = false;
			forHouseContext.SaveChanges();
			return true;
		}
		public bool DeleteComment(int commentId)
		{
			var comment = forHouseContext.CommentTable.Find(commentId);
			comment.IsDelete = true;
			comment.IsUpdata = false;
			forHouseContext.SaveChanges();
			return true;
		}
		public object GetAllComment(int houseId)
		{
			var list = (from c in forHouseContext.CommentTable
						where c.HouseId == houseId && c.IsUpdata == true &&c.IsDelete == false
						join m in forHouseContext.UserTable on c.UserId equals m.UserId
						select new
						{
							commentId = c.CommentId,
							headPhoto = m.UserPhoto,
							account = m.UserAccount,
							content = c.CommentContent,
							time = c.CommentTime
						}).ToList();
			return list ?? null;
		}
		//public List<CommentTable> GetAllCommentChildren(int houseId,int parentId)//&& c.ParentId == parentId
		//{
		//	List<CommentTable> list = forHouseContext.CommentTable.Where(c => c.HouseId == houseId ).ToList();
		//	return list ?? null;
		//}
		public object GetAllPublicComments()
		{
			var list = (from c in forHouseContext.CommentTable
						where c.IsUpdata == true && c.IsDelete == false
						join m in forHouseContext.UserTable on c.UserId equals m.UserId
						join h in forHouseContext.HouseTable on c.HouseId equals h.HouseId
						select new
						{
							commentId = c.CommentId,
							title = h.Title,
							account = m.UserAccount,
							content = c.CommentContent,
							time = c.CommentTime
						}).ToList();
			return list ?? null;
		}
		public object GetAllUnPublicComments()
		{
			var list = (from c in forHouseContext.CommentTable
						where c.IsUpdata == false && c.IsDelete == false
						join m in forHouseContext.UserTable on c.UserId equals m.UserId
						join h in forHouseContext.HouseTable on c.HouseId equals h.HouseId
						select new
						{
							commentId = c.CommentId,
							title = h.Title,
							account = m.UserAccount,
							content = c.CommentContent,
							time = c.CommentTime
						}).ToList();
			return list ?? null;
		}
		public object GetAllDeleteComment()
		{
			var list = (from c in forHouseContext.CommentTable
						where c.IsDelete == true
						join m in forHouseContext.UserTable on c.UserId equals m.UserId
						join h in forHouseContext.HouseTable on c.HouseId equals h.HouseId
						select new
						{
							commentId = c.CommentId,
							title = h.Title,
							account = m.UserAccount,
							content = c.CommentContent,
							time = c.CommentTime
						}).ToList();
			return list ?? null;
		}
		//撤消并发布
		public bool CancelDeleteComment(int commentId)
		{
			var comment = forHouseContext.CommentTable.Find(commentId);
			comment.IsDelete = false;
			comment.IsUpdata = true;
			forHouseContext.SaveChanges();
			return true;
		}
	}
}
