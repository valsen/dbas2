using System.Collections.Generic;

namespace NetHub.Models
{
    public class Series
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public int RatingID { get; set; }

        public ICollection<Season> Seasons { get; set; }
        public ICollection<Episode> Episodes { get; set; }
        public Rating Rating { get; set; }
        public ICollection<SeriesActor> SeriesActors { get; set; }
        public ICollection<SeriesGenre> SeriesGenres { get; set; }
        public ICollection<SeriesCaptioning> SeriesCaptionings { get; set; }
        public ICollection<SeriesLanguage> SeriesLanguages { get; set; }
        public ICollection<SeriesProdcompany> SeriesProdCompanies { get; set; }
    }
}