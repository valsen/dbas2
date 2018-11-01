namespace NetHub.Models {

    public class MediaActor
    {
        public int ActorID { get; set; }
        public int MediaID { get; set; }

        public Actor Actor { get; set; }
        public Medium Medium { get; set; }
    }
}