using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;
using TWA.Core.Entities;
using System.Text.RegularExpressions;

namespace TWA.Service.Services
{
    public class VillageDataSyncService
    {
        private readonly IGameBrowserService _browser;
        private readonly IHtmlParsingService _htmlParser;
        private readonly IUnitOfWork _unitOfWork;

        public VillageDataSyncService(
            IGameBrowserService browser,
            IHtmlParsingService htmlParser,
            IUnitOfWork unitOfWork)
        {
            _browser = browser;
            _htmlParser = htmlParser;
            _unitOfWork = unitOfWork;
        }

        public async Task SyncAllVillageDataAsync(int villageId)
        {
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(villageId);
            if (village == null) return;

            // 1. Ana Bina sayfasından bina seviyeleri
            await SyncBuildingLevelsAsync(village);

            // 2. Genel Bakış'tan kaynaklar ve nüfus
            await SyncResourcesAndPopulationAsync(village);

            // 3. Kışla/Ahır/Atölye'den asker sayıları
            await SyncTroopsAsync(village);

            // 4. Demirci'den araştırma seviyelerini çek
            await SyncResearchLevelsAsync(village);

            // 5. Askeri üretim kuyruklarını çek
            await SyncRecruitmentQueuesAsync(village);

            // Kaydet
            _unitOfWork.Repository<Village>().Update(village);
            await _unitOfWork.CommitAsync();
        }

        private async Task SyncBuildingLevelsAsync(Village village)
        {
            var html = await _browser.GetPageContentAsync("main");
            var buildings = _htmlParser.ParseBuildingLevels(html);

            foreach (var building in buildings)
            {
                switch (building.Key)
                {
                    case "main": village.BuildingMain = building.Value; break;
                    case "barracks": village.BuildingBarracks = building.Value; break;
                    case "stable": village.BuildingStable = building.Value; break;
                    case "garage": village.BuildingGarage = building.Value; break;
                    case "snob": village.BuildingSnob = building.Value; break;
                    case "smith": village.BuildingSmithy = building.Value; break;
                    case "statue": village.BuildingStatue = building.Value; break;
                    case "wood": village.BuildingWood = building.Value; break;
                    case "stone": village.BuildingStone = building.Value; break;
                    case "iron": village.BuildingIron = building.Value; break;
                    case "farm": village.BuildingFarm = building.Value; break;
                    case "storage": village.BuildingStorage = building.Value; break;
                    case "wall": village.BuildingWall = building.Value; break;
                }
            }

            // Parse build queue
            var buildQueue = _htmlParser.ParseBuildQueue(html);
            if (buildQueue.Any())
            {
                village.BuildQueueJson = System.Text.Json.JsonSerializer.Serialize(buildQueue);
            }
        }

        private async Task SyncResourcesAndPopulationAsync(Village village)
        {
            // JavaScript'ten game_data objesini oku
            village.Wood = await _browser.GetGameDataIntAsync("game_data.village.wood");
            village.Stone = await _browser.GetGameDataIntAsync("game_data.village.stone");
            village.Iron = await _browser.GetGameDataIntAsync("game_data.village.iron");
            
            village.StorageCapacity = await _browser.GetGameDataIntAsync("game_data.village.storage_max");
            
            village.PopulationCurrent = await _browser.GetGameDataIntAsync("game_data.village.pop");
            village.PopulationMax = await _browser.GetGameDataIntAsync("game_data.village.pop_max");
            
            village.WoodHourly = await _browser.GetGameDataIntAsync("game_data.village.wood_prod");
            village.StoneHourly = await _browser.GetGameDataIntAsync("game_data.village.stone_prod");
            village.IronHourly = await _browser.GetGameDataIntAsync("game_data.village.iron_prod");
            
            village.Points = await _browser.GetGameDataIntAsync("game_data.village.points");
            village.Name = await _browser.GetGameDataStringAsync("game_data.village.name");
            village.CoordinateX = await _browser.GetGameDataIntAsync("game_data.village.x");
            village.CoordinateY = await _browser.GetGameDataIntAsync("game_data.village.y");
        }

