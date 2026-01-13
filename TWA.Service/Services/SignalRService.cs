using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using TWA.Core.Interfaces.Services;

namespace TWA.Service.Services
{
    public class SignalRService : ISignalRService
    {
        private HubConnection? _hubConnection;

        public bool IsConnected => _hubConnection?.State == HubConnectionState.Connected;

        public async Task ConnectAsync(string hubUrl)
        {
            _hubConnection = new HubConnectionBuilder()
                .WithUrl(hubUrl)
                .WithAutomaticReconnect()
                .Build();

            await _hubConnection.StartAsync();
        }

        public async Task DisconnectAsync()
        {
            if (_hubConnection != null)
            {
                await _hubConnection.StopAsync();
                await _hubConnection.DisposeAsync();
                _hubConnection = null;
            }
        }

        public async Task SendAsync(string methodName, params object[] args)
        {
            if (IsConnected)
            {
                await _hubConnection.InvokeCoreAsync(methodName, args);
            }
        }
    }
}
