using TWA.Core.Entities;

namespace TWA.Web.Models
{
    public class WarfareViewModel
    {
        public List<AttackTask> ActiveAttacks { get; set; } = new List<AttackTask>();
        public int TodayAttackCount { get; set; }
        public double SuccessRate { get; set; }
        public long TotalLoot { get; set; }
    }
}
