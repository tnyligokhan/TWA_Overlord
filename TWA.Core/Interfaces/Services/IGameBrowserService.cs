namespace TWA.Core.Interfaces.Services
{
    public interface IGameBrowserService
    {
        // Oyuna giriş yapar
        // Oyuna giriş yapar - Başarılı mı döndürür
        Task<bool> LoginAsync();
        
        // Belirtilen sayfaya gider ve HTML içeriğini getirir
        Task<string> GetPageContentAsync(string screen);

        // Belirli bir binaya gider
        Task NavigateToBuilding(string buildingName);
        
        // Bir input alanına insan gibi yazar
        Task TypeHumanLike(string selector, string text);
        
        // Bir butona tıklar (Örn: Saldırı onayı)
        Task ClickButtonAsync(string selector);
        
        // Tarayıcıyı kapatır
        Task CloseAsync();

        // Gelen saldırı var mı diye hızlıca bak
        Task<bool> CheckIncomingAttacksAsync();

        // Binanın maliyeti kaynaklarla karşılanabilir mi?
        Task<bool> CanAffordBuilding(string buildingId);

        // İçtima Meydanına Git
        Task NavigateToPlace();

        // Asker sayılarını forma doldur
        Task FillTroops(TWA.Core.Entities.TroopSet troops);
    }
}
