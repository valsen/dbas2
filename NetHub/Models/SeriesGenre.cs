namespace NetHub.Models {

    public class SeriesGenre
    {
        public int GenreID { get; set; }
        public int SeriesID { get; set; }

        public Genre Genre { get; set; }
        public Series Series { get; set; }
    }
}