using Microsoft.Playwright;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class WhatsAppService : IWhatsAppService
    {
        private IPlaywright? _playwright;
        // private IBrowser? _browser; // Removed unused field
        private IPage? _page;
        private readonly IGroqAiService _groqService;

        public WhatsAppService(IGroqAiService groqService)
        {
            _groqService = groqService;
        }

        public async Task StartListeningAsync()
        {
            _playwright = await Playwright.CreateAsync();
            
            // User Data Dir kullanarak QR kodunu hatırlar (Her seferinde okutmazsın)
            var userDataDir = Path.Combine(Directory.GetCurrentDirectory(), "whatsapp_session");
            
            var context = await _playwright.Chromium.LaunchPersistentContextAsync(userDataDir, new BrowserTypeLaunchPersistentContextOptions
            {
                Headless = false, // QR okutmak için başta false olmalı
                SlowMo = 50
            });

            _page = context.Pages.FirstOrDefault() ?? await context.NewPageAsync();
            await _page.GotoAsync("https://web.whatsapp.com");

            // Sohbet listesinin yüklenmesini bekle (QR okutma süresi)
            // Sonsuz bekleme yerine 60 saniye bekleyelim, aksi takdirde uygulama asılı kalabilir.
            try 
            {
                await _page.WaitForSelectorAsync("#pane-side", new PageWaitForSelectorOptions { Timeout = 60000 }); 
            }
            catch (TimeoutException)
            {
                // QR okutulmadıysa veya yüklenmediyse logla ve devam et (veya çık)
                // Console.WriteLine("WhatsApp: QR kodu okutulmadı veya sayfa yüklenmedi.");
                // return; 
            }

            // Console.WriteLine("✅ WhatsApp Bağlandı! Mesajlar dinleniyor...");

            // Kendi numaranı veya "Notlar" sohbetini bulup tıkla
            try 
            {
                 // ÖNCE 'Kendim' (Türkçe) dene, olmazsa 'Me' veya 'Notlar' dene
                 await _page.ClickAsync("span[title='Kendim']", new PageClickOptions { Timeout = 5000 });
            } 
            catch 
            {
                try 
                {
                    await _page.ClickAsync("span[title='Me']", new PageClickOptions { Timeout = 5000 });
                }
                catch
                {
                     // Bulamazsa manuel seçim bekleniyor
                }
            }
            
            // Dinleme Döngüsü
            while (true)
            {
                try
                {
                    // Son mesajı oku
                    var messages = await _page.Locator(".message-in .copyable-text").AllInnerTextsAsync();
                    if (messages.Count > 0)
                    {
                        var lastMessage = messages.Last();

                        // Tetikleyici: "Hey TWA"
                        if (lastMessage.StartsWith("Hey TWA", StringComparison.OrdinalIgnoreCase))
                        {
                            // 1. Groq'a sor
                            string prompt = lastMessage.Replace("Hey TWA", "").Trim();
                            string reply = await _groqService.GetChatResponseAsync(prompt); 

                            // 2. Cevabı yaz
                            await _page.FillAsync("div[contenteditable='true'][data-tab='10']", reply);
                            
                            // 3. Gönder
                            // Kullanıcı önerisi: span[data-icon="send"] daha güvenli
                            await _page.ClickAsync("button[data-tab='11']"); 
                            
                            // Tekrar cevap vermemek için bekle
                            await Task.Delay(5000); 
                        }
                    }
                }
                catch { }
                await Task.Delay(2000);
            }
        }
    }
}
