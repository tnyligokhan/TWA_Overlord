using TWA.Core.Interfaces.Services;
using TWA.Core.DTOs;
using TWA.Core.Entities;
using TWA.Service.Services.Parsers;

namespace TWA.Service.Services
{
    /// <summary>
    /// Facade service that delegates to specialized modular parsers.
    /// Each parser handles a specific domain (Buildings, Troops, Research, etc.)
    /// </summary>
    public class HtmlParsingService : IHtmlParsingService
    {
        private readonly BuildingParser _buildingParser;
        private readonly TroopParser _troopParser;
        private readonly RecruitmentParser _recruitmentParser;
        private readonly ResearchParser _researchParser;
        private readonly ResourceParser _resourceParser;
        private readonly CommandParser _commandParser;
        private readonly MarketParser _marketParser;
        private readonly ReportParser _reportParser;
        private readonly KnightParser _knightParser;
        private readonly InventoryParser _inventoryParser;
        private readonly MapParser _mapParser;

        public HtmlParsingService()
        {
            _buildingParser = new BuildingParser();
            _troopParser = new TroopParser();
            _recruitmentParser = new RecruitmentParser();
            _researchParser = new ResearchParser();
            _resourceParser = new ResourceParser();
            _commandParser = new CommandParser();
            _marketParser = new MarketParser();
            _reportParser = new ReportParser();
            _knightParser = new KnightParser();
            _inventoryParser = new InventoryParser();
            _mapParser = new MapParser();
        }

        // BUILDING DOMAIN
        // BUILDING DOMAIN
        public Dictionary<string, int> ParseBuildingLevels(string html)
        {
            return _buildingParser.ParseBuildingLevels(html);
        }

        public List<BuildQueueItem> ParseBuildQueue(string html)
        {
            return _buildingParser.ParseBuildQueue(html);
        }

        // TROOP DOMAIN
        public Dictionary<string, int> ParseTroopCounts(string html)
        {
            return _troopParser.ParseTroopCounts(html);
        }

        // RECRUITMENT DOMAIN
        public List<RecruitmentQueueItem> ParseRecruitmentQueue(string html, string buildingType)
        {
            return _recruitmentParser.ParseRecruitmentQueue(html, buildingType);
        }

        // RESEARCH DOMAIN
        public Dictionary<string, int> ParseResearchLevels(string html)
        {
            return _researchParser.ParseResearchLevels(html);
        }

        // RESOURCE DOMAIN
        public Dictionary<string, int> ParseHourlyProduction(string html)
        {
            return _resourceParser.ParseHourlyProduction(html);
        }

        // COMMAND DOMAIN
        public List<Command> ParseCommands(string html)
        {
            return _commandParser.ParseCommands(html);
        }

        // MARKET DOMAIN
        public List<TradeOffer> ParseTradeOffers(string html)
        {
            return _marketParser.ParseTradeOffers(html);
        }

        public int ParseAvailableMerchants(string html)
        {
            return _marketParser.ParseAvailableMerchants(html);
        }

        public int ParseTotalMerchants(string html)
        {
            return _marketParser.ParseTotalMerchants(html);
        }

        // REPORT DOMAIN
        public List<Report> ParseReports(string html)
        {
            return _reportParser.ParseReports(html);
        }

        public Report ParseReportDetail(string html)
        {
            return _reportParser.ParseReportDetail(html);
        }

        // KNIGHT DOMAIN
        public string ParseKnightName(string html)
        {
            return _knightParser.ParseKnightName(html);
        }

        public bool IsKnightInVillage(string html)
        {
             return _knightParser.IsKnightInVillage(html);
        }
        

        
        // INVENTORY DOMAIN (Placeholder)
        public List<InventoryItem> ParseInventory(string html)
        {
             return _inventoryParser.ParseInventory(html);
        }

        public Dictionary<string, int> ParseFlags(string html)
        {
             return _inventoryParser.ParseFlags(html);
        }

        // MAP DOMAIN
        public List<MapSectorDto> ParseMapData(string html)
        {
            return _mapParser.ParseMapData(html);
        }
    }
}
