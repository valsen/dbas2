using System;
using System.Collections.Generic;

namespace NetHub.Models {

    public class Actor
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public ICollection<ActsIn> ActsIn { get; set; }
    }
}