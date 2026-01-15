using System;
using TWA.Core.Common;

namespace TWA.Core.Entities
{
    public class InventoryItem : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Identifier { get; set; } // e.g. item_id
        public int Count { get; set; }
        public string Description { get; set; }
    }
}
