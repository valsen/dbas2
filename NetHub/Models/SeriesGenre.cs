namespace NetHub.Models {

    public class SeriesGenre
    {
        public int SeriesID { get; set; }
        public int GenreID { get; set; }

        public Series Series { get; set; }
        public Genre Genre { get; set; }
    }
}