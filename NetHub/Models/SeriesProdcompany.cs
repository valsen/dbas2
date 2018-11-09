namespace NetHub.Models 
{

    public class SeriesProdcompany
    {
        public int SeriesID { get; set; }
        public int ProdCompanyID { get; set; }

        public Series Series { get; set; }
        public ProdCompany ProdCompany { get; set; }
    }
}