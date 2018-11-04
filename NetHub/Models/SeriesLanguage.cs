namespace NetHub.Models
{
    public class SeriesLanguage
    {
        public int SeriesID { get; set; }
        public int LanguageID { get; set; }

        public Series Series { get; set; }
        public Language Language { get; set; } 
    }
}