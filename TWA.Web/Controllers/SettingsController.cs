using Microsoft.AspNetCore.Mvc;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            var model = new SettingsViewModel
            {
                GameSettings = new GameSettings
                {
                    AutoSync = true,
                    SyncInterval = 60,
                    AutoBuild = false,
                    AutoRecruit = false
                },
                BotSettings = new BotSettings
                {
                    IsActive = false,
                    MaxConcurrentTasks = 5,
                    DelayBetweenActions = 2000
                }
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveGameSettings(GameSettings settings)
        {
            // TODO: Save to database or config file
            TempData["Success"] = "Oyun ayarları kaydedildi!";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveBotSettings(BotSettings settings)
        {
            // TODO: Save to database or config file
            TempData["Success"] = "Bot ayarları kaydedildi!";
            return RedirectToAction("Index");
        }
    }
}
