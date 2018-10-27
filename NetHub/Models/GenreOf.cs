namespace NetHub.Models {

    public class GenreOf
    {
        public int ID { get; set; }
        public int GenreID { get; set; }
        public int MovieID { get; set; }

        public Genre Genre { get; set; }
        public Movie Movie { get; set; }
    }
}