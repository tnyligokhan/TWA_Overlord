using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class TimelinePlannerService : ITimelinePlannerService
    {
        private readonly IRepository<ScheduledOperation> _opRepo;
        private readonly Random _rnd = new Random();

        public TimelinePlannerService(IRepository<ScheduledOperation> opRepo)
        {
            _opRepo = opRepo;
        }

        public async Task DistributeTasksForDayAsync(int villageId, List<DailyTask> tasks)
        {
            var now = DateTime.UtcNow;
            
            // Aktif Saatler: Sabah 08:00 - Gece 01:00 arası
            // Eğer şu an saat 14:00 ise, kalan görevleri 14:00 - 01:00 arasına yay.
            
            DateTime shiftStart = now.Hour < 8 ? now.Date.AddHours(8) : now.AddMinutes(10);
            DateTime shiftEnd = now.Date.AddDays(1).AddHours(1); // Ertesi gün 01:00

            int totalMinutes = (int)(shiftEnd - shiftStart).TotalMinutes;
            if (totalMinutes <= 0) totalMinutes = 60; // Güvenlik

            foreach (var task in tasks)
            {
                // Rastgele bir zaman dilimi seç
                int offset = _rnd.Next(0, totalMinutes);
                DateTime plannedTime = shiftStart.AddMinutes(offset);

                // "Lag" ve "Human Jitter" ekle (± 5 dakika oynama)
                plannedTime = plannedTime.AddSeconds(_rnd.Next(-300, 300));

                var op = new ScheduledOperation
                {
                    VillageId = villageId,
                    Type = OpType.DailyTask,
                    ScheduledTime = plannedTime,
                    Payload = System.Text.Json.JsonSerializer.Serialize(task), // Görev detayını sakla
                    IsEmergency = false
                };

                await _opRepo.AddAsync(op);
            }

            // PERİYODİK KONTROL GÖREVLERİ (Günde 4-5 kez girip çıkma)
            for (int i = 0; i < 5; i++)
            {
                int checkOffset = _rnd.Next(0, totalMinutes);
                var checkOp = new ScheduledOperation
                {
                    VillageId = villageId,
                    Type = OpType.PeriodicCheck,
                    ScheduledTime = shiftStart.AddMinutes(checkOffset),
                    IsEmergency = false,
                    Payload = "{}" // Missing Payload fix
                };
                await _opRepo.AddAsync(checkOp);
            }
        }
    }
}
