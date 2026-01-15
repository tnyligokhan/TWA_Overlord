# 🏗️ MODULAR PARSER ARCHITECTURE

## OVERVIEW

The data extraction system follows a **strict modular architecture** where each domain (Buildings, Troops, Research, Resources, Recruitment) has its own dedicated parser class. This ensures:

- **Single Responsibility:** Each parser handles ONE data type only
- **Zero Cross-Domain Dependencies:** Troop parser never touches building logic
- **Easy Testing:** Each parser can be tested independently
- **Scalability:** New parsers can be added without modifying existing code

---

## ARCHITECTURE DIAGRAM

```
┌─────────────────────────────────────────────────────────────┐
│                   HtmlParsingService                        │
│                      (Facade Pattern)                       │
│                                                             │
│  Delegates to specialized parsers:                         │
│  - BuildingParser  → ParseBuildingLevels()                 │
│  - TroopParser     → ParseTroopCounts()                    │
│  - RecruitmentParser → ParseRecruitmentQueue()             │
│  - ResearchParser  → ParseResearchLevels()                 │
│  - ResourceParser  → ParseHourlyProduction()               │
└─────────────────────────────────────────────────────────────┘
                            │
                            │ delegates to
                            ▼
┌──────────────────┬──────────────────┬──────────────────┬──────────────────┬──────────────────┐
│ BuildingParser   │  TroopParser     │ RecruitmentParser│ ResearchParser   │ ResourceParser   │
├──────────────────┼──────────────────┼──────────────────┼──────────────────┼──────────────────┤
│ - Building levels│ - Troop counts   │ - Barracks queue │ - Research levels│ - Hourly wood    │
│ - Build queue    │ - 10 unit types  │ - Stable queue   │ - 8 unit types   │ - Hourly stone   │
│                  │                  │ - Garage queue   │                  │ - Hourly iron    │
│                  │                  │ - Snob queue     │                  │                  │
└──────────────────┴──────────────────┴──────────────────┴──────────────────┴──────────────────┘
                            │
                            │ inherits from
                            ▼
                   ┌─────────────────────┐
                   │   BaseHtmlParser    │
                   │  (Protected Utils)  │
                   │                     │
                   │ - LoadHtml()        │
                   │ - ExtractText()     │
                   │ - ExtractAttribute()│
                   │ - SelectNodes()     │
                   └─────────────────────┘
```

---

## PARSER CLASSES

### 1. BaseHtmlParser (Abstract Base Class)
**Location:** `TWA.Service/Services/Parsers/BaseHtmlParser.cs`

**Purpose:** Provides shared utility methods for all parsers

**Methods:**
- `LoadHtml(string html)` → HtmlDocument
- `ExtractText(HtmlNode node, string xpath)` → string
- `ExtractAttribute(HtmlNode node, string xpath, string attributeName)` → string
- `SelectNodes(HtmlNode node, string xpath)` → List<HtmlNode>

**Access:** Protected (not exposed to external consumers)

---

### 2. BuildingParser
**Location:** `TWA.Service/Services/Parsers/BuildingParser.cs`

**Responsibility:** Parse building-related data from Main page

**Methods:**
- `ParseBuildingLevels(string html)` → Dictionary<string, int>
  - Extracts: main, barracks, stable, garage, snob, smith, statue, wood, stone, iron, farm, storage, wall
  - Pattern: `<tr id="main_buildrow_{type}">` → Regex `Seviye (\d+)`

- `ParseBuildQueue(string html)` → List<BuildQueueItem>
  - Extracts: Building type, current level, target level, start time, end time, is active
  - Pattern: `<tbody id="buildqueue">` → `buildorder_{type}` class + `data-endtime`

**Dependencies:** None (fully self-contained)

---

### 3. TroopParser
**Location:** `TWA.Service/Services/Parsers/TroopParser.cs`

**Responsibility:** Parse troop counts from Place page

**Methods:**
- `ParseTroopCounts(string html)` → Dictionary<string, int>
  - Extracts: spear, sword, axe, spy, light, heavy, ram, catapult, knight, snob
  - Pattern: `unit-item-{type}[^>]*>(\d+)<`

**Dependencies:** None (fully self-contained)

**Note:** This replaces the old `ParseTroopCount()` method that was incorrectly placed in VillageDataSyncService

---

### 4. RecruitmentParser
**Location:** `TWA.Service/Services/Parsers/RecruitmentParser.cs`

**Responsibility:** Parse recruitment queues from Train page

**Methods:**
- `ParseRecruitmentQueue(string html, string buildingType)` → List<RecruitmentQueueItem>
  - Extracts: Unit type, amount, start time, end time, is active
  - Pattern: `<tbody id="trainqueue_{building}">` → Active (class="lit") + Pending rows
  - Supports: barracks, stable, garage, snob

**Private Methods:**
- `ParseRecruitmentRow()` → Parses individual queue row
- `ParseTurkishDateTime()` → Converts "bugün saat HH:mm:ss" to DateTime

**Dependencies:** None (fully self-contained)

---

### 5. ResearchParser
**Location:** `TWA.Service/Services/Parsers/ResearchParser.cs`

