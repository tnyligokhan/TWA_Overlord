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
        private readonly IMapScannerService _mapScannerService;

        public VillageDataSyncService(
            IGameBrowserService browser,
            IHtmlParsingService htmlParser,
            IUnitOfWork unitOfWork,
            IMapScannerService mapScannerService)
        {
            _browser = browser;
            _htmlParser = htmlParser;
            _unitOfWork = unitOfWork;
            _mapScannerService = mapScannerService;
        }

        public async Task SyncAllVillageDataAsync(int villageId, Func<string, Task>? onProgress = null)
        {
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(villageId);
            if (village == null) 
            {
                 // Create village if it doesn't exist? Ideally we should have it.
                 // For now, try to fetch minimal info or return.
                 // Let's assume we can create it or just return.
                 // Actually, best to ensure it exists.
                 // If null, we might be syncing a new village. Return for now or handle creation.
                 return;
            }

            // 1. Ana Bina sayfasından bina seviyeleri
            await SyncBuildingLevelsAsync(village);
            await (onProgress?.Invoke("Bina seviyeleri senkronize edildi.") ?? Task.CompletedTask);

            // 2. Genel Bakış'tan kaynaklar ve nüfus
            await SyncResourcesAndPopulationAsync(village);
            await (onProgress?.Invoke("Kaynaklar ve nüfus verileri güncellendi.") ?? Task.CompletedTask);

            // 3. Kışla/Ahır/Atölye'den asker sayıları
            await SyncTroopsAsync(village);
            await (onProgress?.Invoke("Asker sayıları (Köy ve Temizlik) senkronize edildi.") ?? Task.CompletedTask);

            // 4. Demirci'den araştırma seviyelerini çek
            await SyncResearchLevelsAsync(village);
            await (onProgress?.Invoke("Araştırma seviyeleri alındı.") ?? Task.CompletedTask);

            // 5. Askeri üretim kuyruklarını çek
            await SyncRecruitmentQueuesAsync(village);
            await (onProgress?.Invoke("Asker üretim kuyrukları güncellendi.") ?? Task.CompletedTask);

            // 6. Komutları çek (Saldırı/Destek)
            await SyncCommandsAsync(village);
            await (onProgress?.Invoke("Gelen/Giden komutlar senkronize edildi.") ?? Task.CompletedTask);

            // 7. Pazar verilerini çek
            await SyncMarketAsync(village);
            await (onProgress?.Invoke("Pazar verileri (Teklifler/Tüccarlar) güncellendi.") ?? Task.CompletedTask);

            // 8. Raporları çek
            await SyncReportsAsync(village);
            await (onProgress?.Invoke("Raporlar ve detayları senkronize edildi.") ?? Task.CompletedTask);

            // 9. Şövalye bilgisini çek
            await SyncKnightAsync(village);
            await (onProgress?.Invoke("Şövalye durumu güncellendi.") ?? Task.CompletedTask);

            // 10. Harita (Map)
            await SyncMapAsync(village);
            await (onProgress?.Invoke("Harita verileri tarandı.") ?? Task.CompletedTask);


            // 11. Envanter (Inventory) 
            await SyncInventoryAsync(village);

            // 12. Bayraklar (Flags)
            await SyncFlagsAsync(village);

            // Kaydet
            try
            {
                    _unitOfWork.Repository<Village>().Update(village);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException?.Message ?? "No inner exception";
                throw new Exception($"Veritabanı Kayıt Hatası: {ex.Message} -> {innerMessage}", ex);
            }
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
                    case "market": village.BuildingMarket = building.Value; break;
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
            // Overview sayfasından saatlik üretim verilerini al
            var overviewHtml = await _browser.GetPageContentAsync("overview");
            var hourlyProduction = _htmlParser.ParseHourlyProduction(overviewHtml);
            
            if (hourlyProduction.ContainsKey("wood"))
                village.WoodHourly = hourlyProduction["wood"];
            if (hourlyProduction.ContainsKey("stone"))
                village.StoneHourly = hourlyProduction["stone"];
            if (hourlyProduction.ContainsKey("iron"))
                village.IronHourly = hourlyProduction["iron"];
            
            // JavaScript'ten game_data objesini oku
            village.Wood = await _browser.GetGameDataIntAsync("game_data.village.wood");
            village.Stone = await _browser.GetGameDataIntAsync("game_data.village.stone");
            village.Iron = await _browser.GetGameDataIntAsync("game_data.village.iron");
            
            village.StorageCapacity = await _browser.GetGameDataIntAsync("game_data.village.storage_max");
            
            village.PopulationCurrent = await _browser.GetGameDataIntAsync("game_data.village.pop");
            village.PopulationMax = await _browser.GetGameDataIntAsync("game_data.village.pop_max");
            
            village.Points = await _browser.GetGameDataIntAsync("game_data.village.points");
            village.Name = await _browser.GetGameDataStringAsync("game_data.village.name");
            
            // Koordinatları güncelleme - unique constraint ihlali yaratır
            // village.CoordinateX = await _browser.GetGameDataIntAsync("game_data.village.x");
            // village.CoordinateY = await _browser.GetGameDataIntAsync("game_data.village.y");
        }

        private async Task SyncTroopsAsync(Village village)
        {
            // İçtima Meydanı'ndan asker sayılarını oku
            var html = await _browser.GetPageContentAsync("place&mode=units");
            
            if (village.OwnedTroops == null)
                village.OwnedTroops = new TroopSet();

            // Modular TroopParser kullanarak tüm asker sayılarını parse et
            var troops = _htmlParser.ParseTroopCounts(html);
            
            village.OwnedTroops.Spear = troops.GetValueOrDefault("spear", 0);
            village.OwnedTroops.Sword = troops.GetValueOrDefault("sword", 0);
            village.OwnedTroops.Axe = troops.GetValueOrDefault("axe", 0);
            village.OwnedTroops.Spy = troops.GetValueOrDefault("spy", 0);
            village.OwnedTroops.Light = troops.GetValueOrDefault("light", 0);
            village.OwnedTroops.Heavy = troops.GetValueOrDefault("heavy", 0);
            village.OwnedTroops.Ram = troops.GetValueOrDefault("ram", 0);
            village.OwnedTroops.Catapult = troops.GetValueOrDefault("catapult", 0);
            village.OwnedTroops.Knight = troops.GetValueOrDefault("knight", 0);
            village.OwnedTroops.Snob = troops.GetValueOrDefault("snob", 0);
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

        private async Task SyncCommandsAsync(Village village)
        {
            try
            {
                // Commands overview
                // e.g. screen=overview_villages&mode=commands
                // Note: The URL might differ based on available screens, but usually accessible via overview
                var html = await _browser.GetPageContentAsync("overview_villages&mode=commands");
                var commands = _htmlParser.ParseCommands(html);

                if (commands.Any())
                {
                    // Assuming we want to wipe old commands and replace with new for this village/player context
                    // Or maybe just upsert. For simplicity, we'll try to add them if not existing.
                    var commandRepo = _unitOfWork.Repository<Command>();
                    
                    // Simple logic: Delete all incoming/outgoing for this village and re-add?
                    // Or ideally check by ID. 
                    // Since this is a sync service, simple replacement or smart merge is needed.
                    // For now, let's just Log count or assume simple addition for demo purposes
                    // In a real app, you'd carefully merge.
                    
                    foreach (var cmd in commands)
                    {
                        var existing = (await commandRepo.GetAllAsync())
                            .FirstOrDefault(c => c.GameId == cmd.GameId);
                            
                        if (existing == null)
                        {
                            await commandRepo.AddAsync(cmd);
                        }
                        else
                        {
                            // Update details
                            existing.ArrivalTime = cmd.ArrivalTime;
                            existing.CommandText = cmd.CommandText;
                            commandRepo.Update(existing);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Commands sync error: {ex.Message}");
            }
        }

        private async Task SyncMarketAsync(Village village)
        {
            try
            {
                if (village.BuildingMarket > 0)
                {
                    var html = await _browser.GetPageContentAsync("market");
                    
                    // Merchants
                    var available = _htmlParser.ParseAvailableMerchants(html);
                    var total = _htmlParser.ParseTotalMerchants(html);
                    
                    // Update village merchant info if property exists
                    village.AvailableMerchants = available;
                    village.TotalMerchants = total;

                    // Offers
                    var offers = _htmlParser.ParseTradeOffers(html);
                    if (offers.Any())
                    {
                        var offerRepo = _unitOfWork.Repository<TradeOffer>();
                        foreach (var offer in offers)
                        {
                            var existing = (await offerRepo.GetAllAsync()).FirstOrDefault(o => o.OfferId == offer.OfferId);
                             if (existing == null)
                             {
                                 await offerRepo.AddAsync(offer);
                             }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Market sync error: {ex.Message}");
            }
        }

        private async Task SyncReportsAsync(Village village)
        {
            try
            {
                var html = await _browser.GetPageContentAsync("report");
                var reports = _htmlParser.ParseReports(html);

                if (reports.Any())
                {
                    var reportRepo = _unitOfWork.Repository<Report>();
                    foreach (var report in reports)
                    {
                        var existing = (await reportRepo.GetAllAsync()).FirstOrDefault(r => r.GameId == report.GameId);
                        if (existing == null)
                        {
                            await reportRepo.AddAsync(report);
                            existing = report;
                        }
                        else
                        {
                            existing.IsUnread = report.IsUnread;
                            reportRepo.Update(existing);
                        }
                    }
                    
                    try { await _unitOfWork.CommitAsync(); }
                    catch (Exception ex)
                    {
                        var inner = ex.InnerException?.Message ?? "";
                        throw new Exception($"Rapor Kayıt Hatası: {ex.Message} -> {inner}", ex);
                    }

                    // 2nd Pass: Sync details
                    var reportsToSync = (await reportRepo.GetAllAsync())
                                        .Where(r => string.IsNullOrEmpty(r.HtmlContent))
                                        .OrderByDescending(r => r.Date)
                                        .Take(3)
                                        .ToList();

                    foreach (var r in reportsToSync)
                    {
                        try
                        {
                           var detailUrl = $"report&mode=all&view={r.GameId}";
                           var detailHtml = await _browser.GetPageContentAsync(detailUrl);
                           var detailReport = _htmlParser.ParseReportDetail(detailHtml);
                           
                           if (!string.IsNullOrEmpty(detailReport.HtmlContent))
                           {
                               r.HtmlContent = detailReport.HtmlContent;
                               reportRepo.Update(r);
                           }
                        }
                        catch { }
                    }
                    try { await _unitOfWork.CommitAsync(); }
                    catch (Exception ex)
                    {
                        var inner = ex.InnerException?.Message ?? "";
                        throw new Exception($"Rapor Detay Kayıt Hatası: {ex.Message} -> {inner}", ex);
                    }
                }
            }
            catch (Exception ex) when (!ex.Message.StartsWith("Rapor")) // Don't wrap already wrapped
            {
                 var inner = ex.InnerException?.Message ?? "";
                 throw new Exception($"Rapor Genel Hatası: {ex.Message} -> {inner}", ex);
            }
        }

        private async Task SyncKnightAsync(Village village)
        {
            try
            {
                if (village.BuildingStatue > 0)
                {
                    var html = await _browser.GetPageContentAsync("statue");
                    
                    var name = _htmlParser.ParseKnightName(html);
                    var isLocal = _htmlParser.IsKnightInVillage(html);
                    
                    village.KnightName = name;
                    village.IsKnightLocal = isLocal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Knight sync error: {ex.Message}");
            }
        }

        private async Task SyncMapAsync(Village village)
        {
             try
             {
                 // Usually map is centered on current village
                 var html = await _browser.GetPageContentAsync("map");
                 var sectors = _htmlParser.ParseMapData(html);
                 if (sectors != null && sectors.Any())
                 {
                     await _mapScannerService.ScanAndSaveBarbariansAsync(sectors);
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Map sync error: {ex.Message}");
             }
        }

        private async Task SyncInventoryAsync(Village village)
        {
             try
             {
                 var html = await _browser.GetPageContentAsync("inventory");
                 var items = _htmlParser.ParseInventory(html);
                 // Save items logic here... pending implementation of Inventory repo/table
                 // For now just parsing to ensure flow works
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Inventory sync error: {ex.Message}");
             }
        }

        private async Task SyncFlagsAsync(Village village)
        {
             try
             {
                 var html = await _browser.GetPageContentAsync("flags");
                 var flags = _htmlParser.ParseFlags(html);
                 if (flags.Any())
                 {
                     village.FlagsJson = System.Text.Json.JsonSerializer.Serialize(flags);
                 }
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Flags sync error: {ex.Message}");
             }
        }
    }
}
