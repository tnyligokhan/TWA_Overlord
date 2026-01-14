namespace TWA.Core.Configuration
{
    /// <summary>
    /// Tribal Wars DOM selectors and JavaScript paths for data extraction
    /// Based on current game structure - update if game changes
    /// </summary>
    public static class TechnicalSelectors
    {
        // Global Data - Accessible via game_data JavaScript object
        public static class GlobalData
        {
            public const string Wood_Selector = "#wood";
            public const string Wood_JS = "game_data.village.wood";
            
            public const string Stone_Selector = "#stone";
            public const string Stone_JS = "game_data.village.stone";
            
            public const string Iron_Selector = "#iron";
            public const string Iron_JS = "game_data.village.iron";
            
            public const string StorageMax_Selector = "#storage";
            public const string StorageMax_JS = "game_data.village.storage_max";
            
            public const string PopCurrent_Selector = "#pop_current_label";
            public const string PopCurrent_JS = "game_data.village.pop";
            
            public const string PopMax_Selector = "#pop_max_label";
            public const string PopMax_JS = "game_data.village.pop_max";
            
            public const string IncomingAttacks_Selector = "#incomings_amount";
            public const string IncomingAttacks_JS = "game_data.player.incomings";
            
            public const string VillageId_JS = "game_data.village.id";
            public const string VillageName_JS = "game_data.village.name";
            public const string VillageX_JS = "game_data.village.x";
            public const string VillageY_JS = "game_data.village.y";
            public const string VillagePoints_JS = "game_data.village.points";
        }
        
        // Buildings
        public static class Buildings
        {
            public const string UrlSuffix = "screen=main";
            public const string QueueContainer = "#build_queue .buildorder_eri";
            public const string BuildBtnPattern = ".btn-build[data-building='{0}']";
            public const string LevelPattern = ".main_buildrow[data-building='{0}'] .level";
            
            public static readonly string[] BuildingIds = 
            {
                "main", "barracks", "stable", "garage", "snob", 
                "smith", "place", "market", "wall", "farm", "storage"
            };
        }
        
        // Recruitment
        public static class Recruitment
        {
            public const string UrlSuffix = "screen=train";
            public const string InputPattern = "input[name='{0}']";
            public const string RecruitBtn = ".btn-recruit";
            public const string QueueContainer = ".train_queue_wrap";
            
            public static readonly string[] Units = 
            {
                "spear", "sword", "axe", "spy", "light", 
                "heavy", "ram", "catapult", "knight", "snob"
            };
        }
        
        // Unit Overview (Troop Counts)
        public static class UnitOverview
        {
            public const string UrlSuffix = "screen=overview";
            public const string TableId = "#unit_overview_table";
            
            // Selector pattern: strong[data-count='spear']
            public const string CountPattern = "strong[data-count='{0}']";
            
            // All units row class
            public const string AllUnitsRow = ".all_unit";
            
            // Home units row class (units in village)
            public const string HomeUnitsRow = ".home_unit";
            
            // Individual unit selectors
            public const string SpearCount = "strong[data-count='spear']";
            public const string SwordCount = "strong[data-count='sword']";
            public const string AxeCount = "strong[data-count='axe']";
            public const string SpyCount = "strong[data-count='spy']";
            public const string LightCount = "strong[data-count='light']";
            public const string HeavyCount = "strong[data-count='heavy']";
            public const string RamCount = "strong[data-count='ram']";
            public const string CatapultCount = "strong[data-count='catapult']";
            public const string KnightCount = "strong[data-count='knight']";
            public const string SnobCount = "strong[data-count='snob']";
        }
        
        // Warfare (Place)
        public static class Warfare
        {
            public const string UrlSuffix = "screen=place";
            public const string InputX = "input[name='x']";
            public const string InputY = "input[name='y']";
            public const string BtnAttack = "#target_attack";
            public const string BtnSupport = "#target_support";
            public const string BtnConfirm = "#troop_confirm_submit";
            public const string ArrivalTimeDisplay = "#date_arrival";
            
            // Troop counts from place screen (data-all-count attribute)
            public const string SpearInput = "input[name='spear']";
            public const string SwordInput = "input[name='sword']";
            public const string AxeInput = "input[name='axe']";
            public const string SpyInput = "input[name='spy']";
            public const string LightInput = "input[name='light']";
            public const string HeavyInput = "input[name='heavy']";
            public const string RamInput = "input[name='ram']";
            public const string CatapultInput = "input[name='catapult']";
            public const string KnightInput = "input[name='knight']";
            public const string SnobInput = "input[name='snob']";
        }
        
        // Market
        public static class Market
        {
            public const string UrlSuffix = "screen=market&mode=send";
            public const string AvailableMerchants = "#market_merchant_available_count";
            public const string InputWood = "input[name='wood']";
            public const string InputStone = "input[name='stone']";
            public const string InputIron = "input[name='iron']";
            public const string BtnSend = ".btn-target-action";
            public const string BtnConfirm = ".btn-confirm-yes";
        }
        
        // Minting (Academy)
        public static class Minting
        {
            public const string UrlSuffix = "screen=snob&mode=coin";
            public const string MaxLink = "#coin_mint_fill_max";
            public const string InputCount = "input[name='coin_count']";
            public const string BtnMint = ".btn-mint";
        }
        
        // Reports
        public static class Reports
        {
            public const string UrlSuffix = "screen=report&mode=all";
            public const string Row = "tr.report-link";
            public const string UnreadClass = "unread";
            public const string StatusDot = "img[src*='graphic/dots/']";
            public const string LootIcon = "img[src*='graphic/max_loot/']";
        }
        
        // Map Data (JavaScript objects)
        public static class Map
        {
            public const string Villages_JS = "TWMap.villages";
            public const string Players_JS = "TWMap.players";
            public const string SpawnSector_JS = "TWMap.mapHandler.spawnSector({0}, {1})";
        }
    }
}
