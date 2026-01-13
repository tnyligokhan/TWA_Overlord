using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Helpers;
using TWA.Core.Interfaces;

namespace TWA.Service.Services
{
    public class OpCoordinatorService
    {
        private readonly IRepository<ScheduledOperation> _opRepo;

        public OpCoordinatorService(IRepository<ScheduledOperation> opRepo)
        {
            _opRepo = opRepo;
        }

        // HEDEF ZAMAN: Yarın sabah 08:00:00
        public async Task PlanOperation(int targetX, int targetY, DateTime impactTime, List<Village> myVillages)
        {
            foreach (var village in myVillages)
            {
                // 1. Mesafeyi Hesapla
                // GameMath yoksa manuel hesaplayabiliriz ama var olduğu detected edildi.
                double distance = GameMath.CalculateDistance(village.CoordinateX, village.CoordinateY, targetX, targetY);
                
                // 2. En yavaş birimi bul (Şahmerdan veya Balta)
                // Bu örnekte Şahmerdan (Ram) hızını alıyoruz: 30 dk/birim (Dünya hızına göre değişir)
                double travelMinutes = distance * 30; 
                TimeSpan travelTime = TimeSpan.FromMinutes(travelMinutes);
                
                // 3. Çıkış Saatini Bul (Launch Time)
                // Vuruş Zamanı - Yol Süresi = Çıkış Zamanı
                DateTime launchTime = impactTime.Subtract(travelTime);

                // Eğer çıkış saati geçmişte değilse görevi planla
                if (launchTime > DateTime.UtcNow)
                {
                    // ScheduledOperation tablosuna kaydet
                    // GhostEngine zamanı gelince bunu ateşleyecek
                    var op = new ScheduledOperation
                    {
                        VillageId = village.Id,
                        Type = OpType.SnipeAttack, // Zamanlı Saldırı / Snipe
                        ScheduledTime = launchTime,
                        Payload = System.Text.Json.JsonSerializer.Serialize(new AttackCommand 
                        {
                            SourceVillageId = village.Id,
                            TargetX = targetX, 
                            TargetY = targetY,
                            Troops = new TroopSet { Ram = 100, Axe = 5000 }, // Full Kami
                            Type = AttackType.Real_Nuke,
                            LaunchTime = launchTime
                        })
                    };
                    
                    await _opRepo.AddAsync(op);
                    Console.WriteLine($"⚔️ OP PLANLANDI: {village.Name} köyünden çıkış: {launchTime}");
                }
            }
        }
    }
}
