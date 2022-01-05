#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieStoreSample.Data;
using MovieStoreSample.Models;

namespace MovieStoreSample.Controllers
{


    //GET-Methode: liefert als Response eine HTML - Seite an den Browser 
    public class MovieController : Controller
    {
        private readonly MovieStoreSampleContext _context;

        public MovieController(MovieStoreSampleContext context) //MovieStoreSampleContext wird aus IOC Container geladen (Seperation of Concerne)
        {
            _context = context;
        }


        #region Index-Seite
        // GET: Movie
        public async Task<IActionResult> Index(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                ViewData["FilterQuery"] = query; //ÜBergeben einen Wert an die View. Ist eine Einmalnachricht
            }

            IList<Movie> filteredList = string.IsNullOrEmpty(query) ?
                await _context.Movie.ToListAsync() :
                await _context.Movie.Where(q => q.Title.Contains(query) || q.Description.Contains(query)).ToListAsync();
            
            return View(filteredList);
        }
        #endregion

        #region Details-Seite
        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // 404 Feler wird als Respnse zurück gegeben 
            }

            //EF Call, bekomme movie Object 
            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);


            if (movie == null)
            {
                return NotFound(); // 404 Feler wird als Respnse zurück gegeben 
            }

            return View(movie); //Movie Objekt wird an die Detail UI übergeben 
        }
        #endregion

        #region Create-Seite
        // GET: Movie/Create        -> wird benötigt um das leere Formular anzuzeigen 
        [HttpGet("/movie/create")]
        public IActionResult Create()
        {
            return View(); //Leeres Formular hat keine Daten...daher View()
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost("/movie/create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,ReleaseYear,Genre")] Movie movie) //Model-Binding oder Parameter-Binder
        {
            string title = Request.Form["Title"].ToString(); //Alte schreibweise, wie man ein Formular auswertet 

            if (movie.Title == "The Crow")
            {
                ModelState.AddModelError("Title", "Der Title steht auf dem Index"); //ModelState wird auf false gesetzt 
            }


            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                
                
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        #endregion

        #region Edit-Seite
        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie); 
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Price,ReleaseYear,Genre")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }


        [HttpPost]
        public IActionResult EditAndArchived(int id, [Bind("Id,Title,Description,Price,ReleaseYear,Genre")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                //Mach was schlaues
                return RedirectToAction(nameof(Index));
            }

            return View(movie);
        }
        #endregion

        #region Delete-Seite
        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        #endregion

        [HttpPost("/movie/buy/{id}")]
        public IActionResult Buy(int? id)
        {
            if (!id.HasValue)
                return BadRequest(); //404 Fehler, wenn ID nicht vorhanden ist

            if (HttpContext.Session.IsAvailable)
            {
                IList<int> idList = new List<int>();

                //Wenn der Warenkorb vorhanden ist, gehe ich davon aus, dass ich gerade den zweiten, dritten.... Artikel in den Warenkorb lege 
                if (HttpContext.Session.Keys.Contains("ShoppingCart"))
                {
                    //Wollen Artikel (Ids) aus Warenkorb auslesen
                    string jsonIdList = HttpContext.Session.GetString("ShoppingCart");
                    
                    //bekommen eine Id-Liste mit allen vorhandenen Artikel im Warenkorb
                    idList = JsonSerializer.Deserialize<List<int>>(jsonIdList);
                }

                idList.Add(id.Value);

                string jsonString = JsonSerializer.Serialize(idList);
                HttpContext.Session.SetString("ShoppingCart", jsonString);
            }

            return RedirectToAction(nameof(Index));

        }
        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
