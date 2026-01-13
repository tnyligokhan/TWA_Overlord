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
                        // 0: ID, 2: İsim, 3: Puan, 4: Sahip ID ("0" ise Barbar)
                        var rawData = kvp.Value;
                        string? ownerId = rawData[4]?.ToString();
                        
                        // Sadece Barbarları (Sahibi "0" olanları) alıyoruz
                        if (ownerId == "0") 
                        {
                            int gameId = int.Parse(rawData[0]?.ToString() ?? "0");
                            int points = int.Parse(rawData[3]?.ToString()?.Replace(".", "") ?? "0");
                            
                            // Harita içi bağıl konumdan gerçek koordinatı hesapla
                            // Bu kısım oyunun JS mantığına göre biraz karmaşıktır, 
                            // şimdilik basit bir X/Y varsayımı yapıyoruz veya direkt kaydediyoruz.
                            // Gerçek botta: Sector X/Y + Local Offset hesabı yapılır.
                            
                            // Veritabanında var mı?
                            var existing = (await villageRepo.FindAsync(v => v.GameId == gameId)).FirstOrDefault();
                            
                            if (existing == null)
                            {
                                // Yeni Barbar Ekle
                                var barbarian = new Village
                                {
                                    GameId = gameId,
                                    Name = rawData[2].ToString(),
                                    Points = points,
                                    Type = VillageType.Barbarian,
                                    // Koordinatları hesaplamamız lazım ama şimdilik placeholder
                                    CoordinateX = sector.Data.X, 
                                    CoordinateY = sector.Data.Y 
                                };
                                await villageRepo.AddAsync(barbarian);
                                newVillagesCount++;
                            }
                            else
                            {
                                // Puanı güncelle (Barbarlar gelişir)
                                existing.Points = points;
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
