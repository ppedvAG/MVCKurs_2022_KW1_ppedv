using Microsoft.AspNetCore.Mvc;
using RazorSamples.Models;
using RazorSamples.Services;
using RazorSamples.ViewModels;

namespace RazorSamples.Controllers
{
    public class RazorSamplesController : Controller
    {
        private ITimeService _timeService;  
        
        public RazorSamplesController(ITimeService timeService) //Konstruktor Injection 
        {
            _timeService = timeService; 
        }


        //GET
        public IActionResult Index([FromServices] ITimeService myTimeService) //Methoden Injection 
        {
            IList<Person> myPersons = new List<Person>();

            myPersons.Add(new Person("Max", 33));

            myPersons.Add(new Person("Moritz", 34));

            return View(myPersons.ToArray());
        }


        public IActionResult ShowTable ()
        {
            IList<Movie> movies = new List<Movie>();

            movies.Add(new Movie
            {
                Id = 1,
                Title = "ES",
                Description = "Verwirrter Clown muss eigentlich zum Zahnarzt"
            });

            movies.Add(new Movie
            {
                Id = 1,
                Title = "Star Wars 10",
                Description = "Niederlage der JavaScript Entwickler"
            });

            movies.Add(new Movie
            {
                Id = 3,
                Title = "Star Wars 11",
                Description = ".NET Imperium schlägt zurück"
            });

            return View(movies);
        }

        public IActionResult GeneratedTable()
        {
            IList<Movie> movies = new List<Movie>();

            movies.Add(new Movie
            {
                Id = 1,
                Title = "ES",
                Description = "Verwirrter Clown muss eigentlich zum Zahnarzt"
            });

            movies.Add(new Movie
            {
                Id = 2,
                Title = "Star Wars 10",
                Description = "Niederlage der JavaScript Entwickler"
            });

            movies.Add(new Movie
            {
                Id = 3,
                Title = "Star Wars 11",
                Description = ".NET Imperium schlägt zurück"
            });

            return View(movies);
        }

        public IActionResult ShowTableWithVM ()
        {
            MovieViewModel vm = new MovieViewModel();

            vm.Movie = new Movie
            {
                Id = 1,
                Title = "Jurrasic Park",
                Description = "Handy klingelt auf Klo",
                Price = 19.99m
            };

            vm.Cast = new List<Artists>();
            vm.Cast.Add(new Artists
            {
                Id = 1,
                FirstName = "Otto",
                LastName = " Walkes"
            });

            vm.Cast.Add(new Artists
            {
                Id = 2,
                FirstName = "Harry",
                LastName = " Weinfuhrt"
            });

            vm.Cast.Add(new Artists
            {
                Id = 3,
                FirstName = "Ralf",
                LastName = " Möller"
            });

            vm.ExterneIMDBRating = 8;


            return View(vm);
        }


        //HTML - Helper
        public IActionResult ShowTagHelperSample()
        {
            return View();
        }

        //Asp - Tag Helper 
        public IActionResult ShowAspTagHelperSample()
        {
            return View();
        }


    }
}
