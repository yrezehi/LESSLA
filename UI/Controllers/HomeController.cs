using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly EventLogsService Service;
        private readonly InsightfulAnalysisService AnalysisService;

        public HomeController(EventLogsService service, InsightfulAnalysisService analysisService) =>
            (Service, AnalysisService) = (service, analysisService);

        public async Task<IActionResult> Index() =>
            View(await AnalysisService.Brief());

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}