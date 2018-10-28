using System.Collections.Generic;

namespace NetHub.Models {

    public class ProdCompany
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<ProdCompanyFor> ProdCompanyFor { get; set; }
    }
}