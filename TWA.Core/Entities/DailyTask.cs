using System;
using TWA.Core.Common;

namespace TWA.Core.Entities
{
    public enum TaskType { Recruitment, Building, Attack, Other }

    public class DailyTask : BaseEntity
    {
        public int VillageId { get; set; }
        public TaskType Type { get; set; }
        public string ActionTarget { get; set; } = string.Empty; // Bina ID veya asker türü
        public string TaskName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime ScheduledTime { get; set; }
        
        // Navigation Property
        // public virtual Village Village { get; set; }
    }
}
