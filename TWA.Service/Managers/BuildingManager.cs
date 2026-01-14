using System;
using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Managers
{
    public class BuildingManager
    {
        private readonly IGameBrowserService _browser;
        private readonly IRepository<Village> _villageRepo;

        public BuildingManager(IGameBrowserService browser, IRepository<Village> villageRepo)
        {
            _browser = browser;
            _villageRepo = villageRepo;
        }

        public async Task CheckAndBuildAsync(int villageId)
        {
            var village = await _villageRepo.GetByIdAsync(villageId);
            if (village == null) 
            {
                Console.WriteLine($"⚠️ Köy bulunamadı: {villageId}");
                return;
            }

            // 1. AI STRATEJİ KONTROLÜ (Precognition)
            // Eğer AI "SAVE" (Biriktir) dediyse ve depo taşmıyorsa inşaat yapma.
            if (village.AiAction == "SAVE" && !village.IsStorageNearFull())
            {
                Console.WriteLine($"⏳ İNŞAAT BEKLETİLİYOR: {village.Name} - Hedef: {village.AiTarget}");
                return;
            }

            // 2. ANA BİNAYA GİT
            await _browser.NavigateToBuilding("main");

            // 3. İNŞAAT KUYRUĞU DOLU MU?
            // Oyun genelde max 2 inşaata izin verir (Premiumsuz).
            int activeBuilds = await _browser.GetActiveBuildCountAsync();
            if (activeBuilds >= 2) return;

            // 4. KÖY MODUNA GÖRE ÖNCELİK BELİRLE
            string nextBuilding = DetermineNextBuilding(village);

            // 5. KAYNAK KONTROLÜ VE İNŞA
            if (await _browser.CanAffordBuilding(nextBuilding))
            {
                // Try specific selector first, then fallback to data-building
                try 
                {
                   await _browser.ClickButtonAsync($".btn-build[data-building='{nextBuilding}']");
                }
                catch
                {
                   await _browser.ClickButtonAsync($"#main_buildrow_{nextBuilding} .btn-build");
                }
                
                Console.WriteLine($"🔨 İNŞAAT BAŞLADI: {nextBuilding} - Mod: {village.Mode}");
            }
        }

        private string DetermineNextBuilding(Village v)
        {
            // Basit Karar Ağacı (İleride DB'den okunabilir)
            if (v.Mode == VillageMode.Defensive)
            {
                if (v.WallLevel < 20) return "wall"; // Önce Sur!
                if (v.BarracksLevel < 25) return "barracks";
            }
            else if (v.Mode == VillageMode.Offensive)
            {
                if (v.SmithyLevel < 20) return "smithy"; // Akademi için Demirci şart
                if (v.StableLevel < 20) return "stable";
            }
            
            // Varsayılan: Kaynakları geliştir (Eğer max değilse)
            // Daha akıllı bir mantık eklenebilir, şimdilik "wood" dönüyor snippet'teki gibi
            return "wood"; 
        }
    }
}
