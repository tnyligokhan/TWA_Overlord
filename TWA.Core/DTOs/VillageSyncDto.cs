namespace TWA.Core.DTOs
{
    public class VillageSyncDto
    {
        public int GameId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int X { get; set; }
        public int Y { get; set; }
        public int Points { get; set; }
        
        // Ekonomi
        public int Wood { get; set; }
        public int Stone { get; set; }
        public int Iron { get; set; }
        public int StorageMax { get; set; }
        public int PopCurrent { get; set; }
        public int PopMax { get; set; }

        // Askerler
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
    }
}
