using Microsoft.AspNetCore.Mvc;
using TWA.Core.Interfaces;
using TWA.Core.Entities;

namespace TWA.Web.Controllers
{
    public class VillageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            return View(villages);
        }

        public async Task<IActionResult> Details(int id)
        {
            // Repository'den köyü getir
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(id);
            
            if (village == null) return NotFound();

            // OwnedTroops null ise initialize et
            if (village.OwnedTroops == null)
            {
                village.OwnedTroops = new TroopSet();
            }
            
            if (village.TotalTroops == null)
            {
                village.TotalTroops = new TroopSet();
            }

            // Tüm kuyrukları parse et
            var allQueues = new List<TWA.Core.DTOs.RecruitmentQueueItem>();
            
            // Kışla kuyruğu
            if (!string.IsNullOrEmpty(village.BarracksQueueJson))
            {
                try
                {
                    var barracksQueue = System.Text.Json.JsonSerializer.Deserialize<List<TWA.Core.DTOs.RecruitmentQueueItem>>(village.BarracksQueueJson);
                    if (barracksQueue != null) allQueues.AddRange(barracksQueue);
                }
                catch { }
            }
            
            // Ahır kuyruğu
            if (!string.IsNullOrEmpty(village.StableQueueJson))
            {
                try
                {
                    var stableQueue = System.Text.Json.JsonSerializer.Deserialize<List<TWA.Core.DTOs.RecruitmentQueueItem>>(village.StableQueueJson);
                    if (stableQueue != null) allQueues.AddRange(stableQueue);
                }
                catch { }
            }
            
            // Atölye kuyruğu
            if (!string.IsNullOrEmpty(village.GarageQueueJson))
            {
                try
                {
                    var garageQueue = System.Text.Json.JsonSerializer.Deserialize<List<TWA.Core.DTOs.RecruitmentQueueItem>>(village.GarageQueueJson);
                    if (garageQueue != null) allQueues.AddRange(garageQueue);
                }
                catch { }
            }
            
            // Akademi kuyruğu
            if (!string.IsNullOrEmpty(village.SnobQueueJson))
            {
                try
                {
                    var snobQueue = System.Text.Json.JsonSerializer.Deserialize<List<TWA.Core.DTOs.RecruitmentQueueItem>>(village.SnobQueueJson);
                    if (snobQueue != null) allQueues.AddRange(snobQueue);
                }
                catch { }
            }
            
            // Kuyrukları zamana göre sırala
            allQueues = allQueues.OrderBy(q => q.StartTime).ToList();
            
            ViewBag.RecruitmentQueue = allQueues;

            // View'a gönder
            return View(village);
        }
    }
}
