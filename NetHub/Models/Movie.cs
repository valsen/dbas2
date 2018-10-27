namespace NetHub.Models {

    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int GenreID { get; set; }
        public string Language { get; set; }
        public float rating { get; set; }

        public Genre Genre { get; set; }
    }
}