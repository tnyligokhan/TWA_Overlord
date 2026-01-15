using Microsoft.AspNetCore.Mvc;
using TWA.Core.Interfaces;
using TWA.Core.Entities;
using TWA.Service.Services;

namespace TWA.Web.Controllers.Api
{
    [ApiController]
    [Route("api/sync")]
    public class SyncApiController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly VillageDataSyncService _syncService;

        public SyncApiController(IUnitOfWork unitOfWork, VillageDataSyncService syncService)
        {
            _unitOfWork = unitOfWork;
            _syncService = syncService;
        }

        [HttpPost("village/{id}")]
        public async Task<IActionResult> SyncVillage(int id)
        {
            try
            {
                var village = await _unitOfWork.Repository<Village>().GetByIdAsync(id);
                if (village == null)
                    return NotFound(new { success = false, message = "Köy bulunamadı" });

                await _syncService.SyncAllVillageDataAsync(id);
                await _unitOfWork.CommitAsync();

                return Ok(new
                {
                    success = true,
                    message = $"{village.Name} senkronize edildi",
                    data = new
                    {
                        village.Id,
                        village.Name,
                        village.Wood,
                        village.Stone,
                        village.Iron,
                        village.PopulationCurrent,
                        village.PopulationMax,
                        OwnedTroops = village.OwnedTroops,
                        BuildingLevels = new
                        {
                            village.BuildingMain,
                            village.BuildingBarracks,
                            village.BuildingStable,
                            village.BuildingGarage,
                            village.BuildingSnob,
                            village.BuildingStatue,
                            village.BuildingWall
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Senkronizasyon hatası: " + ex.Message
                });
            }
        }

        [HttpPost("all")]
        public async Task<IActionResult> SyncAllVillages()
        {
            try
            {
                var villages = (await _unitOfWork.Repository<Village>().GetAllAsync()).ToList();
                var results = new List<object>();

                foreach (var village in villages)
                {
                    try
                    {
                        await _syncService.SyncAllVillageDataAsync(village.Id);
                        results.Add(new
                        {
                            villageId = village.Id,
                            villageName = village.Name,
                            success = true
                        });
                    }
                    catch (Exception ex)
                    {
                        results.Add(new
                        {
                            villageId = village.Id,
                            villageName = village.Name,
                            success = false,
                            error = ex.Message
                        });
                    }
                }

                await _unitOfWork.CommitAsync();

                return Ok(new
                {
                    success = true,
                    message = $"{results.Count(r => ((dynamic)r).success)} / {villages.Count} köy senkronize edildi",
                    results
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "Toplu senkronizasyon hatası: " + ex.Message
                });
            }
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetSyncStatus()
        {
            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            return Ok(new
            {
                totalVillages = villages.Count(),
                lastSync = DateTime.Now, // TODO: Track actual last sync time
                isOnline = true
            });
        }
    }
}
