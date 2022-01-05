using LabGuestBookApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LabGuestBookApp.Data
{
    public class GuestBookDbContext : DbContext
    {
        public GuestBookDbContext(DbContextOptions<GuestBookDbContext> guestBookOptions)
            :base (guestBookOptions)
        {
        }

        public DbSet<GuestBookEntry> GuestBookEntries { get; set; } = default!;
    }
}
