using System.Collections.Generic;
using TWA.Core.DTOs;
using TWA.Core.Entities;

namespace TWA.Core.Interfaces.Services
{
    /// <summary>
    /// Interface for HTML parsing service.
    /// Each method is dedicated to a specific domain (Buildings, Troops, Research, etc.)
    /// No generic extraction methods - each parser is self-contained.
    /// </summary>
    public interface IHtmlParsingService
    {
        // BUILDING DOMAIN
        Dictionary<string, int> ParseBuildingLevels(string html);
        List<BuildQueueItem> ParseBuildQueue(string html);
        
        // TROOP DOMAIN
        Dictionary<string, int> ParseTroopCounts(string html);
        
        // RECRUITMENT DOMAIN
        List<RecruitmentQueueItem> ParseRecruitmentQueue(string html, string buildingType);
        
        // RESEARCH DOMAIN
        Dictionary<string, int> ParseResearchLevels(string html);
        
        // RESOURCE DOMAIN
        Dictionary<string, int> ParseHourlyProduction(string html);

        // COMMAND DOMAIN
        List<Command> ParseCommands(string html);

        // MARKET DOMAIN
        List<TradeOffer> ParseTradeOffers(string html);
        int ParseAvailableMerchants(string html);
        int ParseTotalMerchants(string html);

        // REPORT DOMAIN
        List<Report> ParseReports(string html);
        Report ParseReportDetail(string html);

        // KNIGHT DOMAIN
        string ParseKnightName(string html);
        bool IsKnightInVillage(string html);

        // INVENTORY DOMAIN
        List<InventoryItem> ParseInventory(string html);
        Dictionary<string, int> ParseFlags(string html);

        // MAP DOMAIN
        List<MapSectorDto> ParseMapData(string html);
    }
}
