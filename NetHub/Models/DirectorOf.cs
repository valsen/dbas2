namespace NetHub.Models {

    public class DirectorOf
    {
        public int ID { get; set; }
        public int DirectorID { get; set; }
        public int MovieID { get; set; }

        public Director Director { get; set; }
        public Movie Movie { get; set; }
    }
}