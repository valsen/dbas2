namespace NetHub.Models
{
    public class MovieLanguage
    {
        public int MovieID { get; set; }
        public int LanguageID { get; set; }

        public Movie Movie { get; set; }
        public Language Language { get; set; } 
    }
}