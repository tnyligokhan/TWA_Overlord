using System;
using TWA.Core.Common;

namespace TWA.Core.Entities
{
    public enum CommandType
    {
        Attack,
        Support,
        Return,
        Relocation,
        Other
    }

    public class Command : BaseEntity
    {
        public string GameId { get; set; } // External game ID for the command
        public string CommandText { get; set; } // Text description found in the row
        public CommandType Type { get; set; }
        public string IconName { get; set; } // e.g. attack_small, proper, etc.

        public int OriginVillageId { get; set; }
        public string OriginVillageName { get; set; }
        public int OriginX { get; set; }
        public int OriginY { get; set; }

        public int TargetVillageId { get; set; }
        public string TargetVillageName { get; set; }
        public int TargetX { get; set; }
        public int TargetY { get; set; }

        public DateTime ArrivalTime { get; set; }
        public TimeSpan TimeRemaining { get; set; }

        public bool IsIncoming { get; set; } // True if incoming, False if outgoing
    }
}
