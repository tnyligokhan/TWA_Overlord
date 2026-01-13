using Microsoft.AspNetCore.Mvc;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class InfrastructureController : Controller
    {
        public IActionResult Index()
        {
            // MOCK DATA for "Engineering Dashboard"
            var model = new InfrastructureViewModel();

            // 1. Active Builds (Under Construction)
            model.ActiveBuilds = new List<ConstructionTask>
            {
                new ConstructionTask
                {
                    VillageName = "001 | KUZEY KALESİ",
                    BuildingName = "Demir Madeni",
                    BuildingIcon = "fas fa-mountain",
                    CurrentLevel = 28,
                    TargetLevel = 29,
                    StartTime = DateTime.Now.AddMinutes(-45),
                    EndTime = DateTime.Now.AddMinutes(12), // 12 mins left
                    IsActive = true
                },
                new ConstructionTask
                {
                    VillageName = "002 | DOĞU CEPHESİ",
                    BuildingName = "Kışla",
                    BuildingIcon = "fas fa-dungeon",
                    CurrentLevel = 24,
                    TargetLevel = 25,
                    StartTime = DateTime.Now.AddHours(-2),
                    EndTime = DateTime.Now.AddMinutes(45), // 45 mins left
                    IsActive = true
                },
                new ConstructionTask
                {
                    VillageName = "003 | MERKEZ",
                    BuildingName = "Saray",
                    BuildingIcon = "fas fa-chess-rook",
                    CurrentLevel = 0,
                    TargetLevel = 1,
                    StartTime = DateTime.Now.AddHours(-1),
                    EndTime = DateTime.Now.AddHours(2).AddMinutes(15), 
                    IsActive = true
                }
            };

            // 2. Build Queue (Waiting)
            model.BuildQueue = new List<ConstructionTask>
            {
                 new ConstructionTask
                {
                    VillageName = "001 | KUZEY KALESİ",
                    BuildingName = "Sur",
                    BuildingIcon = "fas fa-shield-alt",
                    CurrentLevel = 19,
                    TargetLevel = 20,
                    StartTime = DateTime.Now.AddHours(1),
                    EndTime = DateTime.Now.AddHours(5),
                    IsActive = false
                },
                new ConstructionTask
                {
                    VillageName = "004 | GÜNEY LİMAN",
                    BuildingName = "Depo",
                    BuildingIcon = "fas fa-warehouse",
                    CurrentLevel = 29,
                    TargetLevel = 30,
                    StartTime = DateTime.Now.AddHours(3),
                    EndTime = DateTime.Now.AddHours(12),
                    IsActive = false
                }
            };

            return View(model); 
        }
    }
}
