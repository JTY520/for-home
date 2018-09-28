using System;
using System.Collections.Generic;

namespace ForHouseEntity.Models
{
    public partial class CharacteristicTable
    {
        public int CharacteristicId { get; set; }
        public string CharacteristicName { get; set; }
        public bool? IsDelete { get; set; }
    }
}
