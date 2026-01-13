using TWA.Core.Helpers;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class SecurityService : ISecurityService
    {
        // Dünya 99 Ayarı: Gece Bonusu 23:00 - 07:00
        private readonly TimeSpan _sleepStart = new TimeSpan(23, 15, 0); // 23:15 (Biraz esneklik)
        private readonly TimeSpan _sleepEnd = new TimeSpan(07, 30, 0);   // 07:30 (Alarm çaldı)

        public bool CanOperateNow()
        {
            var now = DateTime.UtcNow.TimeOfDay;

            // Gece Modundaysak ve Kritik bir durum yoksa (Şimdilik kritik kontrolü yok) çalışma.
            // Gece yarısı geçişini (23:00 -> 00:00 -> 07:00) doğru yönetmek için mantık:
            if ((now >= _sleepStart) || (now <= _sleepEnd))
            {
                // %10 İhtimalle "Tuvalete kalkmış" gibi gece de işlem yapabilir (İnandırıcılık)
                if (RandomProvider.RollDice(10)) return true;
                
                return false; 
            }

            return true;
        }

        public int GetActionDelay()
        {
            // Bir sayfayı açtıktan sonra okuma/düşünme süresi
            // Ortalama: 3.5 saniye, Sapma: 1.5 saniye
            return RandomProvider.NextGaussian(3500, 1500);
        }

        public int GetClickDelay()
        {
            // Bir butona basma süresi (Refleks)
            // Ortalama: 250ms, Sapma: 80ms
            return RandomProvider.NextGaussian(250, 80);
        }

        public DateTime ApplyHumanError(DateTime targetTime)
        {
            // "Şişman Parmak" Modülü (Fat Finger)
            // %5 ihtimalle Snipe kaçırır veya geç tıklar.
            
            if (RandomProvider.RollDice(5)) // %5 Hata Oranı
            {
                // 100ms ile 600ms arasında rastgele gecikme ekle
                int mistakeMs = RandomProvider.Next(100, 600);
                return targetTime.AddMilliseconds(mistakeMs);
            }

            return targetTime;
        }
    }
}
