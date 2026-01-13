using System;
using TWA.Core.Common;

namespace TWA.Core.Entities
{
    public enum OpType { DailyTask, PeriodicCheck, DodgeAttack, SnipeAttack }

    public class ScheduledOperation : BaseEntity
    {
        public int VillageId { get; set; }
        public OpType Type { get; set; }
        public DateTime ScheduledTime { get; set; } // Ne zaman çalışacak?
        public bool IsEmergency { get; set; } = false;
        public string Payload { get; set; } // JSON veri (Asker sayısı vb.)
        public bool IsCompleted { get; set; } = false;
        public string ExecutionLog { get; set; } = string.Empty; // Sonuç
    }
}
