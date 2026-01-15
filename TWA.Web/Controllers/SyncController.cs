using Microsoft.AspNetCore.Mvc;
using TWA.Service.Services;

namespace TWA.Web.Controllers
{
    public class SyncController : Controller
    {
        private readonly VillageDataSyncService _syncService;

        public SyncController(VillageDataSyncService syncService)
        {
            _syncService = syncService;
        }

        [HttpPost]
        public async Task<IActionResult> SyncVillage(int villageId)
        {
            try
            {
                await _syncService.SyncAllVillageDataAsync(villageId);
                return Json(new { success = true, message = "Köy verileri senkronize edildi" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }
    }
}
