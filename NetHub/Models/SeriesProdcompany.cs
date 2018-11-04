namespace NetHub.Models 
{

    public class SeriesProdcompany
    {
        public int ProdCompanyID { get; set; }
        public int SeriesID { get; set; }

        public ProdCompany ProdCompany { get; set; }
        public Series Series { get; set; }
    }
}