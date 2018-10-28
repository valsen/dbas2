using System.Collections.Generic;

namespace NetHub.Models {

    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string Language { get; set; }
        public int Runtime { get; set; }

        public ICollection<GenreOf> GenreOf { get; set; }
        public ICollection<DirectorOf> DirectorOf { get; set; }
        public ICollection<ActsIn> ActsIns { get; set; }
    }
}