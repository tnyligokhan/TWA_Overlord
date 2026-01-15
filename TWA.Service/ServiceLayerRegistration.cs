using Microsoft.Extensions.DependencyInjection;
using TWA.Core.Interfaces.Services;
using TWA.Service.Services;

namespace TWA.Service
{
    public static class ServiceLayerRegistration
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            // Servisleri DI Container'a ekle
            services.AddScoped<IVillageService, VillageService>();
            
            // Grok AI Servisi (xAI Grok-2)
            services.AddHttpClient<IGrokAiService, GrokAiService>();

            services.AddScoped<IWarfareService, WarfareService>(); // EKLENDİ
            services.AddScoped<IEconomyService, EconomyService>();
            services.AddScoped<IMapScannerService, MapScannerService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IEmergencyService, EmergencyService>();
            services.AddScoped<IWhatsAppService, WhatsAppService>();
            services.AddSingleton<IGameBrowserService, GameBrowserService>();

            // Connectivity Services
            services.AddSingleton<ITelegramService, TelegramService>();
            services.AddSingleton<ISignalRService, SignalRService>();
            services.AddSingleton<IHtmlParsingService, HtmlParsingService>();

            // Ghost Engine (Background Service)
            services.AddHostedService<GhostEngineService>();

            // Planner Services
            services.AddScoped<ITimelinePlannerService, TimelinePlannerService>();

            // Managers
            services.AddScoped<Managers.TroopManager>();
            services.AddScoped<Managers.BuildingManager>();
            
            // Village Data Sync
            services.AddScoped<VillageDataSyncService>();
            
            // Execution Service
            services.AddScoped<ITaskExecutionService, TaskExecutionService>();
            
            // Parsers
            services.AddScoped<ReportParserService>();

            // Warfare
            services.AddSingleton<HumanErrorService>();
            services.AddScoped<IWarfareService, WarfareService>();
            services.AddScoped<DeceptionService>();
            services.AddScoped<OpCoordinatorService>();
            services.AddScoped<LogisticsService>();
            services.AddScoped<MintingService>();
            
            // Recruitment Queue Service
            services.AddScoped<IRecruitmentQueueService, RecruitmentQueueService>();
            
            // Build Queue Service
            services.AddScoped<IBuildQueueService, BuildQueueService>();

            return services;
        }
    }
}
