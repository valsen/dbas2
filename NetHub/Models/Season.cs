using System.Collections.Generic;

namespace NetHub.Models
{
    public class Season
    {
        public int ID { get; set; }
        public int SeriesID { get; set; }
        public int SeasonNum { get; set; }
        public int Year { get; set; }

        public Series Series { get; set; }
        public ICollection<Episode> Episodes { get; set; }
    }
}