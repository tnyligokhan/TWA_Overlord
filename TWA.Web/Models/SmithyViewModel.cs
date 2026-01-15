using TWA.Core.Entities;

namespace TWA.Web.Models
{
    public class SmithyViewModel
    {
        public List<Village> Villages { get; set; } = new List<Village>();
        public int SelectedVillageId { get; set; }
        public Village? SelectedVillage { get; set; }
    }

    public class ResearchInfo
    {
        public string UnitType { get; set; } = string.Empty;
        public string UnitName { get; set; } = string.Empty;
        public int CurrentLevel { get; set; }
        public int MaxLevel { get; set; } = 3;
        public int WoodCost { get; set; }
        public int StoneCost { get; set; }
        public int IronCost { get; set; }
        public int RequiredSmithyLevel { get; set; }
        public int RequiredBarracksLevel { get; set; }
        public int RequiredStableLevel { get; set; }
        public int RequiredGarageLevel { get; set; }
        public string BuildingRequirement { get; set; } = string.Empty;
    }
}
