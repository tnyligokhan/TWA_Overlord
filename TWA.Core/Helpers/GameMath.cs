using System;
using TWA.Core.Entities;

namespace TWA.Core.Helpers
{
    public static class GameMath
    {
        // Birim Hızları (Dakika/Kare) - Dünya 99 (Hız 1.0)
        public static Dictionary<string, int> UnitSpeeds = new Dictionary<string, int>
        {
            { "Scout", 9 },
            { "Light", 10 },
            { "Heavy", 11 },
            { "Axe", 18 },
            { "Spear", 18 },
            { "Sword", 22 },
            { "Ram", 30 },
            { "Catapult", 30 },
            { "Noble", 35 }, // Misyoner
            { "Militia", 0 } // Milis hareket etmez
        };

        // En yavaş birimi bulur (Ordu hızı buna eşittir)
        public static int GetSlowestUnitSpeed(TroopSet troops)
        {
            int slowest = 0;
            if (troops.Snob > 0) slowest = Math.Max(slowest, UnitSpeeds["Noble"]);
            else if (troops.Ram > 0 || troops.Catapult > 0) slowest = Math.Max(slowest, UnitSpeeds["Ram"]);
            else if (troops.Sword > 0) slowest = Math.Max(slowest, UnitSpeeds["Sword"]);
            else if (troops.Spear > 0 || troops.Axe > 0) slowest = Math.Max(slowest, UnitSpeeds["Spear"]);
            else if (troops.Heavy > 0) slowest = Math.Max(slowest, UnitSpeeds["Heavy"]);
            else if (troops.Light > 0) slowest = Math.Max(slowest, UnitSpeeds["Light"]);
            else if (troops.Spy > 0) slowest = Math.Max(slowest, UnitSpeeds["Scout"]);
            
            return slowest;
        }

        // İki koordinat arası mesafeyi hesaplar (Öklid)
        public static double CalculateDistance(int x1, int y1, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x1 - x2, 2) + Math.Pow(y1 - y2, 2));
        }

        // Seyahat süresini hesaplar (TimeSpan döner)
        public static TimeSpan CalculateTravelTime(double distance, int unitSpeed, double worldSpeed = 1.0, double unitSpeedConfig = 1.0)
        {
            // Formül: (Mesafe * Birim_Hızı) / (Oyun_Hızı * Birim_Hızı_Çarpanı)
            double totalMinutes = (distance * unitSpeed) / (worldSpeed * unitSpeedConfig);
            
            // Saniyeye çevir ve yuvarla
            double totalSeconds = Math.Round(totalMinutes * 60);
            
            return TimeSpan.FromSeconds(totalSeconds);
        }
    }
}
