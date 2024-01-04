using Core.Models.Health;
using Core.Services.Health;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UI.Controllers.Abstracts;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class HealthController : BaseController<HealthService, HealthCheckRegistry>
    {
        public HealthController(HealthService Service) : base(Service) { }

        [HttpGet("[action]")]
        public IActionResult Index() =>
            View();
    }
}
