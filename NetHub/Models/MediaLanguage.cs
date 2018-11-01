namespace NetHub.Models
{
    public class MediaLanguage
    {
        public int MediaID { get; set; }
        public int LanguageID { get; set; }

        public Medium Medium { get; set; }
        public Language Language { get; set; } 
    }
}