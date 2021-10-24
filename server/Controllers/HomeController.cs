using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using server.Hubs;

namespace server.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        private readonly IHubContext<TestHub> _hub;
        private readonly HubWorker _hubWorker;

        public HomeController(IHubContext<TestHub> hub,
            HubWorker hubWorker)
        {
            _hub = hub;
            _hubWorker = hubWorker;
        }

        [HttpGet("toggle")]
        public async Task<IActionResult> ToggleAsync()
        {
            return Ok("Sent.");
        }
    }
}