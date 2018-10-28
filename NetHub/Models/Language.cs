using System.ComponentModel.DataAnnotations;

namespace NetHub.Models
{
    public class Language
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}