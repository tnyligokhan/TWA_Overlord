using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Models;

namespace TWA.Web.Controllers
{
    public class RecruitmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecruitmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Kışla - Piyade Basma
        public async Task<IActionResult> Barracks(int? villageId)
        {
            var villages = (await _unitOfWork.Repository<Village>().GetAllAsync()).ToList();
            
            var selectedVillageId = villageId ?? villages.FirstOrDefault()?.Id ?? 0;
            var selectedVillage = villages.FirstOrDefault(v => v.Id == selectedVillageId);
            
            // Kışla kuyruğunu parse et
            var barracksQueue = new List<TWA.Core.DTOs.RecruitmentQueueItem>();
            if (selectedVillage != null && !string.IsNullOrEmpty(selectedVillage.BarracksQueueJson))
            {
                try
                {
                    barracksQueue = System.Text.Json.JsonSerializer.Deserialize<List<TWA.Core.DTOs.RecruitmentQueueItem>>(selectedVillage.BarracksQueueJson) ?? new List<TWA.Core.DTOs.RecruitmentQueueItem>();
                }
                catch { }
            }
            
            var model = new RecruitmentViewModel
            {
                Villages = villages,
                SelectedVillageId = selectedVillageId,
                SelectedVillage = selectedVillage,
                BuildingLevel = selectedVillage?.BuildingBarracks ?? 0,
                Queue = barracksQueue
            };
            
            return View(model);
        }

        // Ahır - Süvari Basma
        public async Task<IActionResult> Stable(int? villageId)
        {
            var villages = (await _unitOfWork.Repository<Village>().GetAllAsync()).ToList();
            
            var selectedVillageId = villageId ?? villages.FirstOrDefault()?.Id ?? 0;
            var selectedVillage = villages.FirstOrDefault(v => v.Id == selectedVillageId);
            
            // Ahır kuyruğunu parse et
            var stableQueue = new List<TWA.Core.DTOs.RecruitmentQueueItem>();
            if (selectedVillage != null && !string.IsNullOrEmpty(selectedVillage.StableQueueJson))
            {
                try
                {
                    stableQueue = System.Text.Json.JsonSerializer.Deserialize<List<TWA.Core.DTOs.RecruitmentQueueItem>>(selectedVillage.StableQueueJson) ?? new List<TWA.Core.DTOs.RecruitmentQueueItem>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Stable queue parse error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"StableQueueJson is null or empty for village {selectedVillageId}");
            }
            
            var model = new RecruitmentViewModel
            {
                Villages = villages,
                SelectedVillageId = selectedVillageId,
                SelectedVillage = selectedVillage,
                BuildingLevel = selectedVillage?.BuildingStable ?? 0,
                Queue = stableQueue
            };
            
            return View(model);
        }

        // Atölye - Kuşatma Silahları
        public async Task<IActionResult> Garage(int? villageId)
        {
            var villages = (await _unitOfWork.Repository<Village>().GetAllAsync()).ToList();
            
            var selectedVillageId = villageId ?? villages.FirstOrDefault()?.Id ?? 0;
            var selectedVillage = villages.FirstOrDefault(v => v.Id == selectedVillageId);
            
            // Atölye kuyruğunu parse et
            var garageQueue = new List<TWA.Core.DTOs.RecruitmentQueueItem>();
            if (selectedVillage != null && !string.IsNullOrEmpty(selectedVillage.GarageQueueJson))
            {
                try
                {
                    garageQueue = System.Text.Json.JsonSerializer.Deserialize<List<TWA.Core.DTOs.RecruitmentQueueItem>>(selectedVillage.GarageQueueJson) ?? new List<TWA.Core.DTOs.RecruitmentQueueItem>();
                }
                catch { }
            }
            
            var model = new RecruitmentViewModel
            {
                Villages = villages,
                SelectedVillageId = selectedVillageId,
                SelectedVillage = selectedVillage,
                BuildingLevel = selectedVillage?.BuildingGarage ?? 0,
                Queue = garageQueue
            };
            
            return View(model);
        }

        // Akademi - Misyoner Basma
        public async Task<IActionResult> Snob(int? villageId)
        {
            var villages = (await _unitOfWork.Repository<Village>().GetAllAsync()).ToList();
            
            var selectedVillageId = villageId ?? villages.FirstOrDefault()?.Id ?? 0;
            var selectedVillage = villages.FirstOrDefault(v => v.Id == selectedVillageId);
            
            // Akademi kuyruğunu parse et
            var snobQueue = new List<TWA.Core.DTOs.RecruitmentQueueItem>();
            if (selectedVillage != null && !string.IsNullOrEmpty(selectedVillage.SnobQueueJson))
            {
                try
                {
                    snobQueue = System.Text.Json.JsonSerializer.Deserialize<List<TWA.Core.DTOs.RecruitmentQueueItem>>(selectedVillage.SnobQueueJson) ?? new List<TWA.Core.DTOs.RecruitmentQueueItem>();
                }
                catch { }
            }
            
            var model = new RecruitmentViewModel
            {
                Villages = villages,
                SelectedVillageId = selectedVillageId,
                SelectedVillage = selectedVillage,
                BuildingLevel = selectedVillage?.BuildingSnob ?? 0,
                Queue = snobQueue
            };
            
            return View(model);
        }

        // Asker Basma İşlemi
        [HttpPost]
        public async Task<IActionResult> Train(RecruitmentViewModel model)
        {
            // TODO: Implement actual recruitment logic
            // Bu kısım GameBrowserService ile entegre edilecek
            
            TempData["Success"] = $"{model.UnitCount} adet {model.UnitType} basma emri verildi!";
            
            return RedirectToAction(model.BuildingType, new { villageId = model.SelectedVillageId });
        }

        // Toplu Asker Basma
        public IActionResult MassRecruit()
        {
            // Statik veri yok - sadece canlı SignalR verisi
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MassRecruit(MassRecruitmentViewModel model)
        {
            // TODO: Implement mass recruitment logic
            
            TempData["Success"] = $"{model.SelectedVillageIds.Count} köyde toplu asker basma başlatıldı!";
            
            return RedirectToAction("MassRecruit");
        }
    }
}
