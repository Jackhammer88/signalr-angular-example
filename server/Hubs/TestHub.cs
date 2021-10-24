using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace server.Hubs
{
    public class TestHub : Hub
    {
        private readonly ILogger<TestHub> _logger;

        public TestHub(ILogger<TestHub> logger)
        {
            _logger = logger;
        }
        
        public override Task OnConnectedAsync()
        {
            _logger.LogInformation("Connected");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            _logger.LogInformation("Disconnect");
            return base.OnDisconnectedAsync(exception);
        }
    }
}