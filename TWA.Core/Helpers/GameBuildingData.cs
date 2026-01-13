using System;
using System.Collections.Generic;

namespace TWA.Core.Helpers
{
    public struct ResourceCost
    {
        public int Wood;
        public int Stone;
        public int Iron;
        public int Pop; // Nüfus

        public ResourceCost(int w, int s, int i, int p)
        {
            Wood = w; Stone = s; Iron = i; Pop = p;
        }
        
        public int Total => Wood + Stone + Iron;
    }

    public static class GameBuildingData
    {
        // Temel Maliyetler (Seviye 1) - Dünya 99 Hızına göre formüle edilebilir ama basitlik için statik verelim
        // Formül: Base * Factor^(Level-1)
        public static readonly Dictionary<string, (ResourceCost BaseCost, double Factor)> BuildingConstants = new()
        {
            { "main", (new ResourceCost(90, 80, 70, 5), 1.26) }, // Ana Bina
            { "barracks", (new ResourceCost(200, 170, 90, 7), 1.28) }, // Kışla
            { "stable", (new ResourceCost(270, 240, 260, 8), 1.26) }, // Ahır
            { "garage", (new ResourceCost(220, 200, 260, 8), 1.26) }, // Atölye
            { "snob", (new ResourceCost(15000, 25000, 10000, 80), 1.26) }, // Akademi
            { "smith", (new ResourceCost(220, 180, 240, 20), 1.26) }, // Demirci
            { "place", (new ResourceCost(10, 10, 10, 0), 1.26) }, // İçtima
            { "market", (new ResourceCost(100, 100, 100, 20), 1.26) }, // Pazar
            { "wood", (new ResourceCost(50, 10, 10, 5), 1.25) }, // Oduncu
            { "stone", (new ResourceCost(10, 10, 10, 10), 1.27) }, // Kil
            { "iron", (new ResourceCost(10, 10, 10, 10), 1.24) }, // Demir
            { "farm", (new ResourceCost(45, 40, 30, 0), 1.30) }, // Çiftlik
            { "storage", (new ResourceCost(60, 50, 40, 0), 1.265) }, // Depo
            { "wall", (new ResourceCost(50, 100, 20, 5), 1.26) } // Sur
        };

        // Belirli bir seviyenin maliyetini hesaplar
        public static ResourceCost GetCost(string building, int level)
        {
            if (!BuildingConstants.ContainsKey(building)) return new ResourceCost(0,0,0,0);

            var data = BuildingConstants[building];
            double factor = Math.Pow(data.Factor, level - 1);

            return new ResourceCost(
                (int)(data.BaseCost.Wood * factor),
                (int)(data.BaseCost.Stone * factor),
                (int)(data.BaseCost.Iron * factor),
                (int)(data.BaseCost.Pop * factor)
            );
        }

        // Hız 1 için Saatlik Üretim (Seviye 0-30)
        public static readonly int[] ProductionRates = 
        { 
            5, 30, 35, 41, 47, 55, 64, 74, 86, 100, 
            117, 136, 158, 184, 214, 249, 289, 337, 391, 455, 
            530, 616, 717, 833, 969, 1127, 1311, 1525, 1774, 2063, 2400 
        };
    }
}
