using System.Text.RegularExpressions;
using HtmlAgilityPack;
using TWA.Core.DTOs;

namespace TWA.Service.Services.Parsers
{
    /// <summary>
    /// Dedicated parser for recruitment queue data.
    /// Handles: Barracks, Stable, Garage, Snob recruitment queues.
    /// </summary>
    public class RecruitmentParser : BaseHtmlParser
    {
        public List<RecruitmentQueueItem> ParseRecruitmentQueue(string html, string buildingType)
        {
            var queue = new List<RecruitmentQueueItem>();
            var doc = LoadHtml(html);

            var queueId = $"trainqueue_{buildingType}";
            
            // Aktif üretim (ilk satır - class="lit")
            var activeRow = doc.DocumentNode.SelectSingleNode($"//div[@id='trainqueue_wrap_{buildingType}']//tr[@class='lit']");
            if (activeRow != null)
            {
                var item = ParseRecruitmentRow(activeRow, buildingType, true);
                if (item != null) queue.Add(item);
            }

            // Bekleyen üretimler (tbody içindeki satırlar)
            var pendingRows = SelectNodes(doc.DocumentNode, $"//tbody[@id='{queueId}']/tr");
            foreach (var row in pendingRows)
            {
                var item = ParseRecruitmentRow(row, buildingType, false);
                if (item != null) queue.Add(item);
            }

            return queue;
        }

        private RecruitmentQueueItem? ParseRecruitmentRow(HtmlNode row, string buildingType, bool isActive)
        {
            try
            {
                var unitDiv = row.SelectSingleNode(".//div[contains(@class, 'unit_sprite')]");
                if (unitDiv == null) return null;

                var classAttr = unitDiv.GetAttributeValue("class", "");
                var unitMatch = Regex.Match(classAttr, @"unit_sprite.*?\s+(\w+)");
                if (!unitMatch.Success) return null;

                var unitType = unitMatch.Groups[1].Value;

                var amountText = ExtractText(row, ".//td[1]");
                var amountMatch = Regex.Match(amountText, @"(\d+)\s+");
                if (!amountMatch.Success) return null;

                int amount = int.Parse(amountMatch.Groups[1].Value);

                var timeText = ExtractText(row, ".//td[3]");
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

                        if (targetTime < DateTime.Now)
                            targetTime = targetTime.AddDays(1);

                        return targetTime;
                    }
                }
                
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

                return DateTime.Now.AddHours(1);
            }
            catch
            {
                return DateTime.Now.AddHours(1);
            }
        }
    }
}
