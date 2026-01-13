using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class AttackController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarfareService _warfareService;

        public AttackController(IUnitOfWork unitOfWork, IWarfareService warfareService)
        {
            _unitOfWork = unitOfWork;
            _warfareService = warfareService;
        }

        public async Task<IActionResult> Index()
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            
            // Sadece aktif (Bekleyen veya Zamanlanmış) saldırıları getir
            var allAttacks = await _unitOfWork.Repository<AttackTask>().GetAllAsync();
            var activeAttacks = allAttacks
                .Where(a => a.Status != AttackStatus.Cancelled && a.Status != AttackStatus.Failed)
                .OrderBy(a => a.LaunchTime) // En yakın çıkış zamanı en üstte
                .ToList();

            var model = new WarRoomViewModel
            {
                MyVillages = villages,
                Attacks = activeAttacks,
                CurrentVillageId = villages.FirstOrDefault()?.Id ?? 0
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ScheduleAttack(WarRoomViewModel model)
        {
            // Use NewTask from model
            var newTask = model.NewTask;

            // Koordinat Parse Et (455|600)
            if (string.IsNullOrEmpty(newTask.TargetCoordinates)) return BadRequest("Koordinat boş olamaz!");
            
            var coords = newTask.TargetCoordinates.Split('|'); // Use NewTask properties
            if (coords.Length != 2) return BadRequest("Hatalı Koordinat!");

            var task = new AttackTask
            {
                SourceVillageId = model.MyVillages.FirstOrDefault()?.Id ?? 1, // Defaulting for now as selection is not in form yet clearly
                TargetX = int.Parse(coords[0]),
                TargetY = int.Parse(coords[1]),
                Troops = newTask.Troops,
                Type = newTask.Type,
                Status = AttackStatus.Pending,
                // Eğer Snipe ise ArrivalTime, değilse LaunchTime (Hemen çık)
                ArrivalTime = newTask.Type == AttackType.Snipe ? newTask.ArrivalTime : DateTime.MinValue,
                LaunchTime = newTask.Type == AttackType.Snipe ? DateTime.MinValue : DateTime.UtcNow.AddSeconds(10) // 10sn buffer
            };

            // Savaş Motoruna Kaydet
            await _warfareService.ScheduleAttackAsync(task);

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Cancel(int id)
        {
            var task = await _unitOfWork.Repository<AttackTask>().GetByIdAsync(id);
            if (task != null)
            {
                task.Status = AttackStatus.Cancelled;
                _unitOfWork.Repository<AttackTask>().Update(task);
                await _unitOfWork.CommitAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
