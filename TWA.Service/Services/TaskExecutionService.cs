using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;
using TWA.Service.Managers;

namespace TWA.Service.Services
{
    public class TaskExecutionService : ITaskExecutionService
    {
        private readonly Managers.TroopManager _troopManager;
        private readonly Managers.BuildingManager _buildingManager;
        private readonly IRepository<Village> _villageRepo;

        public TaskExecutionService(Managers.TroopManager troopManager, Managers.BuildingManager buildingManager, IRepository<Village> villageRepo)
        {
            _troopManager = troopManager;
            _buildingManager = buildingManager;
            _villageRepo = villageRepo;
        }

        public async Task ExecuteOperationAsync(ScheduledOperation op)
        {
            var village = await _villageRepo.GetByIdAsync(op.VillageId);

            if (village == null) return;

            if (op.Type == OpType.DailyTask)
            {
                // Payload içindeki JSON'u çöz
                try {
                    var task = System.Text.Json.JsonSerializer.Deserialize<DailyTask>(op.Payload);
                    
                    if (task == null) return;

                    if (task.Type == TaskType.Recruitment)
                    {
                        // Asker Yönetimini Çağır
                        await _troopManager.RecruitByTemplateAsync(village);
                    }
                    else if (task.Type == TaskType.Building)
                    {
                        // Bina Yönetimini Çağır
                        await _buildingManager.CheckAndBuildAsync(village.Id);
                    }
                } catch {
                     // JSON parse hatası veya task yapısı bozuk
                }
            }
            else if (op.Type == OpType.PeriodicCheck)
            {
                // Sadece gezinti yap, raporları topla, saldırı var mı bak
                // (CheckIncomingAttacks zaten GhostEngine içinde çağrılıyor)
                // İleride buraya rapor toplama servisi eklenebilir.
            }
        }
    }
}
