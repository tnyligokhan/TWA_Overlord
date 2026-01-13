using TWA.Core.Interfaces;
using TWA.Core.Interfaces.Services;
using TWA.Core.Entities;

namespace TWA.Service.Services
{
    public class EmergencyService : IEmergencyService
    {
        // Singleton gibi davranması için bu değişken static olmalı
        // IUnitOfWork Scoped olduğu için bu sınıfı Singleton yapamayız, ancak static alan ile durumu koruyabiliriz.
        private static bool _isKillSwitchActive = false;
        private readonly IUnitOfWork _unitOfWork;

        public EmergencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void TriggerKillSwitch()
        {
            _isKillSwitchActive = true;
            // Burada log atılabilir veya bildirim gönderilebilir
        }

        public void RevokeKillSwitch()
        {
            _isKillSwitchActive = false;
        }

        public bool IsSystemLocked()
        {
            return _isKillSwitchActive;
        }

        public async Task TriggerMassMilitiaAsync()
        {
            if (_isKillSwitchActive) return; // Sistem kilitliyse işlem yapma

            var villages = await _unitOfWork.Repository<Village>().GetAllAsync();
            foreach (var v in villages)
            {
                // Milis çağırma simülasyonu
                // Gerçekte burada oyunun API'sine istek atılır
                v.OwnedTroops.Militia += 300; 
                _unitOfWork.Repository<Village>().Update(v);
            }
            await _unitOfWork.CommitAsync();
        }
    }
}
