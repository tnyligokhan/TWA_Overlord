using System.Collections.Generic;

namespace TWA.Core.Interfaces.Services
{
    public interface IHtmlParsingService
    {
        string ExtractText(string html, string xpath);
        List<string> ExtractTexts(string html, string xpath);
        string ExtractAttribute(string html, string xpath, string attributeName);
        List<string> ExtractAttributes(string html, string xpath, string attributeName);
    }
}
