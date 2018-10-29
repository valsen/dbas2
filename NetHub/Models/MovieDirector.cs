namespace NetHub.Models {

    public class MovieDirector
    {
        public int DirectorID { get; set; }
        public int MovieID { get; set; }

        public Director Director { get; set; }
        public Movie Movie { get; set; }
    }
}