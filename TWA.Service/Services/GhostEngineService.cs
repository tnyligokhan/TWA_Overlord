using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class GhostEngineService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<GhostEngineService> _logger;

        public GhostEngineService(IServiceScopeFactory scopeFactory, ILogger<GhostEngineService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("👻 GHOST ENGINE BAŞLATILDI. Gölge Protokolü Devrede.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                        var opRepo = uow.Repository<ScheduledOperation>();
                        var browser = scope.ServiceProvider.GetRequiredService<IGameBrowserService>();
                        var taskExecutor = scope.ServiceProvider.GetService<ITaskExecutionService>(); 

                        // 1. SIRADAKİ İŞİ BUL
                        // Varsayım: GetAllAsync() IQueryable veya List dönüyor.
                        // IRepository'de GetAllAsync var.
                        var ops = await opRepo.GetAllAsync(); 
                        var nextOp = ops.Where(x => !x.IsCompleted && x.ScheduledTime <= DateTime.UtcNow)
                            .OrderBy(x => x.ScheduledTime)
                            .FirstOrDefault();

                        if (nextOp != null && taskExecutor != null)
                        {
                            _logger.LogInformation($"🔔 UYANIŞ! Görev: {nextOp.Type} | Köy: {nextOp.VillageId}");

                            // A) GİZLİ GİRİŞ YAP
                            bool loggedIn = await browser.LoginAsync();
                            
                            if (loggedIn)
                            {
                                // B) GÖREVİ İCRA ET
                                await taskExecutor.ExecuteOperationAsync(nextOp);

                                // C) GÖREVİ TAMAMLANDI İŞARETLE
                                nextOp.IsCompleted = true;
                                nextOp.ExecutionLog = $"Tamamlandı: {DateTime.UtcNow}";
                                
                                // Update
                                opRepo.Update(nextOp);
                                await uow.CommitAsync();

                                // D) ACİL DURUM KONTROLÜ (Girmişken bak)
                                await CheckIncomingAttacks(browser, scope);
                            }

                            // E) İZ BIRAKMADAN ÇIK (Session Temizliği)
                            await browser.CloseAsync();
                            
                            // İnsan Taklidi: İşlem sonrası rastgele kısa bir bekleme
                            await Task.Delay(TimeSpan.FromSeconds(Random.Shared.Next(10, 30)), stoppingToken);
                        }
                        else
                        {
                            // Yapılacak iş yoksa işlemciyi yorma, 10 saniye bekle
                            await Task.Delay(10000, stoppingToken);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Ghost Engine Hatası: {ex.Message}");
                    await Task.Delay(30000, stoppingToken); // Hata varsa 30sn soğuma
                }
            }
        }

        private async Task CheckIncomingAttacks(IGameBrowserService browser, IServiceScope scope)
        {
            // Gelen saldırı var mı diye hızlıca bak
            bool attackDetected = await browser.CheckIncomingAttacksAsync();
            if (attackDetected)
            {
                var telegram = scope.ServiceProvider.GetRequiredService<ITelegramService>();
                await telegram.SendMessageAsync("🚨 DİKKAT! GHOST MODUNDA SALDIRI TESPİT EDİLDİ!");
                // Buraya "Dodge" planlaması eklenecek
            }
        }
    }
}
