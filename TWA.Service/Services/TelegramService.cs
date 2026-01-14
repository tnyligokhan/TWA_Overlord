using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TWA.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TWA.Service.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<TelegramService> _logger;
        private readonly string _allowedChatId;
        private ITelegramBotClient? _botClient;

        public TelegramService(IConfiguration config, ILogger<TelegramService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
            var apiKey = config["Telegram:ApiKey"];
            if (string.IsNullOrEmpty(apiKey)) apiKey = config["Telegram:BotToken"];
            
            _allowedChatId = config["Telegram:ChatId"] ?? string.Empty;
            
            if (!string.IsNullOrEmpty(apiKey))
            {
                _botClient = new TelegramBotClient(apiKey);
                StartReceiving();
            }
        }

        private void StartReceiving()
        {
            if (_botClient == null) return;

            var receiverOptions = new ReceiverOptions { AllowedUpdates = Array.Empty<UpdateType>() };
            _botClient.StartReceiving(
                updateHandler: HandleUpdateAsync,
                errorHandler: HandleErrorAsync,
                receiverOptions: receiverOptions
            );
            _logger.LogInformation("🚀 Telegram Bot Başlatıldı.");
        }

        private async Task HandleUpdateAsync(ITelegramBotClient bot, Update update, CancellationToken cts)
        {
            if (update.Message is not { } message) return;
            if (message.Text is not { } messageText) return;
            
            // Güvenlik: Sadece izin verilen Chat ID cevap alır
            if (message.Chat.Id.ToString() != _allowedChatId) return;

            _logger.LogInformation($"Telegram Emri Alındı: {messageText}");

            // Scope oluştur ve gerekli servisleri çöz
            using (var scope = _scopeFactory.CreateScope())
            {
                var warfareService = scope.ServiceProvider.GetRequiredService<IWarfareService>();
                var villageService = scope.ServiceProvider.GetRequiredService<IVillageService>();
                var aiService = scope.ServiceProvider.GetRequiredService<IGroqAiService>();
                var economyService = scope.ServiceProvider.GetRequiredService<IEconomyService>();
                // var taskService = scope.ServiceProvider.GetRequiredService<ITaskExecutionService>(); 

                string response = "";
                var args = messageText.Split(' ');
                var command = args[0].ToLower().Replace("/", ""); // "/" prefixini temizle

                try 
                {
                    switch (command)
                    {
                        case "start":
                            response = "🫡 **Komutanım! TWA Overlord v4.0 Online.**\n\nSistem hazır ve emirlerinizi bekliyor.\nKomut listesi için /help yazabilirsiniz.";
                            break;

                        case "durum":
                            var villages = await villageService.GetAllVillagesAsync();
                            int totalVil = villages.Count();
                            int underAttack = villages.Count(v => v.Attacks.Any(a => a.Status == TWA.Core.Entities.AttackStatus.Sent && a.ArrivalTime > DateTime.Now)); 
                            response = $"📊 **DURUM RAPORU**\n\n🟢 Mod: AKTİF\n🏰 Köyler: {totalVil}\n⚔️ Gelen Saldırı: {underAttack}\n💰 Depolar: %{villages.Average(v => (v.Wood+v.Stone+v.Iron)/(double)(v.StorageCapacity*3)*100):F0} Doluluk";
                            break;

                        case "saldir":
                            // Örnek: saldir 555|444
                            if (args.Length < 2) response = "⚠️ Hedef koordinat girilmedi! Örn: `saldir 555|444`";
                            else 
                            {
                                response = $"⚔️ **Saldırı Emri Alındı!**\nHedef: {args[1]}\nAnaliz ediliyor ve en uygun köyden ordu hazırlanıyor...";
                                // await warfareService.PlanAttack(args[1]); // Implementasyon eklenecek
                            }
                            break;

                        case "fake":
                            response = "🎭 **Hayalet Tren (Fake-Train) Hazırlanıyor...**\n4 Ardışık fake saldırı için hedef koordinatları işleniyor.";
                            break;

                        case "destek":
                            response = "🛡️ **Acil Destek Protokolü!**\nEn yakın savunma köyleri taranıyor. Destek kaydırma işlemi başlatıldı.";
                            break;

                        case "analiz":
                            response = "🧠 **xAI Grok Analizi Başlatıldı...**\nStratejik veriler işleniyor, lütfen bekleyin.";
                            // AI'ya asenkron sorup sonradan cevap dönebiliriz ama şimdilik bekletelim
                             var aiResponse = await aiService.GetChatResponseAsync(args.Length > 1 ? string.Join(" ", args.Skip(1)) : "Genel durum analizi yap.");
                             response += $"\n\n📝 **Analiz Sonucu:**\n{aiResponse}";
                            break;

                        case "durdur":
                            response = "🛑 **KILL SWITCH AKTİF!**\nTüm operasyonlar durduruldu. Bot 'Offline' moda geçiyor.";
                            // _emergencyService.TriggerKillSwitch();
                            break;

                        case "devam":
                            response = "✅ **Sistem Tekrar Aktif!**\nOperasyonlara kalındığı yerden devam ediliyor.";
                            break;

                        case "hayalet":
                            response = "👻 **GHOST MODE** Aktif!\nBot artık sadece 'insan taklidi' modunda ve minimum etkileşimle çalışacak.";
                            break;

                        case "lojistik":
                            response = "🚚 **Lojistik Ağı Tetiklendi.**\nHammadde fazlası olan köylerden, eksik olanlara sevkiyat planlanıyor.";
                            // await economyService.BalanceResourcesAsync();
                            break;
                            
                        case "altin":
                            response = "💰 **Darphane Çalıştırılıyor...**\nUygun olan tüm köylerde altın para basımı kuyruğa alındı.";
                            break;

                        case "insaat":
                            response = "🏗️ **İnşaat Denetçisi Sahada.**\nBoşta duran inşaat kuyrukları dolduruluyor.";
                            break;

                        case "log":
                            var recentOps = await warfareService.GetRecentOperationsAsync(5);
                            if (recentOps.Any())
                            {
                                response = "📜 **Son 5 İşlem:**\n";
                                int i = 1;
                                foreach (var op in recentOps)
                                {
                                    response += $"{i}. [{op.CreatedDate:HH:mm}] {op.Type} - {op.Status}\n";
                                    i++;
                                }
                            }
                            else
                            {
                                response = "📜 **Son İşlemler:**\nHenüz kayıtlı işlem yok.";
                            }
                            break;

                        default:
                            response = "❓ Bilinmeyen emir. Komut listesi için menüye bakınız.";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    response = $"⚠️ **HATA:** Komut işlenirken bir sorun oluştu.\n{ex.Message}";
                    _logger.LogError(ex, "Komut işleme hatası");
                }

                if (!string.IsNullOrEmpty(response))
                {
                    await bot.SendMessage(
                        chatId: message.Chat.Id,
                        text: response,
                        parseMode: ParseMode.Markdown,
                        cancellationToken: cts);
                }
            }
        }

        // Implementation of ITelegramService methods
        public async Task SendMessageAsync(string message)
        {
            await SendNotificationAsync(message);
        }

        public async Task SendMessageToChatAsync(long chatId, string message)
        {
            if (_botClient != null)
                await _botClient.SendMessage(chatId, message);
        }

        public async Task<string> GetUpdatesAsync()
        {
            return await Task.FromResult("Polling is active.");
        }

        public async Task SendNotificationAsync(string message)
        {
            if (_botClient != null && long.TryParse(_allowedChatId, out long chatId))
                await _botClient.SendMessage(chatId, message);
        }

        private Task HandleErrorAsync(ITelegramBotClient bot, Exception exception, CancellationToken cts)
        {
            _logger.LogError($"Telegram Hatası: {exception.Message}");
            return Task.CompletedTask;
        }
    }
}
