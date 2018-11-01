using System.Collections.Generic;

namespace NetHub.Models {

    public class Medium
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        // public int Runtime { get; set; }
        public int RatingID { get; set; }

        public ICollection<MediaGenre> MediaGenres { get; set; }
        public ICollection<MediaLanguage> MediaLanguages { get; set; }
        public ICollection<MediaDirector> MediaDirectors { get; set; }
        public ICollection<MediaActor> MediaActors { get; set; }
        //spublic ICollection<MovieHistory> MovieHistories { get; set; }
        public Rating Rating { get; set; }
    }
}