using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in stock")]
        [Range(0,20)]
        public int NumberInStock { get; set; }

        [Display(Name = "Number available")]
        public int NumberAvailable { get; set; }

        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }
    }
}