namespace TWA.Core.DTOs
{
    public class GrokResourceAdvice
    {
        public string StorageRisk { get; set; } = "LOW"; // LOW, MEDIUM, HIGH
        public double HoursUntilFull { get; set; }
        public string Action { get; set; } = "SAVE"; // SAVE, SPEND, FILLER, PANIC_RECRUIT
        public string Reason { get; set; } = string.Empty;
        public List<string> Recommendations { get; set; } = new List<string>();
    }
}
