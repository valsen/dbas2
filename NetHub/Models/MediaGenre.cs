namespace NetHub.Models {

    public class MediaGenre
    {
        public int GenreID { get; set; }
        public int MediaID { get; set; }

        public Genre Genre { get; set; }
        public Medium Medium { get; set; }
    }
}