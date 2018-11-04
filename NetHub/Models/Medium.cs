using System.Collections.Generic;

namespace NetHub.Models {

    public class Medium
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Runtime { get; set; }

        public ICollection<MediaDirector> MediaDirectors { get; set; }
        public ICollection<History> History { get; set; }
    }
}