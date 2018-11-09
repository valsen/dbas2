using System.ComponentModel.DataAnnotations.Schema;

namespace NetHub.Models
{
    public class AgeFilter
    {
        [ForeignKey("Account")]
        public int ID { get; set; }
        public int AgeLimit { get; set; }

        public Account Account { get; set; }
    }
}