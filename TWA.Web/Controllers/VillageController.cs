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
            // Repository'den köyü, askerleri ve inşaat planlarını getir
            // (Gerçek senaryoda .Include() kullanmanız gerekebilir)
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(id);
            
            if (village == null) return NotFound();

            // View'a gönder
            return View(village);
        }
    }
}
