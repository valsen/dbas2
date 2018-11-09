namespace NetHub.Models {

    public class SeriesActor
    {
        public int SeriesID { get; set; }
        public int ActorID { get; set; }

        public Series Series { get; set; }
        public Actor Actor { get; set; }
    }
}