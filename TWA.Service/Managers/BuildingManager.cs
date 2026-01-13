using System;
using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Managers
{
    public class BuildingManager
    {
        private readonly IGameBrowserService _browser;

        public BuildingManager(IGameBrowserService browser)
        {
            _browser = browser;
        }

        public async Task BuildNextAsync(Village village, string buildingId)
        {
            await _browser.NavigateToBuilding("main");

            // Kaynak Yeterli mi?
            // (Playwright ile sayfadaki "wood", "stone", "iron" maliyetlerini oku)
            bool canBuild = await _browser.CanAffordBuilding(buildingId);

            if (canBuild)
            {
                // İnşaat Emri Ver
                // Playwright Selector Örn: #main_buildrow_iron .btn-build
                // Selector'ı daha spesifik hale getirdim: data-building attribute'u varsaydım.
                // Eğer çalışmazsa "#main_buildrow_" + buildingId + " .btn-build" denenebilir.
                try {
                     await _browser.ClickButtonAsync($"#main_buildrow_{buildingId} .btn-build");
                     Console.WriteLine($"🏗️ İNŞAAT BAŞLADI: {buildingId} - Köy: {village.Name}");
                } catch {
                     // Alternatif selector
                     await _browser.ClickButtonAsync($".btn-build[data-building='{buildingId}']");
                }
            }
            else
            {
                Console.WriteLine($"⚠️ KAYNAK YETERSİZ: {buildingId} için bekleniyor.");
                // Bir sonraki kontrol için kaynak biriktirme moduna geçilebilir.
            }
        }
    }
}
