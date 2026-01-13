using TWA.Core.Entities;
using TWA.Core.Helpers;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class EconomyService : IEconomyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EconomyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public double CalculateROI(Village village, string resourceType, int nextLevel)
        {
            if (nextLevel > 30) return 99999; // Max seviye

            // 1. Maliyeti Bul
            var cost = GameBuildingData.GetCost(resourceType, nextLevel);
            int totalCost = cost.Total;

            // 2. Üretim Artışını Bul (Delta)
            int currentProd = GameBuildingData.ProductionRates[nextLevel - 1];
            int nextProd = GameBuildingData.ProductionRates[nextLevel];
            int productionGain = nextProd - currentProd;

            // 3. ROI Hesabı (Maliyet / Kazanç) = Kaç saatte parasını çıkarır?
            // Hız 1 olduğu için direkt bölüyoruz.
            if (productionGain <= 0) return 99999;

            return (double)totalCost / productionGain;
        }

        public async Task AnalyzeAndPlanBuildsAsync(int villageId)
        {
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(villageId);
            if (village == null) return;

            var planRepo = _unitOfWork.Repository<BuildingPlan>();
            
            // Zaten kuyrukta iş var mı? Varsa dur.
            // (Gerçek hayatta 2-3 bina sıraya atılabilir, şimdilik 1 yapalım)
            var activePlans = await planRepo.FindAsync(p => p.VillageId == villageId && p.IsActive);
            if (activePlans.Any()) return;

            // --- STRATEJİ 1: ACİL DEPO YÖNETİMİ ---
            // Depo %90 doluysa ve Depo Seviyesi < 30 ise -> Depo Bas
            if (village.Wood > village.StorageCapacity * 0.9 || 
                village.Stone > village.StorageCapacity * 0.9 ||
                village.Iron > village.StorageCapacity * 0.9)
            {
                if (village.BuildingStorage < 30)
                {
                    await AddBuildPlan(village, "storage", village.BuildingStorage + 1, 1); // Öncelik 1 (En Yüksek)
                    return;
                }
            }

            // --- STRATEJİ 2: ACİL ÇİFTLİK YÖNETİMİ ---
            // Nüfus dolduysa -> Çiftlik Bas
            if (village.PopulationCurrent >= village.PopulationMax)
            {
                if (village.BuildingFarm < 30)
                {
                    await AddBuildPlan(village, "farm", village.BuildingFarm + 1, 1);
                    return;
                }
            }

            // --- STRATEJİ 3: ROI (YATIRIM) ANALİZİ ---
            // Madenlerin ROI sürelerini hesapla
            double roiWood = CalculateROI(village, "wood", village.BuildingWood + 1);
            double roiStone = CalculateROI(village, "stone", village.BuildingStone + 1);
            double roiIron = CalculateROI(village, "iron", village.BuildingIron + 1);

            // En kârlı olanı bul (En düşük ROI en iyisidir)
            // Eğer ROI < 24 saat ise (1 günde amorti ediyorsa) kesin bas.
            // Dünya 99 yavaş olduğu için bunu < 48 saat yapabiliriz.
            
            string bestRes = "wood";
            double bestRoi = roiWood;
            int targetLevel = village.BuildingWood + 1;

            if (roiStone < bestRoi) { bestRes = "stone"; bestRoi = roiStone; targetLevel = village.BuildingStone + 1; }
            if (roiIron < bestRoi) { bestRes = "iron"; bestRoi = roiIron; targetLevel = village.BuildingIron + 1; }

            if (bestRoi < 48) // 48 saat kuralı
            {
                await AddBuildPlan(village, bestRes, targetLevel, 2); // Öncelik 2 (Orta)
            }
            else
            {
                // ROI çok yüksekse, artık askeri binalara veya karargaha yönel
                // Şimdilik boş bırakıyoruz, Groq AI burada devreye girip "Savaş Modu" diyebilir.
            }
        }

        private async Task AddBuildPlan(Village village, string building, int level, int priority)
        {
            var plan = new BuildingPlan
            {
                VillageId = village.Id,
                BuildingName = building,
                TargetLevel = level,
                Priority = priority,
                IsActive = true, // Hemen kuyruğa al
                CreatedDate = DateTime.UtcNow
            };
            
            await _unitOfWork.Repository<BuildingPlan>().AddAsync(plan);
            await _unitOfWork.CommitAsync();
        }
    }
}
