using System;
using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class WarfareService : IWarfareService
    {
        private readonly IGameBrowserService _browser;
        private readonly HumanErrorService _humanError;

        public WarfareService(IGameBrowserService browser, HumanErrorService humanError)
        {
            _browser = browser;
            _humanError = humanError;
        }

        public DateTime CalculateLaunchTime(Village source, int targetX, int targetY, TroopSet troops, DateTime targetArrivalTime)
        {
            var duration = GetDuration(source, targetX, targetY, troops);
            return targetArrivalTime - duration;
        }

        public TimeSpan GetDuration(Village source, int targetX, int targetY, TroopSet troops)
        {
            // Basit mesafe formülü:
            double dist = Math.Sqrt(Math.Pow(source.CoordinateX - targetX, 2) + Math.Pow(source.CoordinateY - targetY, 2));
            
            // En yavaş birimi bul (Hızlar: Spear=18, Sword=22, vs dk/birim)
            // Bu kısım detaylı oyun verisine ihtiyaç duyar. Şimdilik ortalama bir değer varsayalım veya
            // ileride WorldSettings'den çekilmeli.
            double slowUnitminutesPerField = 35.0; // Misyoner hızı örneğin
            
            // Daha detaylı implementasyon için UnitSpeed helper'ı gerekecektir.
            // Şimdilik placeholder dönüyoruz.
            return TimeSpan.FromMinutes(dist * slowUnitminutesPerField); 
        }

        public async Task ScheduleAttackAsync(AttackTask task)
        {
            // DB'ye kaydetme mantığı (Repository kullanılır)
            // Şimdilik boş bırakıyorum (User prompt sadece SendAttackAsync'e odaklandı)
            await Task.CompletedTask;
        }

        public async Task SendAttackAsync(AttackCommand cmd)
        {
            // 1. İNSAN HATASI EKLE (Jitter)
            // Eğer bu bir Snipe değilse, rastgele gecikme ekle.
            int lag = _humanError.CalculateLag(cmd.Type == AttackType.Snipe); 
            
            // 2. İÇTİMA MEYDANINA GİT
            await _browser.NavigateToPlace();

            // 3. ASKER SAYILARINI GİR (Playwright)
            // Eğer Fake ise HumanError servisi asker sayılarını rastgele değiştirebilir (Smart Fake).
            var troopsToSend = cmd.Troops;
            if (cmd.Type == AttackType.Fake)
            {
                troopsToSend = _humanError.ApplyFatFinger(cmd.Troops);
            }
            
            await _browser.FillTroops(troopsToSend);
            
            // 4. KOORDİNAT GİR
            await _browser.TypeHumanLike("input[name='x']", cmd.TargetX.ToString());
            await _browser.TypeHumanLike("input[name='y']", cmd.TargetY.ToString());

            // 5. "SALDIR" BUTONUNA TIKLA (Ön Onay)
            await _browser.ClickButtonAsync("#target_attack");
            
            // --- BURASI KRİTİK NOKTA (SNIPE ZAMANLAMASI) ---
            
            // Onay sayfasındayız. "Saldırı" butonuna ne zaman basacağımızı hesapla.
            // ServerTime ile LocalTime arasındaki farkı (Offset) hesaba kat.
            
            if (cmd.LaunchTime.HasValue)
            {
                var timeToWait = cmd.LaunchTime.Value - DateTime.UtcNow;
                
                // Eğer süre varsa bekle (Precision Wait)
                if (timeToWait.TotalMilliseconds > 0)
                {
                    Console.WriteLine($"⏳ SNIPE: {timeToWait.TotalSeconds:F1} sn bekleniyor...");
                    
                    // Son 5 saniyeye kadar Thread.Sleep ile kaba bekleme
                    // Son saniyelerde SpinWait ile hassas bekleme yap
                    await Task.Delay(timeToWait.Add(TimeSpan.FromMilliseconds(lag))); 
                }
            }

            // 6. KESİN ONAY (OK)
            try {
                await _browser.ClickButtonAsync("#troop_confirm_submit");
            } catch {
                await _browser.ClickButtonAsync(".btn-attack-confirm");
            }

            Console.WriteLine($"🚀 SALDIRI ÇIKILDI! Hedef: {cmd.TargetX}|{cmd.TargetY} - Tip: {cmd.Type}");
        }
    }
}
