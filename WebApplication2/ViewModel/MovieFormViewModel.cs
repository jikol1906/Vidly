using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public int? MovieId { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [Required]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name = "Number in stock")]
        [Range(0, 20)]
        public int? NumberInStock { get; set; }

        [Display(Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        public string Title
        {
            get
            {
                if (MovieId != 0)
                {
                    return "Edit Movie";
                }

                return "Add Movie";
            }
        }

        public MovieFormViewModel()
        {
            MovieId = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            MovieId = movie.MovieId;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;        
        }

    }
}