using Microsoft.EntityFrameworkCore; // ValueObject için [Owned] gerekebilir veya context'te ayarlanır.

namespace TWA.Core.Entities
{
    [Owned] // EF Core bu sınıfı ayrı tablo yapmaz, eklendiği tablonun kolonu yapar.
    public class TroopSet
    {
        public int Spear { get; set; }
        public int Sword { get; set; }
        public int Axe { get; set; }
        public int Spy { get; set; }
        public int Light { get; set; } // Hafif Atlı
        public int Heavy { get; set; } // Ağır Atlı
        public int Ram { get; set; }   // Şahmerdan
        public int Catapult { get; set; }
        public int Knight { get; set; }
        public int Snob { get; set; }  // Misyoner
        public int Militia { get; set; }

        // Toplam Asker Sayısı (Popülasyon hesabı için)
        public int TotalPopulation() 
        {
            return Spear + Sword + Axe + (Spy * 2) + (Light * 4) + (Heavy * 6) + (Ram * 5) + (Catapult * 8) + (Snob * 100); 
        }
    }
}
