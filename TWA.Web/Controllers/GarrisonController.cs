using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;

namespace TWA.Web.Controllers
{
    public class GarrisonController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public GarrisonController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            
            // OwnedTroops null ise initialize et
            foreach (var village in villages)
            {
                if (village.OwnedTroops == null)
                {
                    village.OwnedTroops = new TroopSet();
                }
            }
            
            return View(villages.OrderByDescending(v => v.OwnedTroops.Total()));
        }

        [HttpGet]
        public async Task<IActionResult> GetTroops(int villageId)
        {
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(villageId);
            if (village == null) return NotFound();

            return Json(new
            {
                villageId = village.Id,
                troops = new
                {
                    spear = village.OwnedTroops.Spear,
                    sword = village.OwnedTroops.Sword,
                    axe = village.OwnedTroops.Axe,
                    light = village.OwnedTroops.Light,
                    heavy = village.OwnedTroops.Heavy,
                    ram = village.OwnedTroops.Ram,
                    catapult = village.OwnedTroops.Catapult,
                    snob = village.OwnedTroops.Snob
                }
            });
        }
    }
}