**Responsibility:** Parse research levels from Smithy page

**Methods:**
- `ParseResearchLevels(string html)` → Dictionary<string, int>
  - Extracts: spear, sword, axe, spy, light, heavy, ram, catapult
  - Pattern: JavaScript `BuildingSmith.techs = {"available":{"unit":{"level":"X"}}}`
  - Two-step parsing: Extract entire techs object → Parse each unit block

**Dependencies:** None (fully self-contained)

---

### 6. ResourceParser
**Location:** `TWA.Service/Services/Parsers/ResourceParser.cs`

**Responsibility:** Parse hourly production from Overview page

**Methods:**
- `ParseHourlyProduction(string html)` → Dictionary<string, int>
  - Extracts: wood, stone, iron
  - Pattern: `{Resource}</td><td><strong>(\d+)</strong> saat başına`

**Private Methods:**
- `ParseResourceProduction()` → Parses single resource production

**Dependencies:** None (fully self-contained)

---

## INTERFACE DESIGN

### IHtmlParsingService
**Location:** `TWA.Core/Interfaces/Services/IHtmlParsingService.cs`

**Design Principles:**
- ❌ **NO generic methods** (ExtractText, ExtractAttribute removed)
- ✅ **Domain-specific methods only**
- ✅ **Clear separation by domain**

```csharp
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
}
```

---

## BENEFITS OF MODULAR ARCHITECTURE

### 1. SINGLE RESPONSIBILITY
- Each parser has ONE job
- BuildingParser never touches troop logic
- TroopParser never touches building logic
- Clear boundaries between domains

### 2. ZERO CROSS-DOMAIN DEPENDENCIES
- No shared state between parsers
- Each parser can be modified independently
- Bug in troop parsing doesn't affect building parsing

### 3. EASY TESTING
- Each parser can be unit tested independently
- Mock HTML for specific domain only
- No need to test entire parsing system for one domain

### 4. SCALABILITY
- Adding new parsers (Commands, Market, Reports) is trivial
- Just create new parser class inheriting from BaseHtmlParser
- Add method to HtmlParsingService facade
- No modifications to existing parsers

### 5. MAINTAINABILITY
- Clear file structure: `Parsers/BuildingParser.cs`, `Parsers/TroopParser.cs`
- Easy to find where specific parsing logic lives
- New developers can understand system quickly

---

## ADDING NEW PARSERS

To add a new parser (e.g., CommandParser):

1. **Create parser class:**
```csharp
// TWA.Service/Services/Parsers/CommandParser.cs
public class CommandParser : BaseHtmlParser
{
    public List<Command> ParseCommands(string html)
    {
        var doc = LoadHtml(html);
        // Parsing logic here
    }
}
```

2. **Add to HtmlParsingService:**
```csharp
private readonly CommandParser _commandParser;

public HtmlParsingService()
{
    _commandParser = new CommandParser();
    // ...
}

public List<Command> ParseCommands(string html)
{
    return _commandParser.ParseCommands(html);
}
```

3. **Add to interface:**
```csharp
public interface IHtmlParsingService
{
    // COMMAND DOMAIN
    List<Command> ParseCommands(string html);
}
```

**That's it!** No modifications to existing parsers needed.

---

## ANTI-PATTERNS AVOIDED

### ❌ BEFORE (Monolithic)
```csharp
public class HtmlParsingService
{
    // Generic methods exposed publicly
    public string ExtractText(string html, string xpath) { }
    public string ExtractAttribute(string html, string xpath, string attr) { }
    
    // All parsing logic in one giant class
    public Dictionary<string, int> ParseBuildingLevels(string html) { }
    public Dictionary<string, int> ParseTroopCounts(string html) { }
    // ... 500 lines of mixed logic
}

// Parsing logic scattered across services
public class VillageDataSyncService
{
    private int ParseTroopCount(string html, string unitType) { } // WRONG!
}
```

### ✅ AFTER (Modular)
```csharp
// Facade delegates to specialized parsers
public class HtmlParsingService
{
    private readonly BuildingParser _buildingParser;
    private readonly TroopParser _troopParser;
    
    public Dictionary<string, int> ParseBuildingLevels(string html)
        => _buildingParser.ParseBuildingLevels(html);
    
    public Dictionary<string, int> ParseTroopCounts(string html)
        => _troopParser.ParseTroopCounts(html);
}

// Each parser is self-contained
public class TroopParser : BaseHtmlParser
{
    public Dictionary<string, int> ParseTroopCounts(string html) { }
    private int ParseSingleTroopCount(string html, string unitType) { }
}
```

---

## SUMMARY

✅ **5 specialized parsers** (Building, Troop, Recruitment, Research, Resource)
✅ **Zero cross-domain dependencies**
✅ **Clean interface** (no generic methods)
✅ **Easy to extend** (add new parsers without touching existing code)
✅ **Easy to test** (each parser independently testable)
✅ **Clear file structure** (`Parsers/` folder with one file per domain)

**Result:** A maintainable, scalable, and testable parsing architecture that follows SOLID principles.
