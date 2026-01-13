namespace TWA.Core.Interfaces.Services
{
    public interface IEmergencyService
    {
        // Sistemi kilitler (Tüm background servisler durur)
        void TriggerKillSwitch();
        
        // Sistemi tekrar açar
        void RevokeKillSwitch();
        
        // Sistem kilitli mi?
        bool IsSystemLocked();

        // Tüm köylerde milis çağır (Acil Savunma)
        Task TriggerMassMilitiaAsync();
    }
}
