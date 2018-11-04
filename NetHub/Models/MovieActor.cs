namespace NetHub.Models {

    public class MovieActor
    {
        public int ActorID { get; set; }
        public int MovieID { get; set; }

        public Actor Actor { get; set; }
        public Movie Movie { get; set; }
    }
}