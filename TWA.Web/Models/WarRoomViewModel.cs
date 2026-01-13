using TWA.Core.Entities;

namespace TWA.Web.Models
{
    public class WarRoomViewModel
    {
        public IEnumerable<Village> MyVillages { get; set; } = new List<Village>();
        
        // List of Active Attacks (Renamed from ActiveOperations to match View)
        public IEnumerable<AttackTask> Attacks { get; set; } = new List<AttackTask>();
        
        // Form Binding Property
        public AttackTask NewTask { get; set; } = new AttackTask();
        
        public int CurrentVillageId { get; set; }
    }
}
