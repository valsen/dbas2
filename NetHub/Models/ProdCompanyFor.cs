namespace NetHub.Models {

    public class ProdCompanyFor
    {
        public int ProdCompanyID { get; set; }
        public int MovieID { get; set; }

        public ProdCompany ProdCompany { get; set; }
        public Movie Movie { get; set; }
    }
}