using TWA.Core.Entities;

namespace TWA.Core.Interfaces.Services
{
    public interface IWarfareService
    {
        // Hedefe istenen saatte varmak için ne zaman çıkmalıyım?
        DateTime CalculateLaunchTime(Village source, int targetX, int targetY, TroopSet troops, DateTime targetArrivalTime);
        
        // Bu orduyla oraya gitmek ne kadar sürer?
        TimeSpan GetDuration(Village source, int targetX, int targetY, TroopSet troops);
        
        // Saldırı emrini veritabanına işler
        Task ScheduleAttackAsync(AttackTask task);

        // Tarayıcı üzerinden fiziksel saldırıyı başlatır (Ghost Engine için)
        Task SendAttackAsync(AttackCommand cmd);

        // Kaynak gönderimi yapar
        Task SendResourcesAsync(TransportCommand cmd);
        
        // Son operasyonları getir
        Task<IEnumerable<AttackTask>> GetRecentOperationsAsync(int count);
    }
}
