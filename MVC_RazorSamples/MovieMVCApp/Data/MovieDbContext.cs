using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieMVCApp.Models;

namespace MovieMVCApp.Data
{

    //1.) Add-Migration FirstVersion -context MovieMVCApp.Data.MovieDbContext
    //2.) Update-Database -context MovieMVCApp.Data.MovieDbContext
    public class MovieDbContext : DbContext
    {
        public MovieDbContext (DbContextOptions<MovieDbContext> options) //via options -> wird der ConnectionString geladen
            : base(options)
        {
            
        }


        //Tabelle werden mit DbSEt abgebildet
        public DbSet<MovieMVCApp.Models.Movie> Movie { get; set; }
    }
}
