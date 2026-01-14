using TWA.Core.DTOs;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;
using TWA.Core.Configuration;

using HtmlAgilityPack;

namespace TWA.Service.Services
{
    public class VillageService : IVillageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGameBrowserService _browserService;

        public VillageService(IUnitOfWork unitOfWork, IGameBrowserService browserService)
        {
            _unitOfWork = unitOfWork;
            _browserService = browserService;
        }

        public async Task ParseAndSyncAsync(string htmlContent)
        {
            // MODERN APPROACH: Use JavaScript game_data object instead of HTML parsing
            // This is more reliable and faster than XPath/CSS selectors
            
            try
            {
                // A. KÖYÜN TEMEL BİLGİLERİNİ ÇEK (game_data.village)
                int villageId = await _browserService.GetGameDataIntAsync(TechnicalSelectors.GlobalData.VillageId_JS);
                string villageName = await _browserService.GetGameDataStringAsync(TechnicalSelectors.GlobalData.VillageName_JS);
                int x = await _browserService.GetGameDataIntAsync(TechnicalSelectors.GlobalData.VillageX_JS);
                int y = await _browserService.GetGameDataIntAsync(TechnicalSelectors.GlobalData.VillageY_JS);
                int points = await _browserService.GetGameDataIntAsync(TechnicalSelectors.GlobalData.VillagePoints_JS);
                
                if (villageId == 0)
                {
                    throw new Exception("Köy ID'si alınamadı. game_data objesi yüklenmemiş olabilir.");
                }
                
                // B. KAYNAKLARI ÇEK
                int wood = await _browserService.GetGameDataIntAsync(TechnicalSelectors.GlobalData.Wood_JS);
                int stone = await _browserService.GetGameDataIntAsync(TechnicalSelectors.GlobalData.Stone_JS);
                int iron = await _browserService.GetGameDataIntAsync(TechnicalSelectors.GlobalData.Iron_JS);
                int storage = await _browserService.GetGameDataIntAsync(TechnicalSelectors.GlobalData.StorageMax_JS);
                int pop = await _browserService.GetGameDataIntAsync(TechnicalSelectors.GlobalData.PopCurrent_JS);
                int popMax = await _browserService.GetGameDataIntAsync(TechnicalSelectors.GlobalData.PopMax_JS);
                
                // C. ASKERLERİ ÇEK (unit_overview_table'dan)
                var troops = await ParseTroopsFromOverviewAsync();
                
                // D. DTO OLUŞTUR VE KAYDET
                var syncData = new VillageSyncDto
                {
                    GameId = villageId,
                    Name = villageName,
                    X = x,
                    Y = y,
                    Points = points,
                    Wood = wood,
                    Stone = stone,
                    Iron = iron,
                    StorageMax = storage,
                    PopCurrent = pop,
                    PopMax = popMax,
                    Spear = troops.Spear,
                    Sword = troops.Sword,
                    Axe = troops.Axe,
                    Spy = troops.Spy,
                    Light = troops.Light,
                    Heavy = troops.Heavy,
                    Ram = troops.Ram,
                    Catapult = troops.Catapult,
                    Knight = troops.Knight,
                    Snob = troops.Snob
                };

                await SyncVillageDataAsync(syncData);
            }
            catch (Exception ex)
            {
                throw new Exception($"Köy verisi parse edilemedi: {ex.Message}", ex);
            }
        }
        
