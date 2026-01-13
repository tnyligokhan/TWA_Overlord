using System.Threading.Tasks;

namespace TWA.Core.Interfaces.Services
{
    public interface ITelegramService
    {
        Task SendMessageAsync(string message);
        Task SendMessageToChatAsync(long chatId, string message);
        Task<string> GetUpdatesAsync(); // Simplified for now, returns raw updates or specific text
    }
}
