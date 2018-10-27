namespace NetHub.Models {

    public class ActsIn
    {
        public int ID { get; set; }
        public int ActorID { get; set; }
        public int MovieID { get; set; }

        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}