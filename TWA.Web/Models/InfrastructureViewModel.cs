using System;
using System.Collections.Generic;

namespace TWA.Web.Models
{
    public class InfrastructureViewModel
    {
        public List<ConstructionTask> ActiveBuilds { get; set; } = new List<ConstructionTask>();
        public List<ConstructionTask> BuildQueue { get; set; } = new List<ConstructionTask>();
    }

    public class ConstructionTask
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string VillageName { get; set; } = string.Empty;
        public string BuildingName { get; set; } = string.Empty; // "Iron Mine", "Headquarters"
        public string BuildingIcon { get; set; } = string.Empty; // "fas fa-hammer"
        public int CurrentLevel { get; set; }
        public int TargetLevel { get; set; }
        
        // Time & Progress
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Duration => EndTime - StartTime;
        public TimeSpan Remaining => EndTime - DateTime.Now;
        
        // Progress Percentage (0-100)
        public int Progress 
        {
            get 
            {
                var total = (EndTime - StartTime).TotalSeconds;
                var elapsed = (DateTime.Now - StartTime).TotalSeconds;
                if (total <= 0) return 100;
                var p = (int)((elapsed / total) * 100);
                return Math.Clamp(p, 0, 100);
            }
        }

        public bool IsActive { get; set; }
    }
}
