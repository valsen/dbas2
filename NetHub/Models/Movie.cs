using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetHub.Models {

    public class Movie
    {
        [ForeignKey("Medium")]
        public int MovieID { get; set; }
        public string ImgPath { get; set; }
        public int RatingID { get; set; }
        public int Year { get; set; }

        // public string Title { get; set; }
        // public int Year { get; set; }
        // public string Description { get; set; }
        // public string ImgPath { get; set; }
        // public int RatingID { get; set; }

        // public ICollection<MovieGenre> MoviesGenres { get; set; }
        // public ICollection<MovieLanguage> MoviesLanguages { get; set; }
        // public ICollection<MovieDirector> MoviesDirectors { get; set; }
        // public ICollection<MovieActor> MoviesActors { get; set; }
        public Medium Medium { get; set; }
        public Rating Rating { get; set; }
        public ICollection<MovieActor> MoviesActors { get; set; }
        public ICollection<MovieGenre> MoviesGenres { get; set; }
        public ICollection<MovieCaptioning> MoviesCaptionings { get; set; }
        public ICollection<MovieLanguage> MoviesLanguages { get; set; }
        public ICollection<MovieProdcompany> MoviesProdCompanies { get; set; }

    }
}