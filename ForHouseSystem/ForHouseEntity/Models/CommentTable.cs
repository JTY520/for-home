using System;
using System.Collections.Generic;

namespace ForHouseEntity.Models
{
    public partial class CommentTable
    {
        public int CommentId { get; set; }
        public int HouseId { get; set; }
        public int UserId { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentTime { get; set; }
        public bool IsDelete { get; set; }
        public bool IsUpdata { get; set; }
        public string DeleteReason { get; set; }
    }
}
