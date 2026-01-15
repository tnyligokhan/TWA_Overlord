namespace TWA.Core.DTOs
{
    public class RecruitmentQueueItem
    {
        public string BuildingType { get; set; } = string.Empty; // "barracks", "stable", "garage", "snob"
        public string UnitType { get; set; } = string.Empty; // "spear", "sword", "axe", etc.
        public int Amount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; } // İlk sıradaki aktif mi?
    }
}
