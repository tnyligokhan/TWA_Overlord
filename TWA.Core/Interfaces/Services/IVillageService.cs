using TWA.Core.DTOs;
using TWA.Core.Entities;

namespace TWA.Core.Interfaces.Services
{
    public interface IVillageService
    {
        Task SyncVillageDataAsync(VillageSyncDto data);
        Task<IEnumerable<Village>> GetVillagesNeedResourcesAsync(); // Deposu boşalanlar
        Task<IEnumerable<Village>> GetVillagesWithFullStorageAsync(); // Deposu taşanlar
        // HTML Parse ve Senkronizasyon
        Task ParseAndSyncAsync(string htmlContent);
        Task<IEnumerable<Village>> GetAllVillagesAsync();
    }
}
