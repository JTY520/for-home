using System;
using System.Collections.Generic;
using System.Text;

namespace ForHouseApplication.Comment
{
    public interface ICommentApplication
    {

		bool AddComment(string content, int houseId, int userId);

		bool PublishComment(int commentId);

		bool DeleteComment(int commentId);
		object GetAllComment(int houseId);
		object GetAllPublicComments();
		object GetAllUnPublicComments();
		object GetAllDeleteComment();
		bool CancelDeleteComment(int commentId);

	}
}
