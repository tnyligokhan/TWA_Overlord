using TWA.Core.Entities;
using TWA.Core.DTOs;

namespace TWA.Web.Models
{
    public class RecruitmentViewModel
    {
        public List<Village> Villages { get; set; } = new List<Village>();
        public int SelectedVillageId { get; set; }
        public Village? SelectedVillage { get; set; }
        public string BuildingType { get; set; } = string.Empty; // barracks, stable, garage, snob
        public int BuildingLevel { get; set; }
        public List<string> AvailableUnits { get; set; } = new List<string>();
        public List<RecruitmentQueueItem> Queue { get; set; } = new List<RecruitmentQueueItem>();
        
        // Form Data
        public string UnitType { get; set; } = string.Empty;
        public int UnitCount { get; set; }
    }

    public class MassRecruitmentViewModel
    {
        public List<Village> Villages { get; set; } = new List<Village>();
        public List<int> SelectedVillageIds { get; set; } = new List<int>();
        public string UnitType { get; set; } = string.Empty;
        public int UnitCountPerVillage { get; set; }
        public bool UseMaxCapacity { get; set; }
    }

    public class UnitInfo
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Iron { get; set; }
        public int Population { get; set; }
        public int BuildTime { get; set; } // seconds
        public int CurrentCount { get; set; }
        public int InQueue { get; set; }
        public int MaxBuildable { get; set; }
    }
}
