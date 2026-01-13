using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class EconomyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEconomyService _economyService;

        public EconomyController(IUnitOfWork unitOfWork, IEconomyService economyService)
        {
            _unitOfWork = unitOfWork;
            _economyService = economyService;
        }

        public async Task<IActionResult> Index()
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            
            var model = new EconomyViewModel
            {
                TotalWood = villages.Sum(v => (long)v.Wood),
                TotalClay = villages.Sum(v => (long)v.Stone), // Map Stone to Clay (TribalWars Logic)
                TotalIron = villages.Sum(v => (long)v.Iron),
                TotalGoldCoins = 450, // Mock Data
                // Basit bir üretim tahmini (Gerçekte bina seviyesinden hesaplanır)
                TotalProductionPerHour = villages.Count() * 2400 * 3, 
                
                VillageResources = villages.Select(v => new VillageEconomyState
                {
                    VillageId = v.Id,
                    VillageName = v.Name,
                    Coordinates = v.Coordinates,
                    Wood = v.Wood,
                    Clay = v.Stone, // Map Stone to Clay
                    Iron = v.Iron,
                    StorageCapacity = v.StorageCapacity,
                    // Mock ROI verisi (Gerçekte _economyService.CalculateROI çağrılır)
                    BestRoiBuilding = v.Wood < v.StorageCapacity ? "Oduncu (12h)" : "Depo (Acil)",
                    ActiveMerchants = 10, // Mock
                    TotalMerchants = 110 // Mock (Pazar seviyesine göre)
                }).OrderByDescending(v => v.IsStorageFull).ToList() // Dolular en üstte
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DistributeResources()
        {
            // Burası "Otomatik Dengeleyici" (Balancer) modülünü tetikler.
            // Lojistik algoritması çalışır ve market emirleri (Task) oluşturulur.
            
            // Simülasyon:
            await Task.Delay(500); 
            return Json(new { success = true, message = "Lojistik ağı optimize edildi. 12 sevkiyat emri oluşturuldu." });
        }

        [HttpPost]
        public async Task<IActionResult> MintCoins()
        {
            // "Altın/Gümüş Fabrikası" modülünü tetikler.
            // Sarayı olan köylerde kaynak varsa altın basar.
            
            await Task.Delay(500);
            return Json(new { success = true, message = "Tüm saraylarda altın basımı tamamlandı. +4 Misyoner limiti kazanıldı." });
        }
    }
}
