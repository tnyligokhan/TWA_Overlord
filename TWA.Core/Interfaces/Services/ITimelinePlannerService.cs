using System.Collections.Generic;
using System.Threading.Tasks;
using TWA.Core.Entities;

namespace TWA.Core.Interfaces.Services
{
    public interface ITimelinePlannerService
    {
        Task DistributeTasksForDayAsync(int villageId, List<DailyTask> tasks);
    }
}
