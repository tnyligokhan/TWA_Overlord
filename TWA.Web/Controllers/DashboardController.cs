using Microsoft.AspNetCore.Mvc;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;

namespace TWA.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IVillageService _villageService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroqAiService _groqAiService;
        private readonly IGameBrowserService _browserService;

        public DashboardController(IVillageService villageService, IUnitOfWork unitOfWork, IGroqAiService groqAiService, IGameBrowserService browserService)
        {
            _villageService = villageService;
            _unitOfWork = unitOfWork;
            _groqAiService = groqAiService;
            _browserService = browserService;
        }

        public async Task<IActionResult> Index()
        {
            // Verileri Çek
            var villages = await _villageService.GetAllVillagesAsync();
            var attacks = await _unitOfWork.Repository<AttackTask>().GetAllAsync();
            
            var activeAttacksList = attacks.Where(a => a.Status == AttackStatus.Scheduled || a.Status == AttackStatus.Sent)
                                           .OrderBy(a => a.LaunchTime)
                                           .Take(10)
                                           .ToList();

            // ViewModel Oluştur
            var model = new DashboardViewModel
            {
                TotalVillages = villages.Count(),
                TotalPoints = villages.Sum(v => v.Points),
                ActiveAttacks = activeAttacksList.Count,
                LowStorageVillages = (await _villageService.GetVillagesNeedResourcesAsync()).Count(),
                FullStorageVillages = (await _villageService.GetVillagesWithFullStorageAsync()).Count(),
                ActiveAttackList = activeAttacksList,
                RecentLogs = GenerateSystemLogs(villages.Count(), activeAttacksList.Count)
            };

            return View(model);
        }

        private List<string> GenerateSystemLogs(int villageCount, int attackCount)
        {
            var logs = new List<string>
            {
                "Sistem Başlatıldı.",
                "Groq AI Aktif.",
                $"Veritabanı Bağlandı: {villageCount} Köy Yüklendi."
            };

            if (attackCount > 0)
                logs.Add($"Savaş Motoru: {attackCount} saldırı emri işleniyor.");
            else
                logs.Add("Savaş Motoru: Beklemede.");

            logs.Add("Güvenlik Servisi: Biyoritim Normal.");
            logs.Reverse(); // En yeniler üstte
            return logs;
        }

        [HttpPost]
        public async Task<IActionResult> ConnectGame()
        {
            try 
            {
                // 1. Giriş Yap (Yavaşlatılmış Mod)
                await _browserService.LoginAsync();
                
                // 2. Genel Bakış Sayfasını Çek
                string html = await _browserService.GetPageContentAsync("overview");
                
                // 3. Veriyi Ayrıştır ve DB'ye Yaz
                if (!string.IsNullOrEmpty(html))
                {
                    await _villageService.ParseAndSyncAsync(html);
                    return Json(new { success = true, message = "Bağlantı Başarılı! Köy Verileri Güncellendi." });
                }
                else
                {
                    return Json(new { success = false, message = "Giriş yapıldı ama HTML boş geldi." });
                }
            }
            catch (Exception ex)
            {
                // Tarayıcı açık kalsın, kullanıcı müdahale edebilsin diye kapatmıyoruz.
                return Json(new { success = false, message = "Hata: " + ex.Message });
            }
        }
    }

    public class DashboardViewModel
    {
        public int TotalVillages { get; set; }
        public int TotalPoints { get; set; }
        public int ActiveAttacks { get; set; }
        public int LowStorageVillages { get; set; }
        public int FullStorageVillages { get; set; }
        public IEnumerable<AttackTask> ActiveAttackList { get; set; } = new List<AttackTask>();
        public List<string> RecentLogs { get; set; } = new List<string>();
    }
}
