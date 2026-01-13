using System;
using TWA.Core.Entities;
using TWA.Core.Helpers;

namespace TWA.Service.Services
{
    public class HumanErrorService
    {
        private readonly Random _rnd = new Random();

        // Jitter / Lag hesapla
        public int CalculateLag(bool isSnipe)
        {
            if (isSnipe)
            {
                // Snipe ise çok daha az hata payı (0-50ms)
                // Ama sunucu LAG'i simüle edebiliriz.
                return _rnd.Next(10, 50);
            }
            else
            {
                // Normal saldırıda 200ms - 2sn arası gecikme doğaldır
                return _rnd.Next(200, 2000);
            }
        }

        // "Fat Finger" / Yanlış Tuşlama Simülasyonu (Fake saldırılar için)
        public TroopSet ApplyFatFinger(TroopSet original)
        {
            // Bu metot sadece Fake saldırılarda çağrılmalı.
            // Asker sayısını +/- %10 değiştir.
            
            var newSet = new TroopSet
            {
                Spear = JitterCount(original.Spear),
                Sword = JitterCount(original.Sword),
                Axe = JitterCount(original.Axe),
                Spy = original.Spy, // Casus genelde sabit kalır (1 tane yeter)
                Light = JitterCount(original.Light),
                Ram = JitterCount(original.Ram),
                Catapult = JitterCount(original.Catapult)
            };
            return newSet;
        }

        private int JitterCount(int count)
        {
            if (count == 0) return 0;
            // %10 sapma
            double factor = 1.0 + (_rnd.NextDouble() * 0.2 - 0.1); 
            int newVal = (int)(count * factor);
            return Math.Max(1, newVal); // En az 1 olsun ki fake iptal olmasın
        }
    }
}
