using TWA.Core.DTOs;

namespace TWA.Core.Interfaces.Services
{
    public interface IMapScannerService
    {
        // Ham JSON verisini işleyip veritabanına Barbarları kaydeder
        Task ScanAndSaveBarbariansAsync(List<MapSectorDto> sectors);
        
        // Belirli bir koordinatın etrafındaki barbarları bulur (Saldırı için)
        Task<IEnumerable<Core.Entities.Village>> FindTargetsNearAsync(int centerX, int centerY, int radius, int minPoints, int maxPoints);
    }
}
