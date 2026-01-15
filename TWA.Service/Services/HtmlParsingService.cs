using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using TWA.Core.Interfaces.Services;
using TWA.Core.DTOs;

namespace TWA.Service.Services
{
    public class HtmlParsingService : IHtmlParsingService
    {
        public string ExtractText(string html, string xpath)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var node = doc.DocumentNode.SelectSingleNode(xpath);
            return node?.InnerText?.Trim() ?? string.Empty;
        }

        public List<string> ExtractTexts(string html, string xpath)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes(xpath);
            return nodes?.Select(n => n.InnerText.Trim()).ToList() ?? new List<string>();
        }

        public string ExtractAttribute(string html, string xpath, string attributeName)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var node = doc.DocumentNode.SelectSingleNode(xpath);
            return node?.GetAttributeValue(attributeName, string.Empty) ?? string.Empty;
        }

        public List<string> ExtractAttributes(string html, string xpath, string attributeName)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodes = doc.DocumentNode.SelectNodes(xpath);
            return nodes?.Select(n => n.GetAttributeValue(attributeName, string.Empty)).ToList() ?? new List<string>();
        }

        public Dictionary<string, int> ParseBuildingLevels(string html)
        {
            var buildings = new Dictionary<string, int>();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Parse building rows: <tr id="main_buildrow_main">
            var rows = doc.DocumentNode.SelectNodes("//tr[starts-with(@id, 'main_buildrow_')]");
            if (rows == null) return buildings;

            foreach (var row in rows)
            {
                var id = row.GetAttributeValue("id", "");
                var buildingType = id.Replace("main_buildrow_", "");

                // Extract level from text like "Seviye 10"
                var levelText = row.SelectSingleNode(".//span[@style='font-size: 0.9em']")?.InnerText ?? "";
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
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Parse build queue: <tbody id="buildqueue">
            var rows = doc.DocumentNode.SelectNodes("//tbody[@id='buildqueue']/tr[contains(@class, 'buildorder_')]");
            if (rows == null) return queue;

            bool isFirst = true;
            foreach (var row in rows)
            {
                try
                {
                    // Building type from class: "lit nodrag buildorder_main"
                    var classAttr = row.GetAttributeValue("class", "");
                    var buildingMatch = Regex.Match(classAttr, @"buildorder_(\w+)");
                    if (!buildingMatch.Success) continue;
                    
                    var buildingType = buildingMatch.Groups[1].Value;

                    // Level from text: "Ana bina<br>Seviye 11"
                    var buildingCell = row.SelectSingleNode(".//td[1]");
                    var levelText = buildingCell?.InnerText ?? "";
                    var levelMatch = Regex.Match(levelText, @"Seviye\s+(\d+)");
                    
                    int targetLevel = 0;
                    if (levelMatch.Success)
                    {
                        int.TryParse(levelMatch.Groups[1].Value, out targetLevel);
                    }

                    // Time: data-endtime attribute in span
                    var timerSpan = row.SelectSingleNode(".//span[@data-endtime]");
                    var endTimeStr = timerSpan?.GetAttributeValue("data-endtime", "") ?? "";
                    
                    DateTime endTime = DateTime.Now.AddHours(1);
                    if (!string.IsNullOrEmpty(endTimeStr) && long.TryParse(endTimeStr, out long timestamp))
                    {
                        endTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).LocalDateTime;
                    }

                    var startTime = isFirst ? DateTime.Now : DateTime.Now;

                    queue.Add(new BuildQueueItem
                    {
                        BuildingType = buildingType,
                        CurrentLevel = targetLevel - 1,
                        TargetLevel = targetLevel,
                        StartTime = startTime,
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

        public List<RecruitmentQueueItem> ParseRecruitmentQueue(string html, string buildingType)
        {
            var queue = new List<RecruitmentQueueItem>();
            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            // Parse recruitment queue: <tbody id="trainqueue_barracks">
            var queueId = $"trainqueue_{buildingType}";
            
            // Aktif üretim (ilk satır - class="lit")
            var activeRow = doc.DocumentNode.SelectSingleNode($"//div[@id='trainqueue_wrap_{buildingType}']//tr[@class='lit']");
            if (activeRow != null)
            {
                var item = ParseRecruitmentRow(activeRow, buildingType, true);
                if (item != null) queue.Add(item);
            }

            // Bekleyen üretimler (tbody içindeki satırlar)
            var pendingRows = doc.DocumentNode.SelectNodes($"//tbody[@id='{queueId}']/tr");
            if (pendingRows != null)
            {
                foreach (var row in pendingRows)
                {
                    var item = ParseRecruitmentRow(row, buildingType, false);
                    if (item != null) queue.Add(item);
                }
            }

            return queue;
        }

        private RecruitmentQueueItem? ParseRecruitmentRow(HtmlNode row, string buildingType, bool isActive)
        {
            try
            {
                // Unit type from class: "unit_sprite unit_sprite_smaller spear"
                var unitDiv = row.SelectSingleNode(".//div[contains(@class, 'unit_sprite')]");
                if (unitDiv == null) return null;

                var classAttr = unitDiv.GetAttributeValue("class", "");
                var unitMatch = Regex.Match(classAttr, @"unit_sprite.*?\s+(\w+)");
                if (!unitMatch.Success) return null;

                var unitType = unitMatch.Groups[1].Value;

                // Amount from text: "40 Mızrakçı"
                var amountText = row.SelectSingleNode(".//td[1]")?.InnerText ?? "";
                var amountMatch = Regex.Match(amountText, @"(\d+)\s+");
                if (!amountMatch.Success) return null;

                int amount = int.Parse(amountMatch.Groups[1].Value);

                // Completion time from text: "bugün saat 20:07:49"
                var timeText = row.SelectSingleNode(".//td[3]")?.InnerText?.Trim() ?? "";
                DateTime endTime = ParseTurkishDateTime(timeText);

                return new RecruitmentQueueItem
                {
                    BuildingType = buildingType,
                    UnitType = unitType,
                    Amount = amount,
                    StartTime = DateTime.Now,
                    EndTime = endTime,
                    IsActive = isActive
                };
            }
            catch
            {
                return null;
            }
        }

        private DateTime ParseTurkishDateTime(string timeText)
        {
            try
            {
                // "bugün saat 20:07:49" formatını parse et
                if (timeText.Contains("bugün saat"))
                {
                    var timeMatch = Regex.Match(timeText, @"(\d+):(\d+):(\d+)");
                    if (timeMatch.Success)
                    {
                        int hour = int.Parse(timeMatch.Groups[1].Value);
                        int minute = int.Parse(timeMatch.Groups[2].Value);
                        int second = int.Parse(timeMatch.Groups[3].Value);

                        var today = DateTime.Today;
                        var targetTime = new DateTime(today.Year, today.Month, today.Day, hour, minute, second);

                        // Eğer saat geçmişte ise yarına al
                        if (targetTime < DateTime.Now)
                            targetTime = targetTime.AddDays(1);

                        return targetTime;
                    }
                }
                
                // "yarın saat" veya diğer formatlar için
                if (timeText.Contains("yarın saat"))
                {
                    var timeMatch = Regex.Match(timeText, @"(\d+):(\d+):(\d+)");
                    if (timeMatch.Success)
                    {
                        int hour = int.Parse(timeMatch.Groups[1].Value);
                        int minute = int.Parse(timeMatch.Groups[2].Value);
                        int second = int.Parse(timeMatch.Groups[3].Value);

                        var tomorrow = DateTime.Today.AddDays(1);
                        return new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, hour, minute, second);
                    }
                }

                // Parse edilemezse 1 saat sonra varsayılan
                return DateTime.Now.AddHours(1);
            }
            catch
            {
                return DateTime.Now.AddHours(1);
            }
        }

        public Dictionary<string, int> ParseResearchLevels(string html)
        {
            var research = new Dictionary<string, int>();
            
            try
            {
                // Parse research levels from Smithy page
                // The data is in JavaScript: BuildingSmith.techs = {"spear":3,"sword":2,...}
                var techsMatch = Regex.Match(html, @"BuildingSmith\.techs\s*=\s*(\{[^}]+\})");
                
                if (techsMatch.Success)
                {
                    var techsJson = techsMatch.Groups[1].Value;
                    
                    // Parse each tech level: "spear":3
                    var techMatches = Regex.Matches(techsJson, @"""(\w+)"":(\d+)");
                    
                    foreach (Match match in techMatches)
                    {
                        var unitType = match.Groups[1].Value;
                        var level = int.Parse(match.Groups[2].Value);
                        research[unitType] = level;
                    }
                }
                
                // Ensure all units have a value (default 0 if not researched)
                var allUnits = new[] { "spear", "sword", "axe", "spy", "light", "heavy", "ram", "catapult" };
                foreach (var unit in allUnits)
                {
                    if (!research.ContainsKey(unit))
                    {
                        research[unit] = 0;
                    }
                }
            }
            catch
            {
                // Return empty dictionary on error
            }
            
            return research;
        }
    }
}