        private async Task SyncTroopsAsync(Village village)
        {
            // İçtima Meydanı'ndan asker sayılarını oku
            var html = await _browser.GetPageContentAsync("place");
            
            if (village.OwnedTroops == null)
                village.OwnedTroops = new TroopSet();

            // units_home tablosundan asker sayılarını parse et
            village.OwnedTroops.Spear = ParseTroopCount(html, "spear");
            village.OwnedTroops.Sword = ParseTroopCount(html, "sword");
            village.OwnedTroops.Axe = ParseTroopCount(html, "axe");
            village.OwnedTroops.Spy = ParseTroopCount(html, "spy");
            village.OwnedTroops.Light = ParseTroopCount(html, "light");
            village.OwnedTroops.Heavy = ParseTroopCount(html, "heavy");
            village.OwnedTroops.Ram = ParseTroopCount(html, "ram");
            village.OwnedTroops.Catapult = ParseTroopCount(html, "catapult");
            village.OwnedTroops.Knight = ParseTroopCount(html, "knight");
            village.OwnedTroops.Snob = ParseTroopCount(html, "snob");
        }

        private int ParseTroopCount(string html, string unitType)
        {
            try
            {
                // units_home tablosundan ilgili birimin sayısını bul
                // Örnek: <td class="unit-item unit-item-spear">500</td>
                var pattern = $@"unit-item-{unitType}[^>]*>(\d+)<";
                var match = Regex.Match(html, pattern);
                
                if (match.Success && int.TryParse(match.Groups[1].Value, out int count))
                    return count;
                
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private async Task SyncRecruitmentQueuesAsync(Village village)
        {
            try
            {
                // Kışla kuyruğu
                if (village.BuildingBarracks > 0)
                {
                    var barracksHtml = await _browser.GetPageContentAsync("train");
                    var barracksQueue = _htmlParser.ParseRecruitmentQueue(barracksHtml, "barracks");
                    if (barracksQueue.Any())
                    {
                        village.BarracksQueueJson = System.Text.Json.JsonSerializer.Serialize(barracksQueue);
                    }
                }

                // Ahır kuyruğu
                if (village.BuildingStable > 0)
                {
                    var stableHtml = await _browser.GetPageContentAsync("train");
                    var stableQueue = _htmlParser.ParseRecruitmentQueue(stableHtml, "stable");
                    if (stableQueue.Any())
                    {
                        village.StableQueueJson = System.Text.Json.JsonSerializer.Serialize(stableQueue);
                    }
                }

                // Atölye kuyruğu
                if (village.BuildingGarage > 0)
                {
                    var garageHtml = await _browser.GetPageContentAsync("train");
                    var garageQueue = _htmlParser.ParseRecruitmentQueue(garageHtml, "garage");
                    if (garageQueue.Any())
                    {
                        village.GarageQueueJson = System.Text.Json.JsonSerializer.Serialize(garageQueue);
                    }
                }

                // Akademi kuyruğu (Soylu)
                if (village.BuildingSnob > 0)
                {
                    var snobHtml = await _browser.GetPageContentAsync("snob");
                    var snobQueue = _htmlParser.ParseRecruitmentQueue(snobHtml, "snob");
                    if (snobQueue.Any())
                    {
                        village.SnobQueueJson = System.Text.Json.JsonSerializer.Serialize(snobQueue);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata olursa logla ama devam et
                Console.WriteLine($"Recruitment queue sync error: {ex.Message}");
            }
        }

        private async Task SyncResearchLevelsAsync(Village village)
        {
            try
            {
                if (village.BuildingSmithy > 0)
                {
                    var smithyHtml = await _browser.GetPageContentAsync("smith");
                    var research = _htmlParser.ParseResearchLevels(smithyHtml);

                    village.ResearchSpear = research.GetValueOrDefault("spear", 0);
                    village.ResearchSword = research.GetValueOrDefault("sword", 0);
                    village.ResearchAxe = research.GetValueOrDefault("axe", 0);
                    village.ResearchSpy = research.GetValueOrDefault("spy", 0);
                    village.ResearchLight = research.GetValueOrDefault("light", 0);
                    village.ResearchHeavy = research.GetValueOrDefault("heavy", 0);
                    village.ResearchRam = research.GetValueOrDefault("ram", 0);
                    village.ResearchCatapult = research.GetValueOrDefault("catapult", 0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Research levels sync error: {ex.Message}");
            }
        }
    }
}
