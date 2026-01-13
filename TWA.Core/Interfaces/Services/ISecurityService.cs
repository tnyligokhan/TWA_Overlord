namespace TWA.Core.Interfaces.Services
{
    public interface ISecurityService
    {
        // Şu an işlem yapabilir miyim? (Uyku modu kontrolü)
        bool CanOperateNow();
        
        // Bir işlemden sonra ne kadar beklemeliyim? (İnsan simülasyonu)
        int GetActionDelay(); 
        
        // Tıklama gecikmesi (Milisaniye)
        int GetClickDelay();

        // Kasıtlı Hata: Hedeflenen zamana "Şişman Parmak" gecikmesi ekler
        DateTime ApplyHumanError(DateTime targetTime);
    }
}
