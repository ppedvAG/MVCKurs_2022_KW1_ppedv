#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorSamples.Models;

namespace RazorSamples.Data
{
    public class RazorSamplesContext : DbContext
    {
        public RazorSamplesContext (DbContextOptions<RazorSamplesContext> options)
            : base(options)
        {
        }

        public DbSet<RazorSamples.Models.Movie> Movie { get; set; }
    }
}
