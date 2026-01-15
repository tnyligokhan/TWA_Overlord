using System.Text.Json;
using TWA.Core.DTOs;
using TWA.Core.Entities;
using TWA.Core.Interfaces;

namespace TWA.Service.Services
{
    public interface IRecruitmentQueueService
    {
        Task ProcessQueuesAsync();
        Task<List<RecruitmentQueueItem>> GetQueueForBuilding(Village village, string buildingType);
        Task UpdateQueueForBuilding(Village village, string buildingType, List<RecruitmentQueueItem> queue);
    }

    public class RecruitmentQueueService : IRecruitmentQueueService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecruitmentQueueService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ProcessQueuesAsync()
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            var now = DateTime.Now;

            foreach (var village in villages)
            {
                // Her bina türü için kuyrukları kontrol et
                await ProcessBuildingQueue(village, "barracks", village.BarracksQueueJson, now);
                await ProcessBuildingQueue(village, "stable", village.StableQueueJson, now);
                await ProcessBuildingQueue(village, "garage", village.GarageQueueJson, now);
                await ProcessBuildingQueue(village, "snob", village.SnobQueueJson, now);
            }

            await _unitOfWork.CommitAsync();
        }

        private async Task ProcessBuildingQueue(Village village, string buildingType, string queueJson, DateTime now)
        {
            var queue = ParseQueue(queueJson);
            if (queue.Count == 0) return;

            // Tamamlananları bul ve sil
            var completed = queue.Where(q => q.EndTime <= now).ToList();
            
            foreach (var item in completed)
            {
                // Askeri birimi köye ekle
                AddCompletedTroopsToVillage(village, item);
                
                // Kuyruktan çıkar
                queue.Remove(item);
            }

            // Güncellenmiş kuyruğu kaydet
            await UpdateQueueForBuilding(village, buildingType, queue);
        }

        private void AddCompletedTroopsToVillage(Village village, RecruitmentQueueItem item)
        {
            // Tamamlanan askerleri köye ekle
            switch (item.UnitType.ToLower())
            {
                case "spear": village.OwnedTroops.Spear += item.Amount; break;
                case "sword": village.OwnedTroops.Sword += item.Amount; break;
                case "axe": village.OwnedTroops.Axe += item.Amount; break;
                case "spy": village.OwnedTroops.Spy += item.Amount; break;
                case "light": village.OwnedTroops.Light += item.Amount; break;
                case "heavy": village.OwnedTroops.Heavy += item.Amount; break;
                case "ram": village.OwnedTroops.Ram += item.Amount; break;
                case "catapult": village.OwnedTroops.Catapult += item.Amount; break;
                case "knight": village.OwnedTroops.Knight += item.Amount; break;
                case "snob": village.OwnedTroops.Snob += item.Amount; break;
            }
        }

        public async Task<List<RecruitmentQueueItem>> GetQueueForBuilding(Village village, string buildingType)
        {
            var queueJson = buildingType.ToLower() switch
            {
                "barracks" => village.BarracksQueueJson,
                "stable" => village.StableQueueJson,
                "garage" => village.GarageQueueJson,
                "snob" => village.SnobQueueJson,
                _ => "[]"
            };

            return ParseQueue(queueJson);
        }

        public async Task UpdateQueueForBuilding(Village village, string buildingType, List<RecruitmentQueueItem> queue)
        {
            var json = JsonSerializer.Serialize(queue);

            switch (buildingType.ToLower())
            {
                case "barracks": village.BarracksQueueJson = json; break;
                case "stable": village.StableQueueJson = json; break;
                case "garage": village.GarageQueueJson = json; break;
                case "snob": village.SnobQueueJson = json; break;
            }

            _unitOfWork.Repository<Village>().Update(village);
        }

        private List<RecruitmentQueueItem> ParseQueue(string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json) || json == "[]")
                    return new List<RecruitmentQueueItem>();

                return JsonSerializer.Deserialize<List<RecruitmentQueueItem>>(json) ?? new List<RecruitmentQueueItem>();
            }
            catch
            {
                return new List<RecruitmentQueueItem>();
            }
        }
    }
}
