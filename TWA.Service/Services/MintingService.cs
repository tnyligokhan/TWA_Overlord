using System;
using System.Linq;
using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class MintingService
    {
        private readonly IGameBrowserService _browser;
        private readonly IRepository<Village> _repo;

        public MintingService(IGameBrowserService browser, IRepository<Village> repo)
        {
            _browser = browser;
            _repo = repo;
        }

        public async Task AutoMintCoinsAsync()
        {
            // Sadece Akademisi (Snob) olan köyleri bul
            // Repository FindAsync expression desteği var
            var academyVillages = await _repo.FindAsync(v => v.BuildingSnob > 0);

            foreach (var village in academyVillages)
            {
                // Eğer "SAVE" modundaysa (asker için biriktiriyorsa) altın basma
                if (village.AiAction == "SAVE") continue;

                await _browser.NavigateToBuilding("snob"); // Akademiye git

                // Sayfadaki "Maksimum Basılabilecek Altın" sayısını oku
                int maxMintable = await _browser.GetMaxMintableCoinsAsync();

                if (maxMintable > 0)
                {
                    // Depoyu tamamen kurutma, %10 rezerv bırak (veya maliyet hesabı yapmadan direkt 90% bas)
                    // Altın basmak 28k/30k/25k ister. Max basılabilir sayı zaten kaynaklara göre hesaplanır.
                    // %90'ını basmak mantıklı.
                    int coinsToMint = (int)(maxMintable * 0.9);
                    
                    if (coinsToMint > 0)
                    {
                        await _browser.TypeHumanLike("input[name='coin_count']", coinsToMint.ToString());
                        await _browser.ClickButtonAsync(".btn-mint"); // veya oyunun kendi butonu
                        Console.WriteLine($"💰 DARPHANE: {village.Name} köyünde {coinsToMint} altın basıldı.");
                    }
                }
            }
        }
    }
}
