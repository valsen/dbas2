using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetHub.Models
{
    public class History
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int MediumID { get; set; }
        public DateTime Date { get; set; }
        [Range(1, 5, ErrorMessage = "{0} must between 1 and 5")]
        public int Rating { get; set; }
        public Medium Medium { get; set; }
        public Account Customer { get; set; }       
    }
}