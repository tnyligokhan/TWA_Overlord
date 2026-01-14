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

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

                        // 1. KÖYLER - Kaynak ve Nüfus Güncellemeleri
                        await BroadcastVillageUpdates(unitOfWork);

                        // 2. İNŞAAT - Bina İlerleme Güncellemeleri
                        await BroadcastBuildingProgress(unitOfWork);

                        // 3. SAVAŞ - Saldırı Durumu Güncellemeleri
                        await BroadcastAttackStatus(unitOfWork);

                        // 4. EKONOMİ - Toplam Kaynak Güncellemeleri
                        await BroadcastEconomyData(unitOfWork);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Canlı veri yayınında hata oluştu!");
                }

                // Her 2 saniyede bir güncelle (Performans dengesi)
                await Task.Delay(2000, stoppingToken);
            }
        }

        private async Task BroadcastVillageUpdates(IUnitOfWork unitOfWork)
        {
            var villages = await unitOfWork.Repository<Village>().GetAllAsync();
            
            foreach (var village in villages)
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
            }
        }

        private async Task BroadcastBuildingProgress(IUnitOfWork unitOfWork)
        {
            var activeBuilds = await unitOfWork.Repository<BuildingPlan>()
                .FindAsync(b => b.IsActive && b.EndTime.HasValue);

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

        private async Task BroadcastEconomyData(IUnitOfWork unitOfWork)
        {
            var villages = await unitOfWork.Repository<Village>().GetAllAsync();

            var economyData = new
            {
                totalWood = villages.Sum(v => (long)v.Wood),
                totalStone = villages.Sum(v => (long)v.Stone),
                totalIron = villages.Sum(v => (long)v.Iron),
                totalVillages = villages.Count(),
                avgStorage = villages.Average(v => v.StorageCapacity),
                fullStorageCount = villages.Count(v => 
                    v.Wood > v.StorageCapacity * 0.9 || 
                    v.Stone > v.StorageCapacity * 0.9 || 
                    v.Iron > v.StorageCapacity * 0.9)
            };

            await _hubContext.Clients.All.SendAsync("EconomyUpdated", economyData);
        }
    }
}
