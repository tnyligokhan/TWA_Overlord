namespace TWA.Core.DTOs
{
    public class GrokMilitaryAnalysis
    {
        public string Status { get; set; } = "INCOMPLETE"; // READY, INCOMPLETE, CRITICAL
        public List<MissingUnit> MissingUnits { get; set; } = new List<MissingUnit>();
        public string RecruitmentPlan { get; set; } = string.Empty;
        public bool ReadyForOffensive { get; set; }
        public bool ReadyForDefensive { get; set; }
    }

    public class MissingUnit
    {
        public string Unit { get; set; } = string.Empty;
        public int Missing { get; set; }
        public double DaysToComplete { get; set; }
    }
}
