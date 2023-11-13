using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Route("[controller]")]
    public class WebHookController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Events() =>
            Ok();

        [HttpGet("[action]")]
        public IActionResult Criticality() =>
            Ok();

        [HttpPost("[action]")]
        public IActionResult Subscribe() =>
            Ok();
    }
}
