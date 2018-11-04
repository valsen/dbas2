namespace NetHub.Models
{
    public class Episode
    {
        public int MediumID { get; set; }
        public int EpisodeNum { get; set; }
        public int SeasonID {get; set; }

        public Medium Medium { get; set; }
        public Season Season { get; set; }
    }
}