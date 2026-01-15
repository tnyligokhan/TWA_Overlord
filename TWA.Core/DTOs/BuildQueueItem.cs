namespace TWA.Core.DTOs
{
    public class BuildQueueItem
    {
        public string BuildingType { get; set; } = string.Empty; // "main", "barracks", etc.
        public int CurrentLevel { get; set; }
        public int TargetLevel { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; } // İlk sıradaki aktif mi?
    }
}
