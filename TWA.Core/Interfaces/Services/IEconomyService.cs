using TWA.Core.Entities;

namespace TWA.Core.Interfaces.Services
{
    public interface IEconomyService
    {
        // Yatırımın Geri Dönüş Süresi (Saat)
        double CalculateROI(Village village, string resourceType, int nextLevel);
        
        // Akıllı İnşaat Önerisi Oluştur
        Task AnalyzeAndPlanBuildsAsync(int villageId);
    }
}
