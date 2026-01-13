using TWA.Core.Common;

namespace TWA.Core.Entities
{
    public class BuildingPlan : BaseEntity
    {
        public int VillageId { get; set; }
        public Village? Village { get; set; }

        public string BuildingName { get; set; } = string.Empty; // "main", "barracks", "wall"
        public int TargetLevel { get; set; }
        public int Priority { get; set; } // 1: Yüksek, 5: Düşük
        
        public new bool IsActive { get; set; } // Şu an basılıyor mu?
    }
}
