using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class BuildingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BuildingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Smithy(int? villageId)
        {
            var villages = (await _unitOfWork.Repository<Village>().GetAllAsync()).ToList();
            
            var selectedVillageId = villageId ?? villages.FirstOrDefault()?.Id ?? 0;
            var selectedVillage = villages.FirstOrDefault(v => v.Id == selectedVillageId);
            
            var model = new SmithyViewModel
            {
                Villages = villages,
                SelectedVillageId = selectedVillageId,
                SelectedVillage = selectedVillage
            };
            
            return View(model);
        }
    }
}
