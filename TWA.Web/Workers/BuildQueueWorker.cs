using TWA.Service.Services;

namespace TWA.Web.Workers
{
    public class BuildQueueWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<BuildQueueWorker> _logger;

        public BuildQueueWorker(IServiceProvider serviceProvider, ILogger<BuildQueueWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("🏗️ İnşaat Kuyruğu Servisi Başlatıldı.");

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _serviceProvider.CreateScope();
                    var queueService = scope.ServiceProvider.GetRequiredService<IBuildQueueService>();

                    await queueService.ProcessQueuesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"❌ İnşaat kuyruğu işleme hatası: {ex.Message}");
                }

                // Her 30 saniyede bir kontrol et
                await Task.Delay(30000, stoppingToken);
            }
        }
    }
}
