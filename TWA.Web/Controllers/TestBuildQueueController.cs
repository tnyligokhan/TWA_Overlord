using Microsoft.AspNetCore.Mvc;
using TWA.Core.Interfaces;
using TWA.Core.Entities;
using System.Text.Json;
using TWA.Core.DTOs;

namespace TWA.Web.Controllers
{
    public class TestBuildQueueController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TestBuildQueueController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> AddTestQueue(int villageId = 1)
        {
            var village = await _unitOfWork.Repository<Village>().GetByIdAsync(villageId);
            if (village == null)
                return NotFound("Köy bulunamadı");

            var queue = new List<BuildQueueItem>
            {
                new BuildQueueItem
                {
                    BuildingType = "main",
                    CurrentLevel = village.BuildingMain,
                    TargetLevel = village.BuildingMain + 1,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddHours(2).AddMinutes(14),
                    IsActive = true
                },
                new BuildQueueItem
                {
                    BuildingType = "barracks",
                    CurrentLevel = village.BuildingBarracks,
                    TargetLevel = village.BuildingBarracks + 1,
                    StartTime = DateTime.Now.AddHours(2).AddMinutes(14),
                    EndTime = DateTime.Now.AddHours(3).AddMinutes(30),
                    IsActive = false
                },
                new BuildQueueItem
                {
                    BuildingType = "wall",
                    CurrentLevel = village.BuildingWall,
                    TargetLevel = village.BuildingWall + 1,
                    StartTime = DateTime.Now.AddHours(3).AddMinutes(30),
                    EndTime = DateTime.Now.AddHours(7).AddMinutes(15),
                    IsActive = false
                }
            };

            village.BuildQueueJson = JsonSerializer.Serialize(queue);
            _unitOfWork.Repository<Village>().Update(village);
            await _unitOfWork.CommitAsync();

            return Ok(new { 
                success = true, 
                message = "Test inşaat kuyruğu eklendi",
                queue = queue
            });
        }
    }
}
