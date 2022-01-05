using Microsoft.AspNetCore.Mvc;
using StateManagementMVC.Models;
using System.Diagnostics;
using System.Text.Json;

namespace StateManagementMVC.Controllers
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

        public IActionResult Privacy()
        {
            string jsonString = HttpContext.Session.GetString("PersonObj");
            Person person = JsonSerializer.Deserialize<Person>(jsonString);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}