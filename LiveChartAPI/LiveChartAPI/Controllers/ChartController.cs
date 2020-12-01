using LiveChartAPI.HubConfig;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using LiveChartAPI.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiveChartAPI.DataAccess;

namespace LiveChartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartController : ControllerBase
    {
        private IHubContext<ChartHub> _hub;
        public ChartController(IHubContext<ChartHub> hub)
        {
            _hub = hub;
        }

        public IActionResult Get()
        {
            var timerManager = new TimerManager(() => _hub.Clients.All.SendAsync("transferchartdata", ChartRepository.GetData()));
            return Ok(new { Message = "Request Completed" });
        }
    }
}
