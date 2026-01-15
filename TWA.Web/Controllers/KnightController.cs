using Microsoft.AspNetCore.Mvc;
using TWA.Core.Interfaces;
using TWA.Core.Entities;
using System.Threading.Tasks;

namespace TWA.Web.Controllers
{
    public class KnightController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public KnightController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int id)
        {
            // id is VillageId
            if (id == 0)
            {
                // If no ID provided, maybe pick the first village or redirect to dashboard
                // For now, let's try to find a default village
                var firstVillage = (await _unitOfWork.Repository<Village>().GetAllAsync()).FirstOrDefault();
                if (firstVillage != null) id = firstVillage.Id;
            }

            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(id);
            if (village == null)
            {
                return NotFound("Köy bulunamadı.");
            }

            return View(village);
        }
    }
}
