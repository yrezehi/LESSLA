using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using UI.Controllers.Abstracts;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class LogsController : BaseController<EventLogsService, EventLog>
    {
        public LogsController(EventLogsService Service) : base(Service) { }

        public IActionResult Index() =>
            View();

        [HttpGet("[action]")]
        public IActionResult Live() =>
            View();
    }
}
