using System;
using System.Threading.Tasks;

namespace TWA.Core.Interfaces.Services
{
    public interface ISignalRService
    {
        Task ConnectAsync(string hubUrl);
        Task DisconnectAsync();
        Task SendAsync(string methodName, params object[] args);
        bool IsConnected { get; }
    }
}
