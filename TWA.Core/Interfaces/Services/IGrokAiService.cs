using TWA.Core.DTOs;

namespace TWA.Core.Interfaces.Services
{
    public interface IGrokAiService
    {
        // 🧠 1. GÜNLÜK OPERASYON AMİRLİĞİ
        Task<GrokStrategyResponse> GenerateDailyTasksAsync(int villageId);
        
        // 💰 2. EKONOMİK ÖNGÖRÜ
        Task<GrokResourceAdvice> GetResourceManagementAdviceAsync(int villageId);
        
        // ⚔️ 3. ASKERİ ANALİST
        Task<GrokMilitaryAnalysis> AnalyzeMilitaryStatusAsync(int villageId);
        Task<GrokReportAnalysis> AnalyzeReportAsync(string reportHtml);
        
        // 📢 4. DİPLOMASİ VE İLETİŞİM
        Task<GrokDiplomaticMessage> GenerateForumPostAsync(string reportHtml, int targetX, int targetY);
        Task<GrokDiplomaticMessage> GenerateHelpRequestAsync(int villageId, string attackDetails);
        
        // 🏗️ 5. ŞANTİYE ŞEFLİĞİ
        Task<GrokStrategyResponse> GetBuildingPriorityAsync(int villageId);
        
        // 🎭 6. İNSAN TAKLİDİ
        DateTime GetHumanizedTime(DateTime baseTime, int varianceSeconds = 180);
        
        // Genel
        Task<string> GetChatResponseAsync(string prompt);
    }
}
