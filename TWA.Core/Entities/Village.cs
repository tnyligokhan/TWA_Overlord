using TWA.Core.Common;

namespace TWA.Core.Entities
{
    public enum VillageType
    {
        Own = 1,        // Bizim Köyümüz
        Barbarian = 2,  // Barbar (Yağma Hedefi)
        Enemy = 3,      // Düşman
        Ally = 4        // Müttefik
    }

    public enum VillageMode { Balanced, Offensive, Defensive, Farm, Spy }

    public class Village : BaseEntity
    {
        // YENİ ÖZELLİKLER
        public VillageMode Mode { get; set; } = VillageMode.Balanced;
        
        // Askeri Şablon Durumu (Hedeflenen sayılar)
        public int TargetSpear { get; set; }
        public int TargetSword { get; set; }
        public int TargetAxe { get; set; }
        public int TargetArcher { get; set; }
        public int TargetSpy { get; set; }
        public int TargetLight { get; set; }
        public int TargetMarcher { get; set; }
        public int TargetHeavy { get; set; }
        public int TargetRam { get; set; }
        public int TargetCatapult { get; set; }
        public int TargetKnight { get; set; }
        public int TargetSnob { get; set; }

        public virtual ICollection<DailyTask> DailyTasks { get; set; } = new List<DailyTask>();
        public int GameId { get; set; } // Oyunun verdiği ID (game.php?village=XXXX)
        public string Name { get; set; } = string.Empty;
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int Points { get; set; }
        public int Loyalty { get; set; } = 100;
        
        // Üretim Oranları (Saatlik)
        public int WoodHourly { get; set; }
        public int StoneHourly { get; set; }
        public int IronHourly { get; set; }

        // Bina Seviyeleri (JSON olarak tutulabilir veya ayrı alanlar)
        // Basitlik için en kritikleri ekliyorum:
        public int BuildingMain { get; set; }
        public int BuildingWood { get; set; }
        public int BuildingStone { get; set; }
        public int BuildingIron { get; set; }
        public int BuildingStorage { get; set; }
        public int BuildingFarm { get; set; }
        public int BuildingWall { get; set; }

        public VillageType Type { get; set; } = VillageType.Own;

        // Ekonomi
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Iron { get; set; }
        public int StorageCapacity { get; set; }
        public int PopulationCurrent { get; set; }
        public int PopulationMax { get; set; }

        // Lojistik & Asker (Owned Type)
        public TroopSet OwnedTroops { get; set; } = new TroopSet(); // Köyün içindeki (Sabit)
        public TroopSet TotalTroops { get; set; } = new TroopSet(); // Dışarıdakiler dahil (Genel Güç)

        // İlişkiler
        public List<BuildingPlan> BuildQueue { get; set; } = new List<BuildingPlan>();
        public List<AttackTask> Attacks { get; set; } = new List<AttackTask>();
        
        // Helper: Koordinat String (555|444)
        public string Coordinates => $"{CoordinateX}|{CoordinateY}";

        public string AvailableTroopsSummary()
        {
            if (OwnedTroops == null) return "0 Asker";
            var parts = new List<string>();
            if (OwnedTroops.Spear > 0) parts.Add($"{OwnedTroops.Spear} Miz");
            if (OwnedTroops.Sword > 0) parts.Add($"{OwnedTroops.Sword} Kil");
            if (OwnedTroops.Axe > 0) parts.Add($"{OwnedTroops.Axe} Bal");
            if (OwnedTroops.Light > 0) parts.Add($"{OwnedTroops.Light} Haf");
            if (OwnedTroops.Heavy > 0) parts.Add($"{OwnedTroops.Heavy} Agir");
            if (OwnedTroops.Ram > 0) parts.Add($"{OwnedTroops.Ram} Sah");
            if (OwnedTroops.Catapult > 0) parts.Add($"{OwnedTroops.Catapult} Man");
            if (OwnedTroops.Snob > 0) parts.Add($"{OwnedTroops.Snob} Mis");
            
            return parts.Count > 0 ? string.Join(", ", parts) : "Asker Yok";
        }

        public double DistanceTo(int targetX, int targetY)
        {
            return Math.Sqrt(Math.Pow(CoordinateX - targetX, 2) + Math.Pow(CoordinateY - targetY, 2));
        }
    }
}
