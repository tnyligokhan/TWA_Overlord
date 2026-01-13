namespace TWA.Core.Interfaces.Services
{
    public interface IGroqAiService
    {
        // Raporu analiz eder ve özet döner
        Task<string> AnalyzeReportAsync(string reportHtml);
        
        // Köy durumuna göre strateji önerir
        Task<string> GetStrategySuggestionAsync(int villageId);

        // Genel Sohbet Cevabı
        Task<string> GetChatResponseAsync(string userDetails);
    }
}
