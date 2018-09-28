using ForHouseCore.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForHouseApplication.Comment
{
	public class CommentApplication : ICommentApplication
	{
		private readonly CommentManage _commentManage = new CommentManage();
		public bool AddComment(string content, int houseId, int userId)
		{
			return _commentManage.AddComment(content, houseId, userId);
		}

		public bool CancelDeleteComment(int commentId)
		{
			return _commentManage.CancelDeleteComment(commentId);
		}

		public bool DeleteComment(int commentId)
		{
			return _commentManage.DeleteComment(commentId);
		}

		public object GetAllComment(int houseId)
		{
			return _commentManage.GetAllComment(houseId);
		}

		public object GetAllDeleteComment()
		{
			return _commentManage.GetAllDeleteComment();
		}

		public object GetAllPublicComments()
		{
			return _commentManage.GetAllPublicComments();
		}

		public object GetAllUnPublicComments()
		{
			return _commentManage.GetAllUnPublicComments();
		}

		public bool PublishComment(int commentId)
		{
			return _commentManage.PublishComment(commentId);
		}
	}
}
