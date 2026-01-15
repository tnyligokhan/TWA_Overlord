using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatisticsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            
            var model = new StatisticsViewModel
            {
                TotalVillages = villages.Count(),
                TotalPopulation = villages.Sum(v => v.PopulationCurrent),
                TotalTroops = 0, // TODO: Calculate
                TotalResources = villages.Sum(v => v.Wood + v.Stone + v.Iron),
                VillageStats = villages.Select(v => new VillageStatItem
                {
                    VillageId = v.Id,
                    VillageName = v.Name,
                    Coordinates = v.Coordinates,
                    Points = v.Points,
                    Population = v.PopulationCurrent,
                    TotalTroops = 0 // TODO: Calculate
                }).OrderByDescending(v => v.Points).ToList()
            };

            return View(model);
        }
    }
}
