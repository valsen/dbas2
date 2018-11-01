namespace NetHub.Models 
{

    public class MediaProdcompany
    {
        public int ProdCompanyID { get; set; }
        public int MediaID { get; set; }

        public ProdCompany ProdCompany { get; set; }
        public Medium Medium { get; set; }
    }
}