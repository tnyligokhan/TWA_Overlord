using System;
using TWA.Core.Common;

namespace TWA.Core.Entities
{
    public class Report : BaseEntity
    {
        public string GameId { get; set; }
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        public string StatusIcon { get; set; } // e.g. green.png, red.png
        public bool IsUnread { get; set; }
        
        // Loot info if available in the list (sometimes shown as icon or small text)
        public int Loot { get; set; } 
        public int MaxLoot { get; set; }
        
        public string ReportType { get; set; } // attack, support, trade, etc.
        public string HtmlContent { get; set; } // Full HTML content of the report
    }
}
