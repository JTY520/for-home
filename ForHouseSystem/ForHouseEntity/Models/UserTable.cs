using System;
using System.Collections.Generic;

namespace ForHouseEntity.Models
{
    public partial class UserTable
    {
        public int UserId { get; set; }
        public string UserAccount { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoto { get; set; }
        public string UserNickName { get; set; }
        public string UserPhone { get; set; }
        public string UserMail { get; set; }
        public bool IsDelete { get; set; }
        public string DeleteReson { get; set; }
    }
}
