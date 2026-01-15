using System;
using TWA.Service.Services.Parsers;
using HtmlAgilityPack;

namespace TWA.Service.Services.Parsers
{
    public class KnightParser : BaseHtmlParser
    {
        public string ParseKnightName(string html)
        {
            var doc = LoadHtml(html);
            var input = doc.DocumentNode.SelectSingleNode("//input[@name='knights_name']");
            return input?.GetAttributeValue("value", "") ?? "";
        }

        public bool IsKnightInVillage(string html)
        {
             // Check for text "Şövalye bu köyde" or similar
             return html.Contains("bu köyde"); // Simplified check
        }
    }
}
