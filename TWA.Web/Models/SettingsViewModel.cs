namespace TWA.Web.Models
{
    public class SettingsViewModel
    {
        public GameSettings GameSettings { get; set; } = new GameSettings();
        public BotSettings BotSettings { get; set; } = new BotSettings();
    }

    public class GameSettings
    {
        public bool AutoSync { get; set; }
        public int SyncInterval { get; set; } // seconds
        public bool AutoBuild { get; set; }
        public bool AutoRecruit { get; set; }
        public bool NotificationsEnabled { get; set; }
    }

    public class BotSettings
    {
        public bool IsActive { get; set; }
        public int MaxConcurrentTasks { get; set; }
        public int DelayBetweenActions { get; set; } // milliseconds
        public bool RandomizeDelay { get; set; }
        public bool SafeMode { get; set; }
    }
}
