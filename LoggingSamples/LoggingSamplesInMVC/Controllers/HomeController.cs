using LoggingSamplesInMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LoggingSamplesInMVC.Controllers
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

            _logger.LogInformation("Sie besuchen die Index-Seite");
            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Sie besuchen die Privacy-Seite");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}