        private async Task<TroopSet> ParseTroopsFromOverviewAsync()
        {
            var troops = new TroopSet();
            
            try
            {
                // Place sayfasına git (daha güvenilir - data-all-count attribute'u var)
                await _browserService.GetPageContentAsync("place");
                
                // DOM'dan asker sayılarını çek (data-all-count attribute'undan)
                troops.Spear = await _browserService.GetElementAttributeIntAsync(TechnicalSelectors.Warfare.SpearInput, "data-all-count");
                troops.Sword = await _browserService.GetElementAttributeIntAsync(TechnicalSelectors.Warfare.SwordInput, "data-all-count");
                troops.Axe = await _browserService.GetElementAttributeIntAsync(TechnicalSelectors.Warfare.AxeInput, "data-all-count");
                troops.Spy = await _browserService.GetElementAttributeIntAsync(TechnicalSelectors.Warfare.SpyInput, "data-all-count");
                troops.Light = await _browserService.GetElementAttributeIntAsync(TechnicalSelectors.Warfare.LightInput, "data-all-count");
                troops.Heavy = await _browserService.GetElementAttributeIntAsync(TechnicalSelectors.Warfare.HeavyInput, "data-all-count");
                troops.Ram = await _browserService.GetElementAttributeIntAsync(TechnicalSelectors.Warfare.RamInput, "data-all-count");
                troops.Catapult = await _browserService.GetElementAttributeIntAsync(TechnicalSelectors.Warfare.CatapultInput, "data-all-count");
                troops.Knight = await _browserService.GetElementAttributeIntAsync(TechnicalSelectors.Warfare.KnightInput, "data-all-count");
                troops.Snob = await _browserService.GetElementAttributeIntAsync(TechnicalSelectors.Warfare.SnobInput, "data-all-count");
            }
            catch
            {
                // Asker verisi alınamazsa boş TroopSet dön
            }
            
            return troops;
        }

        public async Task SyncVillageDataAsync(VillageSyncDto data)
        {
            var repo = _unitOfWork.Repository<Village>();
            
            // Köy var mı diye GameId ile bak
            var village = (await repo.FindAsync(v => v.GameId == data.GameId)).FirstOrDefault();

            if (village == null)
            {
                // Yoksa yeni oluştur
                village = new Village
                {
                    GameId = data.GameId,
                    CoordinateX = data.X,
                    CoordinateY = data.Y,
                    Type = VillageType.Own,
                    AiAction = "BUILD",
                    AiTarget = ""
                };
                await repo.AddAsync(village);
            }

            // Verileri Güncelle
            village.Name = data.Name;
            village.Points = data.Points;
            village.Wood = data.Wood;
            village.Stone = data.Stone;
            village.Iron = data.Iron;
            village.StorageCapacity = data.StorageMax;
            village.PopulationCurrent = data.PopCurrent;
            village.PopulationMax = data.PopMax;
            village.UpdatedDate = DateTime.UtcNow;

            // Askerleri Güncelle (TroopSet)
            village.OwnedTroops.Spear = data.Spear;
            village.OwnedTroops.Sword = data.Sword;
            village.OwnedTroops.Axe = data.Axe;
            village.OwnedTroops.Light = data.Light;
            village.OwnedTroops.Heavy = data.Heavy;
            village.OwnedTroops.Ram = data.Ram;
            village.OwnedTroops.Catapult = data.Catapult;
            village.OwnedTroops.Snob = data.Snob;

            // Değişiklikleri Kaydet
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Village>> GetVillagesNeedResourcesAsync()
        {
            // Deposu %20'nin altında olan köyler (Lojistik hedefi)
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            return villages.Where(v => v.Wood < (v.StorageCapacity * 0.2) || 
                                       v.Stone < (v.StorageCapacity * 0.2) || 
                                       v.Iron < (v.StorageCapacity * 0.2));
        }

        public async Task<IEnumerable<Village>> GetVillagesWithFullStorageAsync()
        {
            // Deposu %90 dolu olan köyler (Kaynak sağlayıcı)
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            return villages.Where(v => v.Wood > (v.StorageCapacity * 0.9) || 
                                       v.Stone > (v.StorageCapacity * 0.9) || 
                                       v.Iron > (v.StorageCapacity * 0.9));
        }

        public async Task<IEnumerable<Village>> GetAllVillagesAsync()
        {
            return await _unitOfWork.Repository<Village>().GetAllAsync();
        }
    }
}
