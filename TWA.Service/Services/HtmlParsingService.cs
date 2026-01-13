using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using TWA.Core.Interfaces.Services;

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
    }
}
