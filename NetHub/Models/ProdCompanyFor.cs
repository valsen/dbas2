namespace NetHub.Models {

    public class ProdCompanyFor
    {
        public int ID { get; set; }
        public int ProdCompanyID { get; set; }
        public int MovieID { get; set; }

        public ProdCompany ProdCompany { get; set; }
        public Movie Movie { get; set; }
    }
}