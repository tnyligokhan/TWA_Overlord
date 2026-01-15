using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using TWA.Core.Entities;

namespace TWA.Service.Services.Parsers
{
    public class InventoryParser : BaseHtmlParser
    {
        public List<InventoryItem> ParseInventory(string html)
        {
            var items = new List<InventoryItem>();
            var doc = LoadHtml(html);

            // 1. Try Parsing Rendered HTML Nodes
            // Look for specific item containers
            var itemNodes = doc.DocumentNode.SelectNodes("//div[contains(@class, 'inventory_item')]");
            if (itemNodes != null)
            {
                foreach (var node in itemNodes)
                {
                    try
                    {
                        var item = new InventoryItem();
                        
                        // ID
                        item.Identifier = node.GetAttributeValue("data-id", "") 
                                       ?? node.GetAttributeValue("id", "");

                        // Name/Title
                        // Often in an attribute 'data-title' or inside a child header/link
                        var name = node.GetAttributeValue("data-title", "");
                        if (string.IsNullOrEmpty(name))
                        {
                            var titleNode = node.SelectSingleNode(".//a[contains(@class, 'inventory_item_link')]") 
                                         ?? node.SelectSingleNode(".//h4");
                            name = titleNode?.InnerText?.Trim();
                        }
                        item.Name = name;

                        // Count
                        // Usually a span with class 'item_count' or similar
                        var countNode = node.SelectSingleNode(".//span[contains(@class, 'item_count')]");
                        if (countNode != null)
                        {
                            int.TryParse(countNode.InnerText.Trim(), out int count);
                            item.Count = count > 0 ? count : 1;
                        }
                        else
                        {
                            item.Count = 1; // Default to 1 if no count shown
                        }

                        // Image / Icon
                        var imgNode = node.SelectSingleNode(".//img");
                        if (imgNode != null)
                        {
                            // Could extract category or type from image src if needed
                        }

                        if (!string.IsNullOrEmpty(item.Name))
                        {
                            items.Add(item);
                        }
                    }
                    catch
                    {
                        // Skip malformed items
                    }
                }
            }
            
            return items;
        }

        public Dictionary<string, int> ParseFlags(string html)
        {
            var flags = new Dictionary<string, int>();
            var doc = LoadHtml(html);
            
            // Parse from JavaScript: FlagsScreen.setFlagCounts({"1":{"1":"0","2":"1"},"2":{"1":"1","2":"1","4":"1"}...});
            var match = Regex.Match(html, @"FlagsScreen\.setFlagCounts\((\{.+?\})\);", RegexOptions.Singleline);
            if (match.Success)
            {
                var jsonStr = match.Groups[1].Value;
                
                // Parse nested structure: {"flagType":{"level":"count"}}
                // flagType: 1=Hammadde, 2=Asker toplama, 3=Saldırı, 4=Savunma, 5=Şans, 6=Nüfus, 7=Altın, 8=Taşıma
                var typeMatches = Regex.Matches(jsonStr, @"""(\d+)"":\{([^\}]+)\}");
                
                foreach (Match tm in typeMatches)
                {
                    var flagType = tm.Groups[1].Value;
                    var levelsStr = tm.Groups[2].Value;
                    
                    // Parse level:count pairs: "1":"0","2":"1","4":"1"
                    var levelMatches = Regex.Matches(levelsStr, @"""(\d+)"":""(\d+)""");
                    
                    foreach (Match lm in levelMatches)
                    {
                        var level = lm.Groups[1].Value;
                        var count = lm.Groups[2].Value;
                        
                        if (int.TryParse(count, out int countInt) && countInt > 0)
                        {
                            string key = $"flag_{flagType}_{level}";
                            flags[key] = countInt;
                        }
                    }
                }
            }
            
            // Parse current assigned flag from HTML
            var currentFlagNode = doc.DocumentNode.SelectSingleNode("//div[@id='current_flag']//img");
            if (currentFlagNode != null)
            {
                var src = currentFlagNode.GetAttributeValue("src", "");
                // Extract type and level from: /graphic/flags/medium/1_2.webp
                var flagMatch = Regex.Match(src, @"flags/medium/(\d+)_(\d+)\.webp");
                if (flagMatch.Success)
                {
                    flags["current_type"] = int.Parse(flagMatch.Groups[1].Value);
                    flags["current_level"] = int.Parse(flagMatch.Groups[2].Value);
                }
            }
            
            return flags;
        }
    }
}
