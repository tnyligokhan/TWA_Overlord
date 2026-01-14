using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Service.Services;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class WarfareController : Controller
    {
        private readonly DeceptionService _deceptionService;
        private readonly OpCoordinatorService _opCoordinator;
        private readonly IUnitOfWork _unitOfWork;

        public WarfareController(DeceptionService deceptionService, OpCoordinatorService opCoordinator, IUnitOfWork unitOfWork)
        {
            _deceptionService = deceptionService;
            _opCoordinator = opCoordinator;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var attacks = await _unitOfWork.Repository<AttackTask>()
                .FindAsync(a => a.Status == AttackStatus.Scheduled || a.Status == AttackStatus.Sent);

            var model = new WarfareViewModel
            {
                ActiveAttacks = attacks.OrderBy(a => a.LaunchTime).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LaunchGhostTrain(int sourceId, int targetX, int targetY)
        {
            await _deceptionService.LaunchGhostTrainAsync(sourceId, targetX, targetY);
            return Json(new { success = true, message = "Ghost Train launched!" });
        }

        [HttpPost]
        public async Task<IActionResult> CalculateSnipe(int targetX, int targetY, DateTime arrivalTime)
        {
            // Basit snipe hesaplama endpoint'i (JS'de de var ama Server-Side doğrulama için)
            // Şimdilik sadece başarılı dönüyoruz, asıl logic OpCoordinator'da planlanabilir.
            return Json(new { success = true });
        }
    }
}
