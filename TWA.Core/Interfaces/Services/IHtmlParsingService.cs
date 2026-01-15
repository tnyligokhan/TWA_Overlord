using System.Collections.Generic;
using TWA.Core.DTOs;

namespace TWA.Core.Interfaces.Services
{
    public interface IHtmlParsingService
    {
        string ExtractText(string html, string xpath);
        List<string> ExtractTexts(string html, string xpath);
        string ExtractAttribute(string html, string xpath, string attributeName);
        List<string> ExtractAttributes(string html, string xpath, string attributeName);
        Dictionary<string, int> ParseBuildingLevels(string html);
        List<BuildQueueItem> ParseBuildQueue(string html);
        List<RecruitmentQueueItem> ParseRecruitmentQueue(string html, string buildingType);
        Dictionary<string, int> ParseResearchLevels(string html);
    }
}
