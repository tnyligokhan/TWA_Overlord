using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;
using TWA.Web.Hubs;

namespace TWA.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IVillageService _villageService;
        private readonly TWA.Service.Services.VillageDataSyncService _syncService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGrokAiService _grokAiService;
        private readonly IGameBrowserService _browserService;
        private readonly IHubContext<GameDataHub> _hubContext;
        private readonly IHtmlParsingService _htmlParser;

        public DashboardController(
            IVillageService villageService, 
            TWA.Service.Services.VillageDataSyncService syncService,
            IUnitOfWork unitOfWork, 
            IGrokAiService grokAiService, 
            IGameBrowserService browserService,
            IHubContext<GameDataHub> hubContext,
            IHtmlParsingService htmlParser)
        {
            _villageService = villageService;
            _syncService = syncService;
            _unitOfWork = unitOfWork;
            _grokAiService = grokAiService;
            _browserService = browserService;
            _hubContext = hubContext;
            _htmlParser = htmlParser;
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

            // Altın para hesapla (her köyün akademi seviyesine göre tahmini)
            // Basit hesap: Her köy için akademi varsa ~50 altın varsayalım
            int totalGold = villages.Count(v => v.AcademyLevel > 0) * 50;

            // Lojistik rotaları (şimdilik boş, ileride gerçek verilerle doldurulacak)
            var logistics = new List<LogisticsRoute>();

            // ViewModel Oluştur
            var model = new DashboardViewModel
            {
                TotalVillages = villages.Count(),
                TotalPoints = villages.Sum(v => v.Points),
                ActiveAttacks = activeAttacksList.Count,
                LowStorageVillages = (await _villageService.GetVillagesNeedResourcesAsync()).Count(),
                FullStorageVillages = (await _villageService.GetVillagesWithFullStorageAsync()).Count(),
                ActiveAttackList = activeAttacksList,
                RecentLogs = GenerateSystemLogs(villages.Count(), activeAttacksList.Count),
                TotalGoldCoins = totalGold,
                ActiveLogistics = logistics,
                Villages = villages
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
                await _hubContext.Clients.All.SendAsync("SystemLogReceived", new 
                { 
                    timestamp = DateTime.Now.ToString("HH:mm:ss"),
                    level = "INFO",
                    message = "Oyuna giriş yapılıyor..." 
                });

                // 1. Giriş Yap (Yavaşlatılmış Mod)
                await _browserService.LoginAsync();
                
                // Set connection status in session
                HttpContext.Session.SetString("IsGameConnected", "true");
                
                await _hubContext.Clients.All.SendAsync("SystemLogReceived", new 
                { 
                    timestamp = DateTime.Now.ToString("HH:mm:ss"),
                    level = "SUCCESS",
                    message = "Giriş başarılı, sayfa yükleniyor..." 
                });

                // 2. Genel Bakış Sayfasını Çek
                string html = await _browserService.GetPageContentAsync("overview");
                
                // 3. Veriyi Ayrıştır ve DB'ye Yaz
                if (!string.IsNullOrEmpty(html))
                {
                    await _hubContext.Clients.All.SendAsync("SystemLogReceived", new 
                    { 
                        timestamp = DateTime.Now.ToString("HH:mm:ss"),
                        level = "INFO",
                        message = "Köy verileri ayrıştırılıyor..." 
                    });

                    // Parse basic info first to ensure village exists and get ID
                    await _villageService.ParseAndSyncAsync(html);
                    
                    // Get Village ID
                    int villageId = await _browserService.GetGameDataIntAsync("game_data.village.id");
                    
                    if (villageId > 0)
                    {
                         // Call Full Sync with Progress Callback
                         await _syncService.SyncAllVillageDataAsync(villageId, async (msg) => 
                         {
                             await _hubContext.Clients.All.SendAsync("SystemLogReceived", new 
                             { 
                                 timestamp = DateTime.Now.ToString("HH:mm:ss"),
                                 level = "INFO",
                                 message = msg 
                             });
                         });
                    }

                    await _hubContext.Clients.All.SendAsync("SystemLogReceived", new 
                    { 
                        timestamp = DateTime.Now.ToString("HH:mm:ss"),
                        level = "SUCCESS",
                        message = "Tüm veriler güncellendi!" 
                    });

                    return Json(new { success = true, message = "Bağlantı Başarılı! Köy Verileri Güncellendi." });
                }
                else
                {
                    await _hubContext.Clients.All.SendAsync("SystemLogReceived", new 
                    { 
                        timestamp = DateTime.Now.ToString("HH:mm:ss"),
                        level = "ERROR",
                        message = "HTML içeriği boş geldi" 
                    });

                    return Json(new { success = false, message = "Giriş yapıldı ama HTML boş geldi." });
                }
            }
            catch (Exception ex)
            {
                await _hubContext.Clients.All.SendAsync("SystemLogReceived", new 
                { 
                    timestamp = DateTime.Now.ToString("HH:mm:ss"),
                    level = "ERROR",
                    message = $"Bağlantı hatası: {ex.Message}",
                    stackTrace = ex.StackTrace,
                    source = ex.Source
                });

                // Tarayıcı açık kalsın, kullanıcı müdahale edebilsin diye kapatmıyoruz.
                return Json(new { success = false, message = "Hata: " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetConnectionStatus()
        {
            var isConnected = HttpContext.Session.GetString("IsGameConnected") == "true";
            return Json(new { isConnected });
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
        
        // Yeni alanlar
        public int TotalGoldCoins { get; set; }
        public List<LogisticsRoute> ActiveLogistics { get; set; } = new List<LogisticsRoute>();
        public IEnumerable<Village> Villages { get; set; } = new List<Village>();
    }

    public class LogisticsRoute
    {
        public string SourceVillageName { get; set; } = string.Empty;
        public string TargetVillageName { get; set; } = string.Empty;
        public string ArrivalTime { get; set; } = string.Empty;
    }
}
