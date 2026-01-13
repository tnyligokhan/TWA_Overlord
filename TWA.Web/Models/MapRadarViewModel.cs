using TWA.Core.Entities;

namespace TWA.Web.Models
{
    public class MapRadarViewModel
    {
        // Filtreler
        public int CenterX { get; set; } = 500; // Varsayılan: Harita ortası
        public int CenterY { get; set; } = 500;
        public int Radius { get; set; } = 15; // 15x15 Karelik alan
        public int MinPoints { get; set; } = 0;
        public int MaxPoints { get; set; } = 3000; // Barbar limiti

        // Sonuçlar
        public IEnumerable<Village> Targets { get; set; } = new List<Village>();
        
        // Özet
        public int BarbarianCount => Targets.Count(t => t.Type == VillageType.Barbarian);
        public int PlayerCount => Targets.Count(t => t.Type == VillageType.Enemy || t.Type == VillageType.Ally);
    }
}
