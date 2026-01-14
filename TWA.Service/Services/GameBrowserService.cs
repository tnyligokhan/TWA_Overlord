using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using TWA.Core.Helpers; // RandomProvider buradan gelecek
using TWA.Core.Interfaces.Services;
using TWA.Core.Configuration;

namespace TWA.Service.Services
{
    public class GameBrowserService : IGameBrowserService
    {
        private readonly IConfiguration _config;
        private IPlaywright? _playwright;
        private IBrowser? _browser;
        private IPage? _page;
        private bool _isLoggedIn = false;

        public GameBrowserService(IConfiguration config)
        {
            _config = config;
        }

        private async Task InitBrowserAsync()
        {
            if (_page != null) return;

            _playwright = await Playwright.CreateAsync();
            
            // Taktik: Tarayıcıyı biraz daha yavaş ve gerçekçi aç
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = _config.GetValue<bool>("GameConfig:Headless"), 
                SlowMo = 50, // Her işlem arası 50ms doğal gecikme
                Args = new[] { "--start-maximized" } // Tam ekran aç
            });

            // Tarayıcı Context'i (User-Agent hilesi)
            var context = await _browser.NewContextAsync(new BrowserNewContextOptions
            {
                UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36",
                ViewportSize = ViewportSize.NoViewport
            });

