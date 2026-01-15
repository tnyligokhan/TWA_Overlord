namespace TWA.Core.DTOs
{
    public class GrokStrategyResponse
    {
        public string Strategy { get; set; } = string.Empty; // DEFENSIVE_BUILDUP, OFFENSIVE_PREP, ECONOMIC_FOCUS, BALANCED
        public string Reason { get; set; } = string.Empty;
        public List<GrokTask> Tasks { get; set; } = new List<GrokTask>();
    }

    public class GrokTask
    {
        public string Type { get; set; } = string.Empty; // Recruit, Build, Attack, Transport
        public string Target { get; set; } = string.Empty; // spear, wall, barracks, etc.
        public int Amount { get; set; }
        public int Priority { get; set; } // 1-5
        public string Reason { get; set; } = string.Empty;
        public DateTime? ScheduledTime { get; set; } // İnsan taklidi için rastgele zaman
    }
}
