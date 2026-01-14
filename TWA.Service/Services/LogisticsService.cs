using System;
using System.Linq;
using System.Threading.Tasks;
using TWA.Core.Entities;
using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class LogisticsService
    {
        private readonly IWarfareService _warfare;
        private readonly IRepository<Village> _repo;

        public LogisticsService(IWarfareService warfare, IRepository<Village> repo)
        {
            _warfare = warfare;
            _repo = repo;
        }

        public async Task BalanceResourcesAsync()
        {
            var allVillages = await _repo.GetAllAsync();
            
            // 1. İHTİYAÇ SAHİPLERİ (Deposu %30 altı veya İnşaat bekleyenler)
            var receivers = allVillages.Where(v => v.NeedsResources()).ToList();

            // 2. BAĞIŞÇILAR (Deposu %80 üstü ve AI "SAVE" modunda olmayanlar)
            var donors = allVillages.Where(v => v.HasExcessResources() && v.AiAction != "SAVE").ToList();

            Console.WriteLine($"📊 LOJİSTİK ANALİZ: {receivers.Count} Alıcı, {donors.Count} Bağışçı bulundu.");

            foreach (var receiver in receivers)
            {
                // En yakın bağışçıyı bul (Nearest Neighbor)
                var bestDonor = donors
                    .OrderBy(d => d.DistanceTo(receiver.X, receiver.Y))
                    .FirstOrDefault();

                if (bestDonor != null)
                {
                    // Ne kadar lazım?
                    int amountToSend = 10000; // Örnek sabit miktar
                    
                    // Basit hesap: Her tüccar 1000 taşır (Dünya ayarına göre değişir)
                    int merchantCapacity = 1000;
                    int merchantsNeeded = amountToSend / merchantCapacity;

                    if (bestDonor.AvailableMerchants >= merchantsNeeded)
                    {
                        await _warfare.SendResourcesAsync(new TransportCommand
                        {
                            SourceId = bestDonor.Id,
                            TargetX = receiver.X,
                            TargetY = receiver.Y,
                            Wood = amountToSend,
                            Stone = amountToSend,
                            Iron = amountToSend
                        });

                        // Donör listesini güncelle (Simülasyon - gerçek güncelleme bir sonraki veri çekme döngüsünde olur)
                        bestDonor.Wood -= amountToSend; 
                        bestDonor.Stone -= amountToSend; 
                        bestDonor.Iron -= amountToSend; 
                        bestDonor.AvailableMerchants -= merchantsNeeded;
                        
                        // Donör artık kaynak veremeyebilir, listeden çıkarma veya puanını düşürme mantığı eklenebilir
                        // Şimdilik basit bırakıyoruz.
                    }
                }
            }
        }
    }
}
