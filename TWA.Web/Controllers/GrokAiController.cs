using Microsoft.AspNetCore.Mvc;
using TWA.Core.Interfaces.Services;

namespace TWA.Web.Controllers
{
    public class GrokAiController : Controller
    {
        private readonly IGrokAiService _grokAi;

        public GrokAiController(IGrokAiService grokAi)
        {
            _grokAi = grokAi;
        }

        public IActionResult Index()
        {
            return View();
        }

        // 🧠 1. GÜNLÜK OPERASYON AMİRLİĞİ
        [HttpPost]
        public async Task<IActionResult> GenerateDailyTasks(int villageId)
        {
            var result = await _grokAi.GenerateDailyTasksAsync(villageId);
            return Json(result);
        }

        // 💰 2. EKONOMİK ÖNGÖRÜ
        [HttpPost]
        public async Task<IActionResult> GetResourceAdvice(int villageId)
        {
            var result = await _grokAi.GetResourceManagementAdviceAsync(villageId);
            return Json(result);
        }

        // ⚔️ 3. ASKERİ ANALİST
        [HttpPost]
        public async Task<IActionResult> AnalyzeMilitary(int villageId)
        {
            var result = await _grokAi.AnalyzeMilitaryStatusAsync(villageId);
            return Json(result);
        }

        // 📢 4. DİPLOMASİ - Forum Mesajı
        [HttpPost]
        public async Task<IActionResult> GenerateForumPost(string reportHtml, int targetX, int targetY)
        {
            var result = await _grokAi.GenerateForumPostAsync(reportHtml, targetX, targetY);
            return Json(result);
        }

        // 📢 4. DİPLOMASİ - Yardım Çağrısı
        [HttpPost]
        public async Task<IActionResult> GenerateHelpRequest(int villageId, string attackDetails)
        {
            var result = await _grokAi.GenerateHelpRequestAsync(villageId, attackDetails);
            return Json(result);
        }

        // 🏗️ 5. ŞANTİYE ŞEFLİĞİ
        [HttpPost]
        public async Task<IActionResult> GetBuildingPriority(int villageId)
        {
            var result = await _grokAi.GetBuildingPriorityAsync(villageId);
            return Json(result);
        }

        // 🎭 6. İNSAN TAKLİDİ - Test
        [HttpGet]
        public IActionResult GetHumanizedTime()
        {
            var baseTime = DateTime.Now.AddHours(2);
            var humanized = _grokAi.GetHumanizedTime(baseTime);
            
            return Json(new 
            { 
                baseTime = baseTime.ToString("HH:mm:ss"),
                humanizedTime = humanized.ToString("HH:mm:ss"),
                difference = (humanized - baseTime).TotalSeconds
            });
        }

        // Genel Chat
        [HttpPost]
        public async Task<IActionResult> Chat(string message)
        {
            var result = await _grokAi.GetChatResponseAsync(message);
            return Json(new { response = result });
        }
    }
}
