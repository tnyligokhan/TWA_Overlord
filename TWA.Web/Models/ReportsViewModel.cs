namespace TWA.Web.Models
{
    public class ReportsViewModel
    {
        public string SelectedCategory { get; set; } = "all";
        public List<ReportItem> Reports { get; set; } = new List<ReportItem>();
        public int TotalCount { get; set; }
        public int UnreadCount { get; set; }
    }

    public class ReportItem
    {
        public int Id { get; set; }
        public string Category { get; set; } = string.Empty; // attack, defense, support, trade, other
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public DateTime ReceivedAt { get; set; }
        public bool IsRead { get; set; }
        public string Icon { get; set; } = string.Empty;
        public string ColorClass { get; set; } = string.Empty;
    }
}
