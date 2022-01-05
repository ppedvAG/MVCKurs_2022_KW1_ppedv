using Microsoft.AspNetCore.Mvc;
using StateManagementMVC.Models;
using System.Text.Json;

namespace StateManagementMVC.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult ViewDataSample()
        {
            //ViewData -> Einmal Nachricht 
            //Nachricht wird an die View übertragen


            //Einschränkungen: -> ViewData kann nur an die Views übertragen, die zu diesem Controller gehören

            ViewData["MessageA"] = "Hallo liebe Teilnehmer";
            ViewData["MessageB"] = "MVC macht Spass";


            return View(/*Datensatz-Struktur kann man hier übergeben*/);
        }

        public IActionResult ViewBagSample()
        {
            //ViewData -> Einmal Nachricht 
            //Nachricht wird an die View übertragen


            //Einschränkungen: -> ViewData kann nur an die Views übertragen, die zu diesem Controller gehören
            ViewBag.MessageC = "Hallo liebe Teilnehmer :-)";
            ViewBag.MessageD = "MVC macht Spass :-)";

            return View(/*Datensatz-Struktur kann man hier übergeben*/);
        }

        public IActionResult TempDataSample()
        {
            TempData["EmailAddress"] = "KevinW@ppedv.de";
            TempData["Id"] = 123;

            //TempData Vorteile gegenüber ViewData
            //Kann Controller übergreifend verwendet werden


            return View(/*Datensatz-Struktur kann man hier übergeben*/);
        }

        public IActionResult TempDataSecondSample()
        {
            return View();
        }

        public IActionResult TempDataThirdSample()
        {
            return View();
        }


        public IActionResult SessionStart()
        {
            //Hinzufügen von Daten in eine Session 
            HttpContext.Session.SetInt32("Lottozahlen", 1234567);
            HttpContext.Session.SetString("Lottogewinner", "Hannes");

            Person person = new Person("Muster", 32, "Muster@ppedv.de");
            string jsonString = JsonSerializer.Serialize(person);
            HttpContext.Session.SetString("PersonObj", jsonString);
            return View();
        }


        public IActionResult SessionResult()
        {
            int? lottozahlen = HttpContext.Session.GetInt32("Lottozahlen");
            string? name = HttpContext.Session.GetString("Lottogewinner");

            return View();
        }
    }
}
