using System.ComponentModel.DataAnnotations.Schema;

namespace NetHub.Models
{
    public class Episode
    {
        [ForeignKey("Medium")]
        public int EpisodeID { get; set; }
        public int EpisodeNum { get; set; }
        public int SeasonID {get; set; }

        public Medium Medium { get; set; }
        public Season Season { get; set; }
    }
}