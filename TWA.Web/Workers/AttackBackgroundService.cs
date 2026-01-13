using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;
using TWA.Core.Helpers;

namespace TWA.Web.Workers
{
    public class AttackBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<AttackBackgroundService> _logger;

        public AttackBackgroundService(IServiceProvider serviceProvider, ILogger<AttackBackgroundService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("⚔️ TWA Savaş Motoru Başlatıldı.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Scope oluştur (Çünkü UnitOfWork Scoped, bu servis Singleton)
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var security = scope.ServiceProvider.GetRequiredService<ISecurityService>(); // GÜVENLİK SERVİSİ
                        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                        var repo = unitOfWork.Repository<AttackTask>();

                        // 1. GÜVENLİK KONTROLÜ: Uyuyor muyuz?
                        if (!security.CanOperateNow())
                        {
                            // Uyuyorsak döngüyü yavaşlat (10 saniyede bir kontrol et)
                            _logger.LogDebug("Zzz... (Bot Uyku Modunda)");
                            await Task.Delay(10000, stoppingToken);
                            continue;
                        }

                        // Zamanı gelen ve henüz gönderilmemiş saldırıları bul
                        // 2 saniye önceden hazırlanması için buffer koyuyoruz
                        var pendingAttacks = await repo.FindAsync(a => 
                            a.Status == AttackStatus.Scheduled && 
                            a.LaunchTime <= DateTime.UtcNow.AddSeconds(2));

                        foreach (var attack in pendingAttacks)
                        {
                            // Kalan süre (Milisaniye)
                            var timeToLaunch = attack.LaunchTime - DateTime.UtcNow;

                            if (timeToLaunch.TotalMilliseconds <= 0)
                            {
                                // VAKİT GELDİ! SALDIR!
                                await ExecuteAttackCommand(attack);
                                
                                attack.Status = AttackStatus.Sent;
                                attack.UpdatedDate = DateTime.UtcNow;
                                unitOfWork.Repository<AttackTask>().Update(attack);
                            }
                            else if (timeToLaunch.TotalMilliseconds < 2000) // 2 saniye kala
                            {
                                // Tam vuruş anında "Beceriksizlik" (Hata) şansını uygula
                                if (timeToLaunch.TotalMilliseconds < 500)
                                {
                                    // Eğer hata zarı gelirse, Thread'i biraz uyuturuz
                                    if (RandomProvider.RollDice(5)) // %5 Hata
                                    {
                                        int mistake = RandomProvider.Next(50, 300);
                                        _logger.LogWarning($"⚠️ TWA 'Şişman Parmak' Hatası Yaptı! ({mistake}ms gecikme)");
                                        await Task.Delay(mistake, stoppingToken); 
                                    }
                                    else
                                    {
                                         // Normal bekleme (Çok az kaldı, bekle ve vur)
                                         await Task.Delay((int)timeToLaunch.TotalMilliseconds, stoppingToken);
                                    }
                                }

                                await ExecuteAttackCommand(attack);
                                
                                attack.Status = AttackStatus.Sent;
                                attack.UpdatedDate = DateTime.UtcNow;
                                unitOfWork.Repository<AttackTask>().Update(attack);
                            }
                        }
                        
                        // Değişiklikleri kaydet
                        if (pendingAttacks.Any())
                        {
                            await unitOfWork.CommitAsync();
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Savaş motorunda hata oluştu!");
                }

                // Döngü hızı (Refleks gecikmesi ekle)
                // Sabit 100ms yerine değişken bir hızda kontrol et (80-150ms)
                await Task.Delay(RandomProvider.Next(80, 150), stoppingToken);
            }
        }

        private async Task ExecuteAttackCommand(AttackTask attack)
        {
            // BURASI KRİTİK NOKTA
            // Gerçek bir botta burada Selenium/Puppeteer tetiklenir.
            // Bizim simülasyonumuzda Log basıyoruz.
            
            _logger.LogWarning($"🚀 SALDIRI ÇIKTI! Hedef: {attack.TargetX}|{attack.TargetY} - Tür: {attack.Type}");
            
            // İLERİDE: Burada "Groq, saldırı butonuna bas!" sinyali gönderilecek.
            await Task.CompletedTask;
        }
    }
}
