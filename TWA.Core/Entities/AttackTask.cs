using System;
using TWA.Core.Common;

namespace TWA.Core.Entities
{
    public enum AttackType
    {
        Fake = 0,
        Farm = 1,       // Yağma (C)
        Real_Nuke = 2,  // Full Kami
        Real_Noble = 3, // Misyoner
        Snipe = 4,      // Savunma araya girme
        Support = 5     // Destek
    }

    public enum AttackStatus
    {
        Pending = 0,    // Beklemede
        Scheduled = 1,  // Zamanlandı (Background Service devrede)
        Sent = 2,       // Gönderildi
        Cancelled = 3,  // İptal
        Failed = 4      // Hata (Asker yetmedi vs.)
    }

    public class AttackTask : BaseEntity
    {
        public int SourceVillageId { get; set; }
        public Village? SourceVillage { get; set; }

        public int TargetX { get; set; }
        public int TargetY { get; set; }
        public string TargetPlayerName { get; set; } = string.Empty; // İstatistik için

        // Zamanlama (En Kritik Kısım)
        public DateTime LaunchTime { get; set; } // Çıkış Zamanı
        public DateTime ArrivalTime { get; set; } // Varış Zamanı (Snipe için hedef)

        // Gönderilecek Asker
        public TroopSet Troops { get; set; } = new TroopSet();

        public AttackType Type { get; set; }
        public AttackStatus Status { get; set; }
        
        public string GroqNotes { get; set; } = string.Empty; // AI'ın bu saldırıyı neden açtığına dair notu

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        public string TargetCoordinates
        {
            get => $"{TargetX}|{TargetY}";
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Contains('|'))
                {
                    var parts = value.Split('|');
                    if (parts.Length == 2 && int.TryParse(parts[0], out int x) && int.TryParse(parts[1], out int y))
                    {
                        TargetX = x;
                        TargetY = y;
                    }
                }
            }
        }
    }
}
