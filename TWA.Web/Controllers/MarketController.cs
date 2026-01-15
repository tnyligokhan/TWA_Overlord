using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class MarketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly TWA.Core.Interfaces.Services.IGameBrowserService _browserService;

        public MarketController(IUnitOfWork unitOfWork, TWA.Core.Interfaces.Services.IGameBrowserService browserService)
        {
            _unitOfWork = unitOfWork;
            _browserService = browserService;
        }

        public async Task<IActionResult> Index(int? villageId)
        {
            var villages = (await _unitOfWork.Repository<Village>().GetAllAsync()).ToList();
            
            var selectedVillageId = villageId ?? villages.FirstOrDefault()?.Id ?? 0;
            var selectedVillage = villages.FirstOrDefault(v => v.Id == selectedVillageId);
            
            // Get Trade Offers
            // In a real app we might filter offers relevant to this village (e.g. range) or all.
            // For now, let's fetch all active offers.
            var offers = await _unitOfWork.Repository<TradeOffer>().GetAllAsync();
            
            var model = new MarketViewModel
            {
                Villages = villages,
                SelectedVillageId = selectedVillageId,
                SelectedVillage = selectedVillage,
                AvailableMerchants = selectedVillage?.AvailableMerchants ?? 0,
                TotalMerchants = selectedVillage?.TotalMerchants ?? 0,
                Offers = offers.ToList()
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SendResources(MarketViewModel model)
        {
            // TODO: Implement actual resource sending logic via _browserService
            // await _browserService.SendResourcesAsync(model.SelectedVillageId, model.TargetVillageId, model.Wood, model.Stone, model.Iron);
            
            TempData["Success"] = "Kaynak gönderimi sıraya alındı! (Simülasyon)";
            return RedirectToAction("Index", new { villageId = model.SelectedVillageId });
        }

        public async Task<IActionResult> Transports()
        {
            var model = new TransportsViewModel
            {
                // Currently we don't track transports in DB actively.
                IncomingTransports = new List<TransportItem>(), 
                OutgoingTransports = new List<TransportItem>() 
            };

            return View(model);
        }
    }
}
