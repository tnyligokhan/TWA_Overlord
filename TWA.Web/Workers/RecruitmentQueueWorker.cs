using TWA.Service.Services;

namespace TWA.Web.Workers
{
    public class RecruitmentQueueWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<RecruitmentQueueWorker> _logger;

        public RecruitmentQueueWorker(IServiceProvider serviceProvider, ILogger<RecruitmentQueueWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("🏭 Askeri Üretim Kuyruğu Servisi Başlatıldı.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var queueService = scope.ServiceProvider.GetRequiredService<IRecruitmentQueueService>();

                    await queueService.ProcessQueuesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"❌ Kuyruk işleme hatası: {ex.Message}");
                }

                // Her 30 saniyede bir kontrol et
                await Task.Delay(30000, stoppingToken);
            }
        }
    }
}
