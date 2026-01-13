using System;
using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class DeceptionService
    {
        private readonly IWarfareService _warfare;

        public DeceptionService(IWarfareService warfare)
        {
            _warfare = warfare;
        }

        // HAYALET TREN (GHOST TRAIN)
        // 1 Gerçek Misyoner yerine, 4 tane peş peşe fake saldırı atar.
        public async Task LaunchGhostTrainAsync(int sourceId, int targetX, int targetY)
        {
            // 4 Vagonlu Fake Treni
            for (int i = 0; i < 4; i++)
            {
                var fakeTroops = new TroopSet { Ram = 1, Spy = 1 }; // Şahmerdan hızı
                
                // Arka planda ateşle (Task.Run) ki birbirini beklemesin, seri olsun
                // Not: WarfareService.SendAttackAsync zaten Task dönüyor ve içinde delay var ancak
                // burada "Fire and Forget" mantığıyla çağırılıyor gibi.
                // Dikkat: Task.Run içinde exception yutulabilir, loglama gerekebilir.
                // User isteği: "_ = _warfare..."
                
                _ = Task.Run(async () => 
                {
                    try {
                        await _warfare.SendAttackAsync(new AttackCommand
                        {
                            SourceVillageId = sourceId,
                            TargetX = targetX,
                            TargetY = targetY,
                            Troops = fakeTroops,
                            Type = AttackType.Fake,
                            // İlk saldırı hemen, diğerleri 150ms, 300ms, 450ms gecikmeyle (GAP)
                            LaunchTime = DateTime.UtcNow.AddMilliseconds(i * 150) 
                        });
                    } catch (Exception ex) {
                        Console.WriteLine($"Ghost Train Error (Car {i}): {ex.Message}");
                    }
                });
                
                // Loop'un çok hızlı dönmesini engellemek için minik bir bekleme
                await Task.Delay(50); 
            }
            Console.WriteLine("👻 HAYALET TREN YOLA ÇIKTI! Düşman panikte.");
        }
    }
}
