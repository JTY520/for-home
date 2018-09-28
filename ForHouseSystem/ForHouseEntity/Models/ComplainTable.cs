using System;
using System.Collections.Generic;

namespace ForHouseEntity.Models
{
    public partial class ComplainTable
    {
        public int UserId { get; set; }
        public int HouseId { get; set; }
        public bool IsPass { get; set; }
        public string ComplainReason { get; set; }
        public bool? IsDelete { get; set; }
    }
}
