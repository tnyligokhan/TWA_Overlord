namespace TWA.Core.DTOs
{
    public class GrokReportAnalysis
    {
        public string Winner { get; set; } = string.Empty; // "Attacker", "Defender"
        public string ReportType { get; set; } = string.Empty; // "Attack", "Support", "Scout"
        public Dictionary<string, int> OurLosses { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> EnemyLosses { get; set; } = new Dictionary<string, int>();
        public WallDamage? WallDamage { get; set; }
        public LootInfo? Loot { get; set; }
        public string Recommendation { get; set; } = string.Empty; // "RAID_AGAIN", "AVOID", "INCREASE_RAMS"
        public string ForumMessage { get; set; } = string.Empty; // BBCode formatında klan mesajı
    }

    public class WallDamage
    {
        public int LevelBefore { get; set; }
        public int LevelAfter { get; set; }
        public bool Destroyed { get; set; }
    }

    public class LootInfo
    {
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Iron { get; set; }
        public int Total { get; set; }
    }
}
