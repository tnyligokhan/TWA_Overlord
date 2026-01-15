using System.Collections.Generic;
using TWA.Core.Entities;

namespace TWA.Core.Entities
{
    public class TroopTemplate
    {
        public int Spear { get; set; }
        public int Sword { get; set; }
        public int Axe { get; set; }
        public int Spy { get; set; }
        public int Light { get; set; }
        public int Heavy { get; set; }
        public int Ram { get; set; }
        public int Catapult { get; set; }
        public int Knight { get; set; }
        public int Snob { get; set; }

        public static Dictionary<VillageMode, TroopTemplate> Defaults = new Dictionary<VillageMode, TroopTemplate>
        {
            { VillageMode.Balanced, new TroopTemplate { Spear = 3000, Sword = 3000, Axe = 3000, Spy = 100, Light = 1500, Heavy = 500, Ram = 250, Catapult = 50 } },
            { VillageMode.Offensive, new TroopTemplate { Axe = 6000, Light = 2800, Ram = 350, Catapult = 20, Spy = 50 } },
            { VillageMode.Defensive, new TroopTemplate { Spear = 8000, Sword = 8000, Heavy = 1000, Spy = 100 } },
            { VillageMode.Farm, new TroopTemplate { Spear = 100, Sword = 100, Axe = 100 } }, // Low requirements for farm
            { VillageMode.Spy, new TroopTemplate { Spy = 5000 } }
        };
    }
}
