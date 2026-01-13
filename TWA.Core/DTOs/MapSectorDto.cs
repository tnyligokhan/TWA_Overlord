using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TWA.Core.DTOs
{
    // Oyunun JSON yapısını karşılayan sınıflar
    public class MapSectorDto
    {
        [JsonPropertyName("data")]
        public SectorData Data { get; set; } = new SectorData();
    }

    public class SectorData
    {
        [JsonPropertyName("x")]
        public int X { get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }

        // Köyler bir dizi içinde sözlük objeleri olarak geliyor
        // Örn: [{"1": ["id", "img", "name", "points", "owner_id", ...]}]
        [JsonPropertyName("villages")]
        public List<Dictionary<string, object[]>> Villages { get; set; } = new List<Dictionary<string, object[]>>();
    }
}
