namespace TWA.Core.DTOs
{
    public class GrokDiplomaticMessage
    {
        public string MessageType { get; set; } = string.Empty; // "FORUM_POST", "TELEGRAM", "HELP_REQUEST"
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Format { get; set; } = "BBCODE"; // BBCODE, MARKDOWN, PLAIN
        public int Urgency { get; set; } // 1-5
    }
}
