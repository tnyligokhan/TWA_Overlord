using System.Text.RegularExpressions;
using TWA.Core.DTOs;

namespace TWA.Service.Services.Parsers
{
    /// <summary>
    /// Dedicated parser for building-related data.
    /// Handles: Building levels, build queue.
    /// </summary>
    public class BuildingParser : BaseHtmlParser
    {
        public Dictionary<string, int> ParseBuildingLevels(string html)
        {
            var buildings = new Dictionary<string, int>();
            var doc = LoadHtml(html);

            var rows = SelectNodes(doc.DocumentNode, "//tr[starts-with(@id, 'main_buildrow_')]");
            if (!rows.Any()) return buildings;

            foreach (var row in rows)
            {
                var id = row.GetAttributeValue("id", "");
                var buildingType = id.Replace("main_buildrow_", "");

                var levelText = ExtractText(row, ".//span[@style='font-size: 0.9em']");
                var match = Regex.Match(levelText, @"Seviye (\d+)");
                
                if (match.Success && int.TryParse(match.Groups[1].Value, out int level))
                {
                    buildings[buildingType] = level;
                }
            }

            return buildings;
        }

        public List<BuildQueueItem> ParseBuildQueue(string html)
        {
            var queue = new List<BuildQueueItem>();
            var doc = LoadHtml(html);

            var rows = SelectNodes(doc.DocumentNode, "//tbody[@id='buildqueue']/tr[contains(@class, 'buildorder_')]");
            if (!rows.Any()) return queue;

            bool isFirst = true;
            foreach (var row in rows)
            {
                try
                {
                    var classAttr = row.GetAttributeValue("class", "");
                    var buildingMatch = Regex.Match(classAttr, @"buildorder_(\w+)");
                    if (!buildingMatch.Success) continue;
                    
                    var buildingType = buildingMatch.Groups[1].Value;

                    var levelText = ExtractText(row, ".//td[1]");
                    var levelMatch = Regex.Match(levelText, @"Seviye\s+(\d+)");
                    
                    int targetLevel = 0;
                    if (levelMatch.Success)
                    {
                        int.TryParse(levelMatch.Groups[1].Value, out targetLevel);
                    }

                    var endTimeStr = ExtractAttribute(row, ".//span[@data-endtime]", "data-endtime");
                    
                    DateTime endTime = DateTime.Now.AddHours(1);
                    if (!string.IsNullOrEmpty(endTimeStr) && long.TryParse(endTimeStr, out long timestamp))
                    {
                        endTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).LocalDateTime;
                    }

                    queue.Add(new BuildQueueItem
                    {
                        BuildingType = buildingType,
                        CurrentLevel = targetLevel - 1,
                        TargetLevel = targetLevel,
                        StartTime = DateTime.Now,
                        EndTime = endTime,
                        IsActive = isFirst
                    });

                    isFirst = false;
                }
                catch
                {
                    continue;
                }
            }

            return queue;
        }
    }
}
