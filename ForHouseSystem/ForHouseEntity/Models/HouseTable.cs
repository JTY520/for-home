using System;
using System.Collections.Generic;

namespace ForHouseEntity.Models
{
    public partial class HouseTable
    {
        public int HouseId { get; set; }
        public int MasterId { get; set; }
        public string Title { get; set; }
        public int HouseType { get; set; }
        public string HouseSummary { get; set; }
        public string HousePlace { get; set; }
        public string HouseBargainContent { get; set; }
        public decimal HouseMoney { get; set; }
        public int NumberOfLike { get; set; }
        public int? NumberOfDiss { get; set; }
        public bool IsDone { get; set; }
        public bool IsPublic { get; set; }
        public DateTime PublicTime { get; set; }
        public bool IsDelete { get; set; }
        public string DeleteReason { get; set; }
        public string Characteristic { get; set; }
        public string Images { get; set; }
    }
}
