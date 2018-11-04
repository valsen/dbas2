using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetHub.Models
{
    public class Language
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<MovieLanguage> MoviesLanguages { get; set; }
        public ICollection<SeriesLanguage> SeriesLanguages { get; set; }
    }
}