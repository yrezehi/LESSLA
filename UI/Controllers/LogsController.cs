using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class LogsController : Controller
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> Index() =>
            Ok();
    }
}
