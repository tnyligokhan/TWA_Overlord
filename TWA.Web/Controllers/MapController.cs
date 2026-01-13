using Microsoft.AspNetCore.Mvc;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class MapController : Controller
    {
        private readonly IMapScannerService _mapService;
        private readonly IUnitOfWork _unitOfWork;

        public MapController(IMapScannerService mapService, IUnitOfWork unitOfWork)
        {
            _mapService = mapService;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(MapRadarViewModel model)
        {
            // Eğer koordinat girilmemişse, ilk köyümüzün koordinatını alalım
            if (model.CenterX == 500 && model.CenterY == 500)
            {
                var myVillage = (await _unitOfWork.Repository<Core.Entities.Village>().GetAllAsync()).FirstOrDefault();
                if (myVillage != null)
                {
                    model.CenterX = myVillage.CoordinateX;
                    model.CenterY = myVillage.CoordinateY;
                }
            }

            // Radar Taraması (Veritabanından)
            // Not: FindTargetsNearAsync metodunu daha önce Service katmanında yazmıştık.
            var targets = await _mapService.FindTargetsNearAsync(
                model.CenterX, 
                model.CenterY, 
                model.Radius, 
                model.MinPoints, 
                model.MaxPoints
            );

            model.Targets = targets;

            return View(model);
        }

        [HttpPost]
        public IActionResult Scan(MapRadarViewModel model)
        {
            // Filtreleri uygulayıp sayfayı yeniler
            return RedirectToAction("Index", model);
        }
    }
}
