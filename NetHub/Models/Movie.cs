using System.Collections.Generic;

namespace NetHub.Models {

    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public int Runtime { get; set; }
        public int RatingID { get; set; }

        public ICollection<MovieGenre> MoviesGenres { get; set; }
        public ICollection<MovieLanguage> MoviesLanguages { get; set; }
        public ICollection<MovieDirector> MoviesDirectors { get; set; }
        public ICollection<MovieActor> MoviesActors { get; set; }
        public ICollection<MovieHistory> MovieHistories { get; set; }
        public Rating Rating { get; set; }
    }
}