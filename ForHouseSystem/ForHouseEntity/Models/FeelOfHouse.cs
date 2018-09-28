using System;
using System.Collections.Generic;

namespace ForHouseEntity.Models
{
    public partial class FeelOfHouse
    {
        public int HouseId { get; set; }
        public int UserId { get; set; }
        public int FeelType { get; set; }
        public bool? IsCancel { get; set; }
    }
}