            _page = await context.NewPageAsync();
        }

        // İNSAN GİBİ YAZMA FONKSİYONU
        public async Task TypeHumanLike(string selector, string text)
        {
            if (_page == null) return;

            await _page.ClickAsync(selector); // Önce kutuya tıkla
            await Task.Delay(RandomProvider.Next(100, 300)); // Odaklanma beklemesi

            var locator = _page.Locator(selector);
            foreach (char c in text)
            {
                // Her harf arası rastgele bekleme (50ms - 150ms)
                await locator.PressSequentiallyAsync(c.ToString(), new LocatorPressSequentiallyOptions { Delay = RandomProvider.Next(50, 150) });
            }
            
            await Task.Delay(RandomProvider.Next(300, 800)); // Yazma bitince bekle
        }

        public async Task NavigateToBuilding(string buildingName)
        {
            await GetPageContentAsync(buildingName);
        }

        public async Task<bool> LoginAsync()
        {
            await InitBrowserAsync();
            if (_isLoggedIn) return true;
            if (_page == null) throw new InvalidOperationException("Browser not initialized");

            var url = _config["GameConfig:Url"] ?? throw new InvalidOperationException("Game Config Url is missing");
            var user = _config["GameConfig:Username"] ?? throw new InvalidOperationException("Game Config Username is missing");
            var pass = _config["GameConfig:Password"] ?? throw new InvalidOperationException("Game Config Password is missing");
            var world = _config["GameConfig:World"] ?? throw new InvalidOperationException("Game Config World is missing");

            await _page.GotoAsync(url);
            await Task.Delay(2000); // Sayfa yüklenince 2sn bekle (Bot testi yememek için)

            // Çerez İzni Varsa Kapat (Olası)
            try { if (await _page.IsVisibleAsync(".osano-cm-accept-all")) await _page.ClickAsync(".osano-cm-accept-all"); } catch { }

            // Kullanıcı Adı ve Şifreyi İnsan Gibi Gir
            await TypeHumanLike("#user", user);
            await TypeHumanLike("#password", pass);

            // Giriş Yap
            await _page.ClickAsync(".btn-login");
            
            // --- KRİTİK BÖLGE: DÜNYA SEÇİMİ VE BOT KONTROLÜ ---
            
            // Eğer "Bot Testi" (Captcha) çıktıysa, giriş yapılamaz.
            // Burada kullanıcıya zaman tanımak için uzun bir bekleme veya kontrol döngüsü kuruyoruz.
            
            bool worldFound = false;
            int attempts = 0;

            while (!worldFound && attempts < 60) // 60 saniye boyunca dünyayı arar
            {
                try 
                {
                    // Önce zaten giriş yapılmış mı kontrol et
                    if (await _page.IsVisibleAsync("#menu_row")) 
                    {
                        worldFound = true;
                        break;
                    }

                    // Dünya seçim sayfasında mıyız?
                    // Klanlar.org'da dünya listesi genelde .world_button_active veya benzer class'larda
                    // Daha genel bir yaklaşım: Dünya numarasını içeren herhangi bir link
                    var worldNumber = world.Replace("tr", "").Replace("TR", "");
                    
                    // Farklı selector denemeleri
                    var selectors = new[] 
                    {
                        $"a:has-text('Dünya {worldNumber}')",
                        $"a:has-text('TR{worldNumber}')",
                        $"a:has-text('{world}')",
                        $".world_button_active:has-text('{worldNumber}')",
                        $"a[href*='world={world}']"
                    };

                    bool clicked = false;
                    foreach (var selector in selectors)
                    {
                        try
                        {
                            if (await _page.IsVisibleAsync(selector))
                            {
                                await Task.Delay(1000);
                                await _page.ClickAsync(selector);
                                clicked = true;
                                worldFound = true;
                                break;
                            }
                        }
                        catch { }
                    }

                    if (!clicked)
                    {
                        // Ekranda bir şey yok, belki CAPTCHA var? Kullanıcı çözsün diye bekliyoruz.
                        await Task.Delay(1000); 
                        attempts++;
                    }
                }
                catch { await Task.Delay(1000); attempts++; }
            }

            if (!worldFound) throw new Exception("Giriş yapılamadı! Lütfen tarayıcıdaki CAPTCHA'yı çözün.");

            // --- OYUN İÇİ POPUP TEMİZLİĞİ ---
            await _page.WaitForLoadStateAsync(LoadState.NetworkIdle); // Sayfa tamamen dursun
            await Task.Delay(2000);

            // Günlük bonus veya pop-up varsa kapatmayı dene
            // (Oyunun popup kapatma class'ları değişebilir, genel bir mantık)
            var popupCloseButtons = new[] { ".popup_box_close", "#close_welcome_screen", ".btn-confirm-yes" };
            foreach (var btn in popupCloseButtons)
            {
                try {
                    if (await _page.IsVisibleAsync(btn)) await _page.ClickAsync(btn);
                } catch { }
            }

            // Ana menü göründü mü?
            await _page.WaitForSelectorAsync("#menu_row");
            _isLoggedIn = true;
            return true;
        }

        public async Task<bool> CheckIncomingAttacksAsync()
        {
            if (_page == null) return false;
            try 
            {
                // Saldırı ikonunu veya sayısını kontrol et
                // Tribal Wars'da genelde id="incomings_amount" veya class="icon header incoming" kullanılır.
                // Basit bir kontrol:
                var incomingSelector = "#incomings_amount"; 
                if (await _page.IsVisibleAsync(incomingSelector))
                {
                    var text = await _page.InnerTextAsync(incomingSelector);
                    if (int.TryParse(text, out int count) && count > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CanAffordBuilding(string buildingId)
        {
             if (_page == null) return false;
             try 
             {
                 // Örnek Selector: .cost_wood, .cost_stone, .cost_iron (Bu selectorlar oyunun HTML yapısına göre değişir)
                 // Tribal Wars genelde maliyeti data attribute veya özel class içinde tutar.
                 // Basit bir yaklaşım: Binanın sırasındaki kaynak ikonlarının yanındaki sayıları okumak.
                 
                 // Varsayım: Maliyetleri "wood", "stone", "iron" global değişkenlerinden veya header'dan okuyup
                 // binanın gereksinimleriyle kıyaslıyoruz.
                 
                 // Ancak kullanıcı "Playwright ile sayfadaki maliyetleri oku" dedi.
                 // Bu yüzden sayfada o anki binanın ".build_options .wood" gibi alanlarına bakacağız.
                 // Selector örneği: $"#main_buildrow_{buildingId} .cost_wood"
                 
                 var woodCostElem = _page.Locator($"#main_buildrow_{buildingId} .cost_wood");
                 var stoneCostElem = _page.Locator($"#main_buildrow_{buildingId} .cost_stone");
                 var ironCostElem = _page.Locator($"#main_buildrow_{buildingId} .cost_iron");

                 // Eğer elementler yoksa, bina max seviye veya yapılamaz olabilir.
                 if (!await woodCostElem.IsVisibleAsync()) return false;

                 int woodCost = int.Parse(await woodCostElem.InnerTextAsync());
                 int stoneCost = int.Parse(await stoneCostElem.InnerTextAsync());
                 int ironCost = int.Parse(await ironCostElem.InnerTextAsync());

                 // Mevcut kaynakları oku (Header'dan)
                 int currentWood = int.Parse(await _page.InnerTextAsync("#wood"));
                 int currentStone = int.Parse(await _page.InnerTextAsync("#stone"));
                 int currentIron = int.Parse(await _page.InnerTextAsync("#iron"));

                 return currentWood >= woodCost && currentStone >= stoneCost && currentIron >= ironCost;
             }
             catch
             {
                 // Parse hatası veya element bulunamadı -> Güvenli taraf: false
                 return false;
             }
        }

        public async Task<int> GetActiveBuildCountAsync()
        {
            if (_page == null) return 0;
            try
            {
                // İnşaat kuyruğundaki iptal butonlarını veya satırları sayar
                // Bu selector oyunun sürümüne göre değişebilir ama genelde #build_queue içindedir.
                // Standard: #build_queue .btn-cancel veya .lit-item
                
                if (await _page.IsVisibleAsync("#build_queue"))
                {
                    // Kuyruktaki satır sayısını al (header hariç)
                    // Veya direkt iptal edilebilir emirleri say
                    return await _page.Locator("#build_queue .btn-cancel").CountAsync();
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        public async Task<int> GetMaxMintableCoinsAsync()
        {
            if (_page == null) return 0;
            try 
            {
                // Akademi sayfasındaki "Maksimum: X" yazısını veya kaynağa göre hesabı bul.
                // Genelde #coin_mint_fill_max gibi bir link olur ve tıklayınca input dolar.
                // Veya o linkin text'inden (X) değeri okunabilir.
                
                var maxLink = _page.Locator("#coin_mint_fill_max"); // Örn selector
                if (await maxLink.IsVisibleAsync())
                {
                    var text = await maxLink.InnerTextAsync();
                    // "(5)" gibi formatları temizle
                    text = text.Replace("(", "").Replace(")", "").Trim();
                    if (int.TryParse(text, out int count)) return count;
                }
                
                // Alternatif: Kaynakları ve altın maliyetini biliyorsak hesaplayabiliriz
                // Şimdilik sadece DOM'a bakıyoruz.
                return 0; 
            }
            catch
            {
                return 0;
            }
        }

        public async Task NavigateToPlace()
        {
            await GetPageContentAsync("place");
        }

        public async Task FillTroops(TWA.Core.Entities.TroopSet troops)
        {
            if (_page == null) return;

            // Form inputlarını doldur
            // Tribal Wars input name'leri: spear, sword, axe, spy, light, heavy, ram, catapult
            
            if (troops.Spear > 0) await TypeHumanLike("input[name='spear']", troops.Spear.ToString());
            if (troops.Sword > 0) await TypeHumanLike("input[name='sword']", troops.Sword.ToString());
            if (troops.Axe > 0) await TypeHumanLike("input[name='axe']", troops.Axe.ToString());
            if (troops.Spy > 0) await TypeHumanLike("input[name='spy']", troops.Spy.ToString());
            if (troops.Light > 0) await TypeHumanLike("input[name='light']", troops.Light.ToString());
            if (troops.Heavy > 0) await TypeHumanLike("input[name='heavy']", troops.Heavy.ToString());
            if (troops.Ram > 0) await TypeHumanLike("input[name='ram']", troops.Ram.ToString());
            if (troops.Catapult > 0) await TypeHumanLike("input[name='catapult']", troops.Catapult.ToString());
            if (troops.Snob > 0) await TypeHumanLike("input[name='snob']", troops.Snob.ToString());
            if (troops.Knight > 0) await TypeHumanLike("input[name='knight']", troops.Knight.ToString());
        }

        public async Task<string> GetPageContentAsync(string screen)
        {
            if (!_isLoggedIn) await LoginAsync();
            if (_page == null) throw new InvalidOperationException("Browser not initialized");

            // Mevcut URL'i kontrol et
            if (!_page.Url.Contains($"screen={screen}"))
            {
                // URL Manipülasyonu ile git (Daha hızlı)
                var currentUrl = _page.Url;
                
                // Köy ID'yi DOM'dan çek (game_data objesinden)
                string? villageId = null;
                try
                {
                    var vId = await _page.EvaluateAsync<object?>("game_data.village.id");
                    villageId = vId?.ToString();
                }
                catch
                {
                    // game_data yoksa URL'den çekmeyi dene
                    if (currentUrl.Contains("village="))
                    {
                        villageId = currentUrl.Split("village=")[1].Split('&')[0];
                    }
                }

                if (string.IsNullOrEmpty(villageId))
                {
                    throw new Exception("Köy ID'si alınamadı. Oyuna giriş yapıldığından emin olun.");
                }

                // Base URL'i bul
                var baseUrl = currentUrl.Contains('?') ? currentUrl.Split('?')[0] : currentUrl;
                if (!baseUrl.Contains("game.php"))
                {
                    // URL'de game.php yoksa ekle
                    var uri = new Uri(currentUrl);
                    baseUrl = $"{uri.Scheme}://{uri.Host}/game.php";
                }

                var targetUrl = $"{baseUrl}?village={villageId}&screen={screen}";
                await _page.GotoAsync(targetUrl);
                await _page.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
                
                // Rastgele bekleme (İnsan hissi)
                await Task.Delay(RandomProvider.Next(500, 1500));
            }

            return await _page.ContentAsync();
        }

        public async Task ClickButtonAsync(string selector)
        {
            if (_page == null) throw new InvalidOperationException("Browser not initialized");
            // Tıklamadan önce hafif bekle
            await Task.Delay(RandomProvider.Next(200, 600));
            await _page.ClickAsync(selector);
        }

        public async Task CloseAsync()
        {
            if (_browser != null) await _browser.CloseAsync();
        }
        
        // JavaScript Evaluation Helpers
        public async Task<T?> EvaluateJsAsync<T>(string jsExpression)
        {
            if (_page == null) throw new InvalidOperationException("Browser not initialized");
            
            try
            {
                return await _page.EvaluateAsync<T>(jsExpression);
            }
            catch
            {
                return default;
            }
        }
        
        public async Task<int> GetGameDataIntAsync(string jsPath)
        {
            var result = await EvaluateJsAsync<object?>(jsPath);
            if (result == null) return 0;
            
            if (int.TryParse(result.ToString(), out int value))
                return value;
            
            return 0;
        }
        
        public async Task<string> GetGameDataStringAsync(string jsPath)
        {
            var result = await EvaluateJsAsync<object?>(jsPath);
            return result?.ToString() ?? string.Empty;
        }
        
        public async Task<int> GetElementIntAsync(string cssSelector)
        {
            if (_page == null) throw new InvalidOperationException("Browser not initialized");
            
            try
            {
                // Element var mı kontrol et
                if (!await _page.IsVisibleAsync(cssSelector))
                    return 0;
                
                // Element'in text içeriğini al
                var text = await _page.InnerTextAsync(cssSelector);
                
                // Sayıyı parse et
                if (int.TryParse(text.Trim(), out int value))
                    return value;
                
                return 0;
            }
            catch
            {
                return 0;
            }
        }
        
        public async Task<string> GetElementTextAsync(string cssSelector)
        {
            if (_page == null) throw new InvalidOperationException("Browser not initialized");
            
            try
            {
                if (!await _page.IsVisibleAsync(cssSelector))
                    return string.Empty;
                
                return await _page.InnerTextAsync(cssSelector);
            }
            catch
            {
                return string.Empty;
            }
        }
        
        public async Task<int> GetElementAttributeIntAsync(string cssSelector, string attributeName)
        {
            if (_page == null) throw new InvalidOperationException("Browser not initialized");
            
            try
            {
                if (!await _page.IsVisibleAsync(cssSelector))
                    return 0;
                
                var attribute = await _page.GetAttributeAsync(cssSelector, attributeName);
                
                if (string.IsNullOrEmpty(attribute))
                    return 0;
                
                if (int.TryParse(attribute, out int value))
                    return value;
                
                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
