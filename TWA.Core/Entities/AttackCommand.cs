using System;
using TWA.Core.Entities;

namespace TWA.Core.Entities
{
    // public enum AttackType { Normal, Fake, Snipe, Support } -> Moved to AttackTask.cs or common

    public class AttackCommand
    {
        public int SourceVillageId { get; set; }
        public int TargetX { get; set; }
        public int TargetY { get; set; }
        public AttackType Type { get; set; }
        public TroopSet Troops { get; set; } = new TroopSet();
        public DateTime? LaunchTime { get; set; } // Snipe için kritik
    }
}
