using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class MarketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MarketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int? villageId)
        {
            var villages = (await _unitOfWork.Repository<Village>().GetAllAsync()).ToList();
            
            var selectedVillageId = villageId ?? villages.FirstOrDefault()?.Id ?? 0;
            var selectedVillage = villages.FirstOrDefault(v => v.Id == selectedVillageId);
            
            // Market level doesn't exist in Village entity, using a default value
            int merchantCount = 10; // Default merchant count
            
            var model = new MarketViewModel
            {
                Villages = villages,
                SelectedVillageId = selectedVillageId,
                SelectedVillage = selectedVillage,
                AvailableMerchants = merchantCount,
                TotalMerchants = merchantCount
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendResources(MarketViewModel model)
        {
            // TODO: Implement resource sending via GameBrowserService
            TempData["Success"] = "Kaynak gönderimi başlatıldı!";
            return RedirectToAction("Index", new { villageId = model.SelectedVillageId });
        }

        public async Task<IActionResult> Transports()
        {
            var model = new TransportsViewModel
            {
                IncomingTransports = new List<TransportItem>(), // TODO: Load from database
                OutgoingTransports = new List<TransportItem>() // TODO: Load from database
            };

            return View(model);
        }
    }
}
