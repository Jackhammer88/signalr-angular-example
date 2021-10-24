using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using server.Hubs;

namespace server
{
    public class HubWorker
    {
        private readonly IHubContext<TestHub> _hub;

        public HubWorker(IHubContext<TestHub> hub)
        {
            _hub = hub;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(5000);
            while (!cancellationToken.IsCancellationRequested)
            {
                await Task.Delay(1000);            
                await _hub.Clients.All.SendCoreAsync("send", 
                    new[] { DateTime.Now.ToString("T") });
            }
        }
    }
}