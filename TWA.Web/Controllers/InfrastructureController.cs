using Microsoft.AspNetCore.Mvc;
using TWA.Core.Interfaces;
using TWA.Core.Entities;
using TWA.Core.DTOs;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class InfrastructureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InfrastructureController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int? villageId)
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            
            var selectedVillageId = villageId ?? villages.FirstOrDefault()?.Id ?? 0;
            var selectedVillage = villages.FirstOrDefault(v => v.Id == selectedVillageId);

            if (selectedVillage == null)
            {
                return View(new InfrastructureViewModel());
            }

            // Parse JSON build queue
            var buildQueue = ParseBuildQueue(selectedVillage.BuildQueueJson);
            
            var model = new InfrastructureViewModel
            {
                ActiveBuilds = buildQueue
                    .Where(b => b.IsActive)
                    .Select(b => new ConstructionTask
                    {
                        Id = Guid.NewGuid().ToString(),
                        VillageName = selectedVillage.Name,
                        BuildingName = GetBuildingName(b.BuildingType),
                        BuildingIcon = GetBuildingIcon(b.BuildingType),
                        CurrentLevel = b.CurrentLevel,
                        TargetLevel = b.TargetLevel,
                        StartTime = b.StartTime,
                        EndTime = b.EndTime,
                        IsActive = true
                    }).ToList(),

                BuildQueue = buildQueue
                    .Where(b => !b.IsActive)
                    .Select(b => new ConstructionTask
                    {
                        Id = Guid.NewGuid().ToString(),
                        VillageName = selectedVillage.Name,
                        BuildingName = GetBuildingName(b.BuildingType),
                        BuildingIcon = GetBuildingIcon(b.BuildingType),
                        CurrentLevel = b.CurrentLevel,
                        TargetLevel = b.TargetLevel,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now.AddHours(1),
                        IsActive = false
                    }).ToList()
            };

            return View(model);
        }

        private List<BuildQueueItem> ParseBuildQueue(string json)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(json) || json == "[]")
                    return new List<BuildQueueItem>();
                
                return System.Text.Json.JsonSerializer.Deserialize<List<BuildQueueItem>>(json) ?? new List<BuildQueueItem>();
            }
            catch
            {
                return new List<BuildQueueItem>();
            }
        }

        private string GetBuildingName(string type)
        {
            return type switch
            {
                "main" => "Saray",
                "barracks" => "Kışla",
                "stable" => "Ahır",
                "garage" => "Atölye",
                "snob" => "Akademi",
                "smith" => "Demirci",
                "place" => "Meydan",
                "statue" => "Heykel",
                "market" => "Pazar",
                "wood" => "Oduncu",
                "stone" => "Taş Ocağı",
                "iron" => "Demir Madeni",
                "farm" => "Çiftlik",
                "storage" => "Depo",
                "hide" => "Sığınak",
                "wall" => "Sur",
                _ => type
            };
        }

        private string GetBuildingIcon(string type)
        {
            return type switch
            {
                "main" => "fas fa-crown",
                "barracks" => "fas fa-shield-alt",
                "stable" => "fas fa-horse",
                "garage" => "fas fa-tools",
                "snob" => "fas fa-graduation-cap",
                "smith" => "fas fa-hammer",
                "place" => "fas fa-flag",
                "statue" => "fas fa-monument",
                "market" => "fas fa-store",
                "wood" => "fas fa-tree",
                "stone" => "fas fa-mountain",
                "iron" => "fas fa-gem",
                "farm" => "fas fa-tractor",
                "storage" => "fas fa-warehouse",
                "hide" => "fas fa-shield",
                "wall" => "fas fa-fort-awesome",
                _ => "fas fa-building"
            };
        }

        private int CalculateProgress(DateTime start, DateTime end)
        {
            var total = (end - start).TotalSeconds;
            var elapsed = (DateTime.Now - start).TotalSeconds;
            return total > 0 ? (int)((elapsed / total) * 100) : 0;
        }
    }
}

