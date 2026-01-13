using TWA.Core.DTOs;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;

using HtmlAgilityPack;

namespace TWA.Service.Services
{
    public class VillageService : IVillageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ParseAndSyncAsync(string htmlContent)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            // A. HAMMADDELERİ OKU
            var woodNode = doc.DocumentNode.SelectSingleNode("//span[@id='wood']");
            var stoneNode = doc.DocumentNode.SelectSingleNode("//span[@id='stone']");
            var ironNode = doc.DocumentNode.SelectSingleNode("//span[@id='iron']");
            var storageNode = doc.DocumentNode.SelectSingleNode("//span[@id='storage']");
            var popNode = doc.DocumentNode.SelectSingleNode("//span[@id='pop_current']");
            var popMaxNode = doc.DocumentNode.SelectSingleNode("//span[@id='pop_max']");

            if (woodNode == null) return; // Veri çekilemedi

            int wood = int.Parse(woodNode.InnerText.Replace(".", "") ?? "0");
            int stone = int.Parse(stoneNode?.InnerText.Replace(".", "") ?? "0");
            int iron = int.Parse(ironNode?.InnerText.Replace(".", "") ?? "0");
            int storage = int.Parse(storageNode?.InnerText.Replace(".", "") ?? "0");
            int pop = int.Parse(popNode?.InnerText.Replace(".", "") ?? "0");
            int popMax = int.Parse(popMaxNode?.InnerText.Replace(".", "") ?? "0");

            // B. KÖY ID'SİNİ BUL (Linklerden ayıkla)
            var overviewLink = doc.DocumentNode.SelectSingleNode("//a[contains(@href, 'screen=overview')]")?.GetAttributeValue("href", "");
            int villageId = 0;
            
            if (overviewLink != null && overviewLink.Contains("village="))
            {
                var vIdStr = overviewLink.Split("village=")[1].Split('&')[0];
                villageId = int.Parse(vIdStr);
            }

            if (villageId == 0) return; // ID bulunamadı

            // C. DTO OLUŞTUR VE KAYDET
            var syncData = new VillageSyncDto
            {
                GameId = villageId,
                Name = "Köy " + villageId, // İsim sonra parse edilebilir
                Wood = wood,
                Stone = stone,
                Iron = iron,
                StorageMax = storage,
                PopCurrent = pop,
                PopMax = popMax,
                // Koordinatları şimdilik harita servisinden alıyoruz, burada 0 geçebiliriz
                X = 0, 
                Y = 0
            };

            await SyncVillageDataAsync(syncData);
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
                    Type = VillageType.Own
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
