using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieMVCApp.Models
{
    public class Movie //POCO Klasse -> Keine Logik + keine NestedTypes
    {
        //Nested Type
        //public enum Genre { Action = 1, Thriller, Horror, Comedy, Romance, Drama, Animation, ScienceFiction, Documentary }



        //DatAnnotations wirken sich auf DB aus + UI aus
        //CompopntentModel -> wirkt sich nur auf die Darstellung in der UI aus
        //WEitere DataAnnotationen -> https://docs.microsoft.com/de-de/dotnet/api/system.componentmodel.dataannotations?view=net-5.0
        public int Id { get; set; }


        [Required] //System.ComponentModel.DataAnnotations;
        public string Title { get; set; }
        public string Description { get; set; }

        [DisplayName("Genre Typ")] //System.ComponentModel;
        public Genre GenreType { get; set; }

        //[Range(1, 10, ErrorMessage = "Dies ist ein Movie Store, der abnormale Preise nicht zulässt und nichts verschenkt")]
        public decimal Price { get; set; }

        [Range(1, 9)]
        [Required]
        public int IMDBRating { get; set; }
    }

    public enum Genre { Default=0, Action, Thriller, Horror, Comedy, Romance, Drama, Animation, ScienceFiction, Documentary }

   
}
