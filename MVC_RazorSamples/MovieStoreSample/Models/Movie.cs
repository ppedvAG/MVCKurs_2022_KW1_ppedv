using System.ComponentModel.DataAnnotations;

namespace MovieStoreSample.Models
{

    //https://docs.microsoft.com/de-de/dotnet/api/system.componentmodel.dataannotations?view=net-6.0
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = default!;

        [MinLength(20)]
        [Required]
        public string Description { get; set; } = default!;

        [Range(0, 20)]
        public decimal Price { get; set; } 

        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }

        
        public GenreType Genre { get; set; }
    }

    public enum GenreType { Action, Thriller, Drama, Romance, Horror, Comedy, Documentation }
}
