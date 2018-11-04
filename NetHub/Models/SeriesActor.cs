namespace NetHub.Models {

    public class SeriesActor
    {
        public int ActorID { get; set; }
        public int SeriesID { get; set; }

        public Actor Actor { get; set; }
        public Series Series { get; set; }
    }
}