#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieStoreSample.Models;

namespace MovieStoreSample.Data
{
    public class MovieStoreSampleContext : DbContext
    {
        public MovieStoreSampleContext (DbContextOptions<MovieStoreSampleContext> options)
            : base(options)
        {
        }

        public DbSet<MovieStoreSample.Models.Movie> Movie { get; set; }
    }
}
