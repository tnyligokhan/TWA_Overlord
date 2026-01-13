using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Managers
{
    public class TroopManager
    {
        private readonly IGameBrowserService _browser;

        public TroopManager(IGameBrowserService browser)
        {
            _browser = browser;
        }

        // Şablonu Uygula
        public async Task RecruitByTemplateAsync(Village village)
        {
            // 1. Köyün Moduna Göre Hedef Şablonu Al
            if (!TroopTemplate.Defaults.ContainsKey(village.Mode)) return; // Şablon yoksa çık
            var template = TroopTemplate.Defaults[village.Mode]; 

            // troops null check
            if (village.OwnedTroops == null) village.OwnedTroops = new TroopSet();

            // 2. Eksikleri Hesapla
            int needSpear = template.Spear - village.OwnedTroops.Spear;
            int needSword = template.Sword - village.OwnedTroops.Sword;
            int needAxe = template.Axe - village.OwnedTroops.Axe;
            
            // Diğer birimler eklenebilir (Archer, Spy, Light, etc.)
            // Şimdilik ana birimler üzerinden gidelim, gerekirse genişletilir.

            // Eğer eksik yoksa çık
            if (needSpear <= 0 && needSword <= 0 && needAxe <= 0) return;

            // 3. Kışlaya Git
            await _browser.NavigateToBuilding("barracks");

            // 4. Kaynak Kontrolü ve Basım (Playwright ile input doldurma)
            // Burada Humanizer devreye girer: Sayıları yavaş yavaş yazar.
            
            if (needSpear > 0) 
                await _browser.TypeHumanLike("input[name='spear']", CalculateAffordable(needSpear, village, "spear").ToString());
            
            if (needSword > 0) 
                await _browser.TypeHumanLike("input[name='sword']", CalculateAffordable(needSword, village, "sword").ToString());

            if (needAxe > 0) 
                await _browser.TypeHumanLike("input[name='axe']", CalculateAffordable(needAxe, village, "axe").ToString());

            // 5. Butona Tıkla
             // Tribal Wars'da genelde recruit butonu class'ı veya name'i değişebilir.
             // Genelde "btn-recruit" veya input type="submit" olur.
             // Selector'ı genişletmek gerekebilir.
            try {
                await _browser.ClickButtonAsync(".btn-recruit"); 
            } catch {
                // Alternatif buton
                await _browser.ClickButtonAsync("input[type='submit']");
            }
        }

        // Param yetiyor mu kontrolü
        private int CalculateAffordable(int needed, Village v, string unit)
        {
            // Basit matematik: Kaynak yetiyorsa needed döndür, yetmiyorsa basabildiğin kadarını döndür.
            // Bu kısım kaynak maliyetlerine göre hesaplanır.
            // Basitlik adına şimdilik needed dönüyor.
            // Gerçek versiyonda Resources kontrolü yapılmalı.
            return needed; 
        }
    }
}
