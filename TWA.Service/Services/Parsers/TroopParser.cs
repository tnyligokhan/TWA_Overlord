using System.Text.RegularExpressions;

namespace TWA.Service.Services.Parsers
{
    /// <summary>
    /// Dedicated parser for troop-related data.
    /// Handles: Troop counts from Place page.
    /// </summary>
    public class TroopParser : BaseHtmlParser
    {
        public Dictionary<string, int> ParseTroopCounts(string html)
        {
            var troops = new Dictionary<string, int>();
            var unitTypes = new[] { "spear", "sword", "axe", "spy", "light", "heavy", "ram", "catapult", "knight", "snob" };
            
            // Initialize with 0
            foreach (var u in unitTypes) troops[u] = 0;

            var doc = LoadHtml(html);
            if (doc == null) return troops;

            // 1. Parse "Bu köyden" (From this village) row in #units_home
            var homeRow = doc.DocumentNode.SelectSingleNode("//table[@id='units_home']//tr[contains(., 'Bu köyden')]");
            if (homeRow != null)
            {
                foreach (var unit in unitTypes)
                {
                    var cell = homeRow.SelectSingleNode($".//td[contains(@class, 'unit-item-{unit}')]");
                    if (cell != null)
                    {
                        var txt = cell.InnerText.Trim();
                        // Sometimes separate by dots
                        txt = txt.Replace(".", "");
                        if (int.TryParse(txt, out int count))
                        {
                            troops[unit] += count;
                        }
                    }
                }
            }

            // 2. Parse Scavenging Troops (Temizlik birlikleri)
            // Look for table following h3 'Temizlik birlikleri' or simply a table containing 'Tembel Çapulcular'
            // And get its 'Toplam' row.
            var scavengeTables = doc.DocumentNode.SelectNodes("//table[contains(@class, 'vis')]");
            if (scavengeTables != null)
            {
                foreach (var table in scavengeTables)
                {
                    // Check if this is a scavenging table (has scavenge specific terms)
                    if (table.InnerText.Contains("Tembel Çapulcular") || table.InnerText.Contains("Temizlik birlikleri"))
                    {
                        var totalRow = table.SelectSingleNode(".//tr[contains(., 'Toplam')]");
                        if (totalRow != null)
                        {
                            foreach (var unit in unitTypes)
                            {
                                var cell = totalRow.SelectSingleNode($".//td[contains(@class, 'unit-item-{unit}')]");
                                if (cell != null)
                                {
                                    var txt = cell.InnerText.Trim();
                                    txt = txt.Replace(".", "");
                                    if (int.TryParse(txt, out int count))
                                    {
                                        troops[unit] += count;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return troops;
        }

        private int ParseSingleTroopCount(string html, string unitType)
        {
             // Deprecated by ParseTroopCounts new logic but kept for interface/compatibility if needed, 
             // though currently unused in new implementation.
             return 0;
        }
    }
}
