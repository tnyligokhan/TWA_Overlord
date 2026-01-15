using System.Text.RegularExpressions;

namespace TWA.Service.Services.Parsers
{
    /// <summary>
    /// Dedicated parser for research/smithy data.
    /// Handles: Research levels from Smithy page.
    /// </summary>
    public class ResearchParser : BaseHtmlParser
    {
        public Dictionary<string, int> ParseResearchLevels(string html)
        {
            var research = new Dictionary<string, int>();
            var units = new[] { "spear", "sword", "axe", "spy", "light", "heavy", "ram", "catapult" };
            
            try
            {
                // Parse research levels from Smithy page
                // The data is in JavaScript: BuildingSmith.techs = {"available":{"spear":{"id":"spear",...,"level":"1",...}}}
                
                var techsMatch = Regex.Match(html, @"BuildingSmith\.techs\s*=\s*(\{.+?\});", RegexOptions.Singleline);
                
                if (!techsMatch.Success)
                {
                    foreach (var unit in units)
                    {
                        research[unit] = 0;
                    }
                    return research;
                }
                
                var techsJson = techsMatch.Groups[1].Value;
                
                foreach (var unit in units)
                {
                    var unitBlockPattern = $@"""{unit}"":\{{(?:[^{{}}]|\{{[^{{}}]*\}})*\}}";
                    var unitBlockMatch = Regex.Match(techsJson, unitBlockPattern);
                    
                    if (unitBlockMatch.Success)
                    {
                        var unitBlock = unitBlockMatch.Value;
                        var levelPattern = @"""level"":""(\d+)""";
                        var levelMatch = Regex.Match(unitBlock, levelPattern);
                        
                        research[unit] = levelMatch.Success ? int.Parse(levelMatch.Groups[1].Value) : 0;
                    }
                    else
                    {
                        research[unit] = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ParseResearchLevels error: {ex.Message}");
                foreach (var unit in units)
                {
                    research[unit] = 0;
                }
            }
            
            return research;
        }
    }
}
