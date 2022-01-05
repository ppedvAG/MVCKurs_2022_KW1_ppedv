using LabGuestBookApp.Data;
using LabGuestBookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabGuestBookApp.Controllers
{
    public class GuestBookController : Controller
    {
        private readonly GuestBookDbContext _ctx;

        public GuestBookController(GuestBookDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _ctx.GuestBookEntries.ToListAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(GuestBookEntry entry)
        {
            entry.CreatedAt = DateTime.Now;
            _ctx.GuestBookEntries.Add(entry);
            await _ctx.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
