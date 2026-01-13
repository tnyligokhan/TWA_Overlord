using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TWA.Service.Services;

namespace TWA.Web.Controllers
{
    public class WarfareController : Controller
    {
        private readonly DeceptionService _deceptionService;
        private readonly OpCoordinatorService _opCoordinator;

        public WarfareController(DeceptionService deceptionService, OpCoordinatorService opCoordinator)
        {
            _deceptionService = deceptionService;
            _opCoordinator = opCoordinator;
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
