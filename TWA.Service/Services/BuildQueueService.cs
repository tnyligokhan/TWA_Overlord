using System.Text.Json;
using TWA.Core.DTOs;
using TWA.Core.Entities;
using TWA.Core.Interfaces;

namespace TWA.Service.Services
{
    public interface IBuildQueueService
    {
        Task ProcessQueuesAsync();
    }

    public class BuildQueueService : IBuildQueueService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuildQueueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessQueuesAsync()
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            var now = DateTime.Now;

            foreach (var village in villages)
            {
                await ProcessVillageBuildQueue(village, now);
            }

            await _unitOfWork.CommitAsync();
        }

        private async Task ProcessVillageBuildQueue(Village village, DateTime now)
        {
            var queue = ParseQueue(village.BuildQueueJson);
            if (queue.Count == 0) return;

            // Tamamlananları bul ve sil
            var completed = queue.Where(q => q.EndTime <= now).ToList();
            
            foreach (var item in completed)
            {
                // Bina seviyesini yükselt
                UpgradeBuildingLevel(village, item);
                
                // Kuyruktan çıkar
                queue.Remove(item);
            }

            // Kalan kuyrukta ilk item'ı aktif yap
            if (queue.Any())
            {
                queue[0].IsActive = true;
            }

            // Güncellenmiş kuyruğu kaydet
            village.BuildQueueJson = JsonSerializer.Serialize(queue);
            _unitOfWork.Repository<Village>().Update(village);
        }

        private void UpgradeBuildingLevel(Village village, BuildQueueItem item)
        {
            // Bina seviyesini yükselt
            switch (item.BuildingType.ToLower())
            {
                case "main": village.BuildingMain = item.TargetLevel; break;
                case "barracks": village.BuildingBarracks = item.TargetLevel; break;
                case "stable": village.BuildingStable = item.TargetLevel; break;
                case "garage": village.BuildingGarage = item.TargetLevel; break;
                case "snob": village.BuildingSnob = item.TargetLevel; break;
                case "smith": village.BuildingSmithy = item.TargetLevel; break;
                case "wood": village.BuildingWood = item.TargetLevel; break;
                case "stone": village.BuildingStone = item.TargetLevel; break;
                case "iron": village.BuildingIron = item.TargetLevel; break;
                case "farm": village.BuildingFarm = item.TargetLevel; break;
                case "storage": village.BuildingStorage = item.TargetLevel; break;
                case "wall": village.BuildingWall = item.TargetLevel; break;
            }
        }

        private List<BuildQueueItem> ParseQueue(string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json) || json == "[]")
                    return new List<BuildQueueItem>();

                return JsonSerializer.Deserialize<List<BuildQueueItem>>(json) ?? new List<BuildQueueItem>();
            }
            catch
            {
                return new List<BuildQueueItem>();
            }
        }
    }
}
