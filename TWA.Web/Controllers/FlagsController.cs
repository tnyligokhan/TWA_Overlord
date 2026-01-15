using Microsoft.AspNetCore.Mvc;
using TWA.Core.Interfaces;
using TWA.Core.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;

namespace TWA.Web.Controllers
{
    public class FlagsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FlagsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index(int id)
        {
            // id is VillageId
             if (id == 0)
            {
                var firstVillage = (await _unitOfWork.Repository<Village>().GetAllAsync()).FirstOrDefault();
                if (firstVillage != null) id = firstVillage.Id;
            }

            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(id);
            if (village == null)
            {
                return NotFound("Köy bulunamadı.");
            }
            
            // Deserialize FlagsJson
            Dictionary<string, int> flags = new Dictionary<string, int>();
            if (!string.IsNullOrEmpty(village.FlagsJson))
            {
                try
                {
                    flags = JsonSerializer.Deserialize<Dictionary<string, int>>(village.FlagsJson);
                }
                catch { }
            }

            ViewBag.VillageName = village.Name;
            return View(flags);
        }
    }
}
