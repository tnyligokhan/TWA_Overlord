using HtmlAgilityPack;

namespace TWA.Service.Services.Parsers
{
    /// <summary>
    /// Base class for all HTML parsers with shared utility methods.
    /// These utilities are protected - not exposed to external consumers.
    /// </summary>
    public abstract class BaseHtmlParser
    {
        protected HtmlDocument LoadHtml(string html)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            return doc;
        }

        protected string ExtractText(HtmlNode node, string xpath)
        {
            return node?.SelectSingleNode(xpath)?.InnerText?.Trim() ?? string.Empty;
        }

        protected string ExtractAttribute(HtmlNode node, string xpath, string attributeName)
        {
            return node?.SelectSingleNode(xpath)?.GetAttributeValue(attributeName, string.Empty) ?? string.Empty;
        }

        protected List<HtmlNode> SelectNodes(HtmlNode node, string xpath)
        {
            return node?.SelectNodes(xpath)?.ToList() ?? new List<HtmlNode>();
        }
    }
}
