using TWA.Core.Entities;

namespace TWA.Web.Models
{
    public class EconomyViewModel
    {
        // Global Özet
        public long TotalWood { get; set; }
        public long TotalClay { get; set; } // Renamed from Stone
        public long TotalIron { get; set; }
        public int TotalGoldCoins { get; set; } // Added for Mining Rig
        public int TotalProductionPerHour { get; set; } // Ortalama üretim
        public int TotalMerchantsAvailable { get; set; }

        // Köy Detayları
        public List<VillageEconomyState> VillageResources { get; set; } = new List<VillageEconomyState>(); // Renamed from VillageStates
    }

    public class VillageEconomyDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Coordinates { get; set; } = string.Empty;
        public int Wood { get; set; }
        public int Clay { get; set; } // Renamed from Stone
        public int Iron { get; set; }
        public int Storage { get; set; }
        public int StorageCapacity { get; set; }
        public int Population { get; set; }
        public int PopulationMax { get; set; }
        
        // Hesaplanan Veriler
        public string BestRoiBuilding { get; set; } = string.Empty; // En mantıklı inşaat
        public int PredictedResourceOverflowInHours { get; set; } // Depo kaç saate dolar?
    }

    public class VillageEconomyState
    {
        public int VillageId { get; set; }
        public string VillageName { get; set; } = string.Empty; // Renamed from Name to match View usage which was valid in previous? Wait, view used VillageName
        public string Coordinates { get; set; } = string.Empty;
        
        // Kaynaklar
        public int Wood { get; set; }
        public int Clay { get; set; } // Renamed from Stone
        public int Iron { get; set; }
        public int StorageCapacity { get; set; }
        
        // Durumlar
        public bool IsStorageFull => (Wood > StorageCapacity * 0.9 || Clay > StorageCapacity * 0.9 || Iron > StorageCapacity * 0.9);
        public string BestRoiBuilding { get; set; } = string.Empty; // Örn: "Oduncu (14h)"
        public int ActiveMerchants { get; set; }
        public int TotalMerchants { get; set; }
    }
}
