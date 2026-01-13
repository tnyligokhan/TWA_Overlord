using TWA.Core.Common;

namespace TWA.Core.Entities
{
    public class WorldConfig : BaseEntity
    {
        public int WorldId { get; set; } // Örn: 99
        public double GameSpeed { get; set; } // 1.0
        public double UnitSpeed { get; set; } // 1.0
        
        // Savaş Kuralları
        public bool ArchersActive { get; set; } // false (W99)
        public bool PaladinActive { get; set; } // true
        public int FakeLimitPercent { get; set; } // 1
        public bool MillisecondsActive { get; set; } // true
        public int LagRandomizationMs { get; set; } // 25 (W99: +/- 25ms)

        // Gece Bonusu
        public bool NightBonusActive { get; set; }
        public TimeSpan NightStart { get; set; } // 23:00
        public TimeSpan NightEnd { get; set; }   // 07:00
    }
}
