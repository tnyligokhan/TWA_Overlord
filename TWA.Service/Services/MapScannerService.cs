using System.Text.Json; // veya Newtonsoft.Json
using TWA.Core.DTOs;
using TWA.Core.Entities;
using TWA.Core.Helpers;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class MapScannerService : IMapScannerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MapScannerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ScanAndSaveBarbariansAsync(List<MapSectorDto> sectors)
        {
            var villageRepo = _unitOfWork.Repository<Village>();
            int newVillagesCount = 0;

            foreach (var sector in sectors)
            {
                if (sector.Data?.Villages == null) continue;

                foreach (var villageGroup in sector.Data.Villages)
                {
                    foreach (var kvp in villageGroup)
                    {
                        // JSON Array içindeki indeksler (Oyunun yapısına göre):
                        // 0: ID, 1: X, 2: Y, 3: İsim, 4: Puan, 5: Sahip ID ("0" ise Barbar)
                        var rawData = kvp.Value;
                        
                        // Parse village data
                        int gameId = int.Parse(rawData[0]?.ToString() ?? "0");
                        int villageX = int.Parse(rawData[1]?.ToString() ?? "0");
                        int villageY = int.Parse(rawData[2]?.ToString() ?? "0");
                        string villageName = rawData[3]?.ToString() ?? "Unknown";
                        int points = int.Parse(rawData[4]?.ToString()?.Replace(".", "") ?? "0");
                        string? ownerId = rawData[5]?.ToString();
                        
                        // Sadece Barbarları (Sahibi "0" olanları) alıyoruz
                        if (ownerId == "0") 
                        {
                            // Veritabanında var mı? GameId veya Koordinat ile kontrol
                            var existing = (await villageRepo.FindAsync(v => 
                                v.GameId == gameId || 
                                (v.CoordinateX == villageX && v.CoordinateY == villageY)
                            )).FirstOrDefault();
                            
                            if (existing == null)
                            {
                                // Yeni Barbar Ekle
                                var barbarian = new Village
                                {
                                    GameId = gameId,
                                    Name = villageName,
                                    Points = points,
                                    Type = VillageType.Barbarian,
                                    CoordinateX = villageX, 
                                    CoordinateY = villageY 
                                };
                                await villageRepo.AddAsync(barbarian);
                                newVillagesCount++;
                            }
                            else
                            {
                                // Puanı ve diğer bilgileri güncelle
                                existing.Points = points;
                                existing.Name = villageName;
                                existing.UpdatedDate = DateTime.UtcNow;
                                villageRepo.Update(existing);
                            }
                        }
                    }
                }
            }

            if (newVillagesCount > 0)
            {
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<IEnumerable<Village>> FindTargetsNearAsync(int centerX, int centerY, int radius, int minPoints, int maxPoints)
        {
            var allBarbarians = await _unitOfWork.Repository<Village>().FindAsync(v => v.Type == VillageType.Barbarian);
            
            // Veritabanından çekip bellekte filtreliyoruz (Performans için önce SQL'de kare filtrelemesi yapılabilir)
            return allBarbarians.Where(v => 
                v.Points >= minPoints && 
                v.Points <= maxPoints &&
                GameMath.CalculateDistance(centerX, centerY, v.CoordinateX, v.CoordinateY) <= radius
            ).OrderByDescending(v => v.Points); // En büyükler önce
        }
    }
}
