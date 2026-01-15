namespace TWA.Web.Models
{
    public class StatisticsViewModel
    {
        public int TotalVillages { get; set; }
        public int TotalPopulation { get; set; }
        public int TotalTroops { get; set; }
        public int TotalResources { get; set; }
        public List<VillageStatItem> VillageStats { get; set; } = new List<VillageStatItem>();
    }

    public class VillageStatItem
    {
        public int VillageId { get; set; }
        public string VillageName { get; set; } = string.Empty;
        public string Coordinates { get; set; } = string.Empty;
        public int Points { get; set; }
        public int Population { get; set; }
        public int TotalTroops { get; set; }
    }
}
