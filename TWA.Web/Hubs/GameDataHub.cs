using Microsoft.AspNetCore.SignalR;
using TWA.Core.DTOs;

namespace TWA.Web.Hubs
{
    public class GameDataHub : Hub
    {
        public async Task BroadcastVillageUpdate(VillageSyncDto data)
        {
            await Clients.All.SendAsync("VillageUpdated", data);
        }

        public async Task BroadcastResourceUpdate(int villageId, int wood, int stone, int iron)
        {
            await Clients.All.SendAsync("ResourcesUpdated", new { villageId, wood, stone, iron });
        }

        public async Task BroadcastBuildingProgress(int villageId, string buildingName, int progress)
        {
            await Clients.All.SendAsync("BuildingProgressUpdated", new { villageId, buildingName, progress });
        }

        public async Task BroadcastAttackStatus(int attackId, string status, DateTime? arrivalTime)
        {
            await Clients.All.SendAsync("AttackStatusUpdated", new { attackId, status, arrivalTime });
        }

        public async Task BroadcastTroopUpdate(int villageId, object troops)
        {
            await Clients.All.SendAsync("TroopsUpdated", new { villageId, troops });
        }

        public async Task BroadcastEconomyUpdate(object economyData)
        {
            await Clients.All.SendAsync("EconomyUpdated", economyData);
        }

        public async Task BroadcastMapUpdate(object mapData)
        {
            await Clients.All.SendAsync("MapUpdated", mapData);
        }
    }
}
