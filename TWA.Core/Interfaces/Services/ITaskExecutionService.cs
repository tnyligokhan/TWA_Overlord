using System.Threading.Tasks;
using TWA.Core.Entities;

namespace TWA.Core.Interfaces.Services
{
    public interface ITaskExecutionService
    {
        Task ExecuteOperationAsync(ScheduledOperation operation);
    }
}
