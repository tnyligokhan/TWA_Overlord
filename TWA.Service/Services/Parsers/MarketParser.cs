using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using TWA.Core.Entities;

namespace TWA.Service.Services.Parsers
{
    public class MarketParser : BaseHtmlParser
    {
        public List<TradeOffer> ParseTradeOffers(string html)
        {
            var offers = new List<TradeOffer>();
            var doc = LoadHtml(html);

            // Look for table with offers
            // Rows usually have an input with id starting with "id_" or similar structure
            var rows = doc.DocumentNode.SelectNodes("//table//tr[.//input[contains(@name, 'id_')]]");
            if (rows == null) return offers;

            foreach (var row in rows)
            {
                try
                {
                    var offer = new TradeOffer();
                    
                    // ID
                    var input = row.SelectSingleNode(".//input[contains(@name, 'id_')]");
                    if (input != null) offer.OfferId = input.GetAttributeValue("value", "");

                    // Player
                    var playerLink = row.SelectSingleNode(".//a[contains(@href, 'screen=info_player')]");
                    if (playerLink != null) offer.PlayerName = playerLink.InnerText.Trim();

                    // Resources - usually in cells with icons
                    // Detecting what is being offered vs asked is tricky without exact layout
                    // Assuming columns: Offer | Ask | Ratio | Duration
                    
                    // Allow simple parsing for now
                    
                    offers.Add(offer);
                }
                catch { }
            }

            return offers;
        }

        public int ParseAvailableMerchants(string html)
        {
            var doc = LoadHtml(html);
            
            // Try specific element if possible
            // <span class="traders">10/110</span> context
            var merchantsNode = doc.DocumentNode.SelectSingleNode("//*[contains(text(), 'Tüccar') or contains(text(), 'Merchants')]");
            if (merchantsNode != null)
            {
                var match = Regex.Match(merchantsNode.InnerText, @"(\d+)/(\d+)");
                if (match.Success) return int.Parse(match.Groups[1].Value);
            }
            
            // Try finding "10/110" pattern near "Tüccar"
            var text = doc.DocumentNode.InnerText;
            var merchantMatch = Regex.Match(text, @"Tüccarlar:\s*(\d+)/(\d+)");
            if (merchantMatch.Success) return int.Parse(merchantMatch.Groups[1].Value);

            return 0;
        }

        public int ParseTotalMerchants(string html)
        {
            var doc = LoadHtml(html);
            var text = doc.DocumentNode.InnerText;
            var merchantMatch = Regex.Match(text, @"Tüccarlar:\s*(\d+)/(\d+)");
            if (merchantMatch.Success) return int.Parse(merchantMatch.Groups[2].Value);
            return 0;
        }
    }
}
