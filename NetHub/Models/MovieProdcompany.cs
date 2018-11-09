namespace NetHub.Models 
{

    public class MovieProdcompany
    {
        public int MovieID { get; set; }
        public int ProdCompanyID { get; set; }

        public Movie Movie { get; set; }
        public ProdCompany ProdCompany { get; set; }
    }
}