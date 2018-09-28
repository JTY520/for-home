using System;
using System.Collections.Generic;

namespace ForHouseEntity.Models
{
    public partial class OrderTable
    {
        public int HouseId { get; set; }
        public int UserId { get; set; }
        public int MasterId { get; set; }
        public int OrderType { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderPlace { get; set; }
        public DateTime OrderCreateTime { get; set; }
        public bool IsAccepted { get; set; }
        public string ContactWay { get; set; }
    }
}
