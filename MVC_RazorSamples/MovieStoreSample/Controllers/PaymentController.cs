using Microsoft.AspNetCore.Mvc;
using MovieStoreSample.Data;
using MovieStoreSample.Models;
using System.Text.Json;

namespace MovieStoreSample.Controllers
{
    public class PaymentController : Controller
    {
        private readonly MovieStoreSampleContext _context;

        public PaymentController(MovieStoreSampleContext context) //MovieStoreSampleContext wird aus IOC Container geladen (Seperation of Concerne)
        {
            _context = context;
        }


        public IActionResult ShoppingCartOverview()
        {
            IList<Movie> movieList = new List<Movie>();

            if (HttpContext.Session.IsAvailable)
            {
                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
                {
                    movieList = InitializeShoppingCart();
                }
            }

            return View(movieList);
        }

        private IList<Movie> InitializeShoppingCart()
        {
            IList<Movie> movieList = new List<Movie>();

            List<int> ids = ReadShoppingCartFromSession();

            foreach (int id in ids)
            {
                Movie currentMovie = _context.Movie.Find(id);
                movieList.Add(currentMovie);
            }

            return movieList;
        }

        private List<int> ReadShoppingCartFromSession()
        {
            string jsonString = HttpContext.Session.GetString("ShoppingCart");
            List<int> ids = JsonSerializer.Deserialize<List<int>>(jsonString);

            return ids;
        }

        [HttpPost] 
        public IActionResult Delete(int? id)
        {
            if(!id.HasValue)
            {
                return BadRequest();
            }

            List<int> ids = ReadShoppingCartFromSession();

            if (ids.Contains(id.Value))
            {
                ids.Remove(id.Value);

                if (ids.Count == 0) //Wenn Warenkorb leer ist
                {
                    //wird aus der Session der Eintrag ShoppingCart entfernt 
                    HttpContext.Session.Remove("ShoppingCart");
                }
                else
                {
                    //Artikel sind in Wahrenkorb vorhanden und werden aktualisiert in Session gespeichert
                    string jsonString = JsonSerializer.Serialize(ids);
                    HttpContext.Session.SetString("ShoppingCart", jsonString);
                }
            }
            return RedirectToAction(nameof(ShoppingCartOverview));
        }

        [HttpGet]
        public IActionResult Pay()
        {
            return View();
        }
    }
}
