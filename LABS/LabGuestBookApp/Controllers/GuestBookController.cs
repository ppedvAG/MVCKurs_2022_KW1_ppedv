using LabGuestBookApp.Data;
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
    }
}
