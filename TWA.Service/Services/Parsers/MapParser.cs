using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.RegularExpressions;
using TWA.Core.DTOs;

namespace TWA.Service.Services.Parsers
{
    public class MapParser : BaseHtmlParser
    {
        public List<MapSectorDto> ParseMapData(string html)
        {
            var sectors = new List<MapSectorDto>();

            try
            {
                // Find TWMap.sectorPrefech = [...];
                var match = Regex.Match(html, @"TWMap\.sectorPrefech\s*=\s*(\[.+?\]);", RegexOptions.Singleline);
                if (match.Success)
                {
                    var json = match.Groups[1].Value;
                    // Deserialize
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    sectors = JsonSerializer.Deserialize<List<MapSectorDto>>(json, options) ?? new List<MapSectorDto>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"MapParsing error: {ex.Message}");
            }

            return sectors;
        }
    }
}
