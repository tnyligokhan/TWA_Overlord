using System;

namespace TWA.Core.Helpers
{
    public static class RandomProvider
    {
        private static readonly Random _random = new Random();

        // İnsan benzeri rastgelelik (Box-Muller Dönüşümü)
        // Mean: Ortalama bekleme süresi
        // StdDev: Standart sapma (Ne kadar değişken olsun?)
        public static int NextGaussian(int mean, int stdDev)
        {
            double u1 = 1.0 - _random.NextDouble();
            double u2 = 1.0 - _random.NextDouble();
            
            // Standart Normal Dağılım (Z)
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2);
            
            // İstenen ortalama ve sapmaya uyarla
            double randNormal = mean + stdDev * randStdNormal;
            
            // Negatif çıkarsa pozitife çevir (Süre negatif olamaz)
            return (int)Math.Max(0, randNormal);
        }

        // Basit aralık
        public static int Next(int min, int max)
        {
            return _random.Next(min, max);
        }
        
        // Hata Zarı At (Örn: %5 şansla true döner)
        public static bool RollDice(int percentChance)
        {
            return _random.Next(0, 100) < percentChance;
        }
    }
}
