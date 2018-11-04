using System.Collections.Generic;

namespace NetHub.Models {

    public class ProdCompany
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<MovieProdcompany> MoviesProdcompanies { get; set; }
        public ICollection<SeriesProdcompany> SeriesProdcompanies { get; set; }
    }
}