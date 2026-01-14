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
            
            // Groq Servisi için HttpClient ekliyoruz
            services.AddHttpClient<IGroqAiService, GroqAiService>();

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
            services.AddScoped<IHtmlParsingService, HtmlParsingService>();

            // Ghost Engine (Background Service)
            services.AddHostedService<GhostEngineService>();

            // Planner Services
            services.AddScoped<ITimelinePlannerService, TimelinePlannerService>();

            // Managers
            services.AddScoped<Managers.TroopManager>();
            // Managers
            services.AddScoped<Managers.TroopManager>();
            services.AddScoped<Managers.BuildingManager>();
            
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

            return services;
        }
    }
}
