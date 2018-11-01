namespace NetHub.Models {

    public class MediaDirector
    {
        public int DirectorID { get; set; }
        public int MediaID { get; set; }

        public Director Director { get; set; }
        public Medium Medium { get; set; }
    }
}