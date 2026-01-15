using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class AcademyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AcademyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int? villageId)
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            var selectedVillage = villageId.HasValue 
                ? villages.FirstOrDefault(v => v.Id == villageId.Value) 
                : villages.FirstOrDefault();

            if (selectedVillage == null)
                return RedirectToAction("Index", "Village");

            var model = new AcademyViewModel
            {
                Villages = villages.OrderBy(v => v.Name).ToList(),
                SelectedVillageId = selectedVillage.Id,
                SelectedVillage = selectedVillage,
                AcademyLevel = selectedVillage.BuildingSnob,
                AvailableCoins = 0, // TODO: Load from database
                CoinsInProduction = 0 // TODO: Load from database
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> MintCoin(int villageId)
        {
            // TODO: Implement coin minting via GameBrowserService
            TempData["Success"] = "Altın sikke basımı başlatıldı!";
            return RedirectToAction("Index", new { villageId });
        }
    }
}
