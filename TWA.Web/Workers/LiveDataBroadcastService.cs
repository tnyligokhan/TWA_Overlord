using Microsoft.AspNetCore.SignalR;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Web.Hubs;

namespace TWA.Web.Workers
{
    public class LiveDataBroadcastService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<LiveDataBroadcastService> _logger;
        private readonly IHubContext<GameDataHub> _hubContext;
        private DateTime _lastVillageUpdate = DateTime.MinValue;
        private DateTime _lastBuildingUpdate = DateTime.MinValue;
        private DateTime _lastAttackUpdate = DateTime.MinValue;

        public LiveDataBroadcastService(
            IServiceProvider serviceProvider, 
            ILogger<LiveDataBroadcastService> logger,
            IHubContext<GameDataHub> hubContext)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("📡 Canlı Veri Yayın Servisi Başlatıldı.");
            await _hubContext.Clients.All.SendAsync("SystemLogReceived", new 
            { 
                timestamp = DateTime.Now.ToString("HH:mm:ss"),
                level = "INFO",
                message = "Canlı Veri Yayın Servisi Başlatıldı (Optimize Mod)" 
            });

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                        // Veritabanı boş mu kontrol et
                        var villageCount = await unitOfWork.Repository<Village>().CountAsync();
                        if (villageCount == 0)
                        {
                            // İlk çalıştırmada veritabanı boş, sadece bekle
                            await Task.Delay(10000, stoppingToken);
                            continue;
                        }

                        // 1. KÖYLER - Sadece 30 saniyede bir güncelle
                        if ((DateTime.UtcNow - _lastVillageUpdate).TotalSeconds > 30)
                        {
                            await BroadcastVillageUpdates(unitOfWork);
                            _lastVillageUpdate = DateTime.UtcNow;
                        }

                        // 2. İNŞAAT - Sadece aktif inşaat varsa ve 5 saniyede bir
                        if ((DateTime.UtcNow - _lastBuildingUpdate).TotalSeconds > 5)
                        {
                            await BroadcastBuildingProgress(unitOfWork);
                            _lastBuildingUpdate = DateTime.UtcNow;
                        }

                        // 3. SAVAŞ - Sadece aktif saldırı varsa ve 10 saniyede bir
                        if ((DateTime.UtcNow - _lastAttackUpdate).TotalSeconds > 10)
                        {
                            await BroadcastAttackStatus(unitOfWork);
                            _lastAttackUpdate = DateTime.UtcNow;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Canlı veri yayınında hata oluştu!");
                    await _hubContext.Clients.All.SendAsync("SystemLogReceived", new 
                    { 
                        timestamp = DateTime.Now.ToString("HH:mm:ss"),
                        level = "ERROR",
                        message = $"Veri yayın hatası: {ex.Message}" 
                    });
                }

                // Her 5 saniyede bir kontrol et (daha az sıklık)
                await Task.Delay(5000, stoppingToken);
            }
        }

        private async Task BroadcastVillageUpdates(IUnitOfWork unitOfWork)
        {
            // Sadece son 30 saniyede güncellenen köyleri çek
            var recentlyUpdated = await unitOfWork.Repository<Village>()
                .FindAsync(v => v.UpdatedDate >= DateTime.UtcNow.AddSeconds(-35));
            
            if (!recentlyUpdated.Any())
            {
                // Hiç güncelleme yoksa atla
                return;
            }

            foreach (var village in recentlyUpdated)
            {
                // OwnedTroops null kontrolü
                if (village.OwnedTroops == null)
                {
                    village.OwnedTroops = new TroopSet();
                }

                await _hubContext.Clients.All.SendAsync("ResourcesUpdated", new
                {
                    villageId = village.Id,
                    wood = village.Wood,
                    stone = village.Stone,
                    iron = village.Iron,
                    popCurrent = village.PopulationCurrent,
                    popMax = village.PopulationMax,
                    storageCapacity = village.StorageCapacity
                });

                // Asker güncellemeleri
                await _hubContext.Clients.All.SendAsync("TroopsUpdated", new
                {
                    villageId = village.Id,
                    troops = new
                    {
                        spear = village.OwnedTroops.Spear,
                        sword = village.OwnedTroops.Sword,
                        axe = village.OwnedTroops.Axe,
                        light = village.OwnedTroops.Light,
                        heavy = village.OwnedTroops.Heavy,
                        ram = village.OwnedTroops.Ram,
                        catapult = village.OwnedTroops.Catapult,
                        snob = village.OwnedTroops.Snob
                    }
                });

                // 🏗️ BİNA SEVİYELERİ GÜNCELLEMESİ
                await _hubContext.Clients.All.SendAsync("BuildingLevelsUpdated", new
                {
                    villageId = village.Id,
                    buildings = new
                    {
                        main = village.BuildingMain,
                        barracks = village.BuildingBarracks,
                        stable = village.BuildingStable,
                        garage = village.BuildingGarage,
                        snob = village.BuildingSnob,
                        smith = village.BuildingSmithy,
                        wood = village.BuildingWood,
                        stone = village.BuildingStone,
                        iron = village.BuildingIron,
                        farm = village.BuildingFarm,
                        storage = village.BuildingStorage,
                        wall = village.BuildingWall
                    }
                });
            }

            // Log gönder
            _logger.LogInformation($"📊 {recentlyUpdated.Count()} köy verisi yayınlandı");
        }

        private async Task BroadcastBuildingProgress(IUnitOfWork unitOfWork)
        {
            var activeBuilds = await unitOfWork.Repository<BuildingPlan>()
                .FindAsync(b => b.IsActive && b.EndTime.HasValue);

            if (!activeBuilds.Any())
            {
                return; // Aktif inşaat yoksa atla
            }

            foreach (var build in activeBuilds)
            {
                if (build.EndTime.HasValue && build.StartTime.HasValue)
                {
                    var total = (build.EndTime.Value - build.StartTime.Value).TotalSeconds;
                    var elapsed = (DateTime.UtcNow - build.StartTime.Value).TotalSeconds;
                    var progress = Math.Min(100, (int)((elapsed / total) * 100));

                    await _hubContext.Clients.All.SendAsync("BuildingProgressUpdated", new
                    {
                        buildId = build.Id,
                        villageId = build.VillageId,
                        buildingName = build.BuildingName,
                        progress = progress,
                        remaining = build.EndTime.Value - DateTime.UtcNow
                    });
                }
            }
        }

        private async Task BroadcastAttackStatus(IUnitOfWork unitOfWork)
        {
            var activeAttacks = await unitOfWork.Repository<AttackTask>()
                .FindAsync(a => a.Status == AttackStatus.Scheduled || a.Status == AttackStatus.Sent);

            if (!activeAttacks.Any())
            {
                return; // Aktif saldırı yoksa atla
            }

            foreach (var attack in activeAttacks)
            {
                await _hubContext.Clients.All.SendAsync("AttackStatusUpdated", new
                {
                    attackId = attack.Id,
                    status = attack.Status.ToString(),
                    launchTime = attack.LaunchTime,
                    arrivalTime = attack.ArrivalTime,
                    targetX = attack.TargetX,
                    targetY = attack.TargetY
                });
            }
        }
    }
}
