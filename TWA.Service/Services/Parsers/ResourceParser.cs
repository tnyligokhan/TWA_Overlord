using System.Text.RegularExpressions;

namespace TWA.Service.Services.Parsers
{
    /// <summary>
    /// Dedicated parser for resource production data.
    /// Handles: Hourly production from Overview page.
    /// </summary>
    public class ResourceParser : BaseHtmlParser
    {
        public Dictionary<string, int> ParseHourlyProduction(string html)
        {
            var production = new Dictionary<string, int>();
            
            try
            {
                var options = RegexOptions.IgnoreCase | RegexOptions.Singleline;

                production["wood"] = ParseResourceProduction(html, "Odun", options);
                production["stone"] = ParseResourceProduction(html, "Kil", options);
                production["iron"] = ParseResourceProduction(html, "Demir", options);
            }
            catch
            {
                // Return empty dictionary on error
            }
            
            return production;
        }

        private int ParseResourceProduction(string html, string resourceName, RegexOptions options)
        {
            var pattern = $@"{resourceName}\s*</td>\s*<td[^>]*>\s*<strong>\s*(\d+)\s*</strong>\s*saat başına";
            var match = Regex.Match(html, pattern, options);
            
            return match.Success ? int.Parse(match.Groups[1].Value) : 0;
        }
    }
}
