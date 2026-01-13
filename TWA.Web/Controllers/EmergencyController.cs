using Microsoft.AspNetCore.Mvc;
using TWA.Core.Interfaces.Services;

namespace TWA.Web.Controllers
{
    public class EmergencyController : Controller
    {
        private readonly IEmergencyService _emergencyService;

        public EmergencyController(IEmergencyService emergencyService)
        {
            _emergencyService = emergencyService;
        }

        public IActionResult Index()
        {
            ViewBag.IsLocked = _emergencyService.IsSystemLocked();
            return View();
        }

        [HttpPost]
        public IActionResult ToggleKillSwitch(bool enable)
        {
            if (enable)
                _emergencyService.TriggerKillSwitch();
            else
                _emergencyService.RevokeKillSwitch();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> PanicDefense()
        {
            await _emergencyService.TriggerMassMilitiaAsync();
            TempData["Message"] = "Tüm köylerde Milisler silahlandırıldı! Çiftlik üretimi %50 düştü.";
            return RedirectToAction("Index");
        }
    }
}
