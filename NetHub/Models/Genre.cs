using System.Collections.Generic;

namespace NetHub.Models {

    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<MovieGenre> MoviesGenres { get; set; }
    }
}