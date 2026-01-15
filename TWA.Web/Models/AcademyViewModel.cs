using TWA.Core.Entities;

namespace TWA.Web.Models
{
    public class AcademyViewModel
    {
        public List<Village> Villages { get; set; } = new List<Village>();
        public int SelectedVillageId { get; set; }
        public Village? SelectedVillage { get; set; }
        public int AcademyLevel { get; set; }
        public int AvailableCoins { get; set; }
        public int CoinsInProduction { get; set; }
        public int MaxCoins => 3;
    }
}
