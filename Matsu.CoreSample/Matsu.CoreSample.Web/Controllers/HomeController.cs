using Matsu.CoreSample.Common;
using Matsu.CoreSample.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Matsu.CoreSample.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();

        }

        public string GetWorkFlowResults()
        {
            var api = new LogicAppsStandardWebApi();
            return api.CallHttpTrigger("https://la4standard.azurewebsites.net:443/api/WF-HTTPtrigger/triggers/manual/invoke?api-version=2022-05-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0", "tFJChuAq-AwUYqVJIOrtFrsGlQcqG7QA3JiXE6YhB0c").Result.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}