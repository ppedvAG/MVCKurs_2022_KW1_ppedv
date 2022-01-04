using Microsoft.AspNetCore.Mvc;
using RazorSamples.Models;
using System.Diagnostics;

namespace RazorSamples.Controllers
{

    // Controller-Klasse:
    // - Datenbahnautobahn zwischen View und Data-Layer
    //    - Validierung
    // - Navigation

    // Ein Controller hat mehrere Views
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(); // IActionResult -> View()
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