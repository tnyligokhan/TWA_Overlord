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

namespace TWA.Service.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly TelegramBotClient? _botClient;
        private readonly ILogger<TelegramService> _logger;
        private readonly string _allowedChatId; // Sadece sizinle konuşsun

        public TelegramService(IConfiguration config, ILogger<TelegramService> logger)
        {
            _logger = logger;
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

            string response = "";

            // KOMUT İŞLEYİCİ
            switch (messageText.Split(' ')[0].ToLower())
            {
                case "/start":
                    response = "🫡 Komutanım! TWA v3.6 Online. Emirlerinizi bekliyorum.";
                    break;
                case "/durum":
                    // Burası ileride veritabanından güncel durumu çekecek
                    response = "📊 **DURUM RAPORU**\n\n🟢 Sistem: AKTİF\n🏰 Köyler: 5\n⚔️ Gelen Saldırı: YOK\n💰 Depolar: %65";
                    break;
                case "/durdur":
                    response = "🛑 **KILL SWITCH AKTİF!** Sistem kilitlendi.";
                    // _emergencyService.TriggerKillSwitch() çağrılacak
                    break;
                default:
                    response = "❓ Bilinmeyen emir. /durum veya /durdur deneyin.";
                    break;
            }

            await bot.SendMessage(
                chatId: message.Chat.Id,
                text: response,
                parseMode: ParseMode.Markdown,
                cancellationToken: cts);
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
