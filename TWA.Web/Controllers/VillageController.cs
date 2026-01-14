using Microsoft.AspNetCore.Mvc;
using TWA.Core.Interfaces;
using TWA.Core.Entities;

namespace TWA.Web.Controllers
{
    public class VillageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            return View(villages.OrderByDescending(v => v.Points));
        }

        public async Task<IActionResult> Details(int id)
        {
            // Repository'den köyü getir (BuildQueue ve Attacks şimdilik yükleme - DB hatası veriyor)
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(id);
            
            if (village == null) return NotFound();

            // OwnedTroops null ise initialize et
            if (village.OwnedTroops == null)
            {
                village.OwnedTroops = new TroopSet();
            }
            
            if (village.TotalTroops == null)
            {
                village.TotalTroops = new TroopSet();
            }

            // View'a gönder
            return View(village);
        }
    }
}
