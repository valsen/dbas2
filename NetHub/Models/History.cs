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
        public int Rating { get; set; }
        public Medium Medium { get; set; }
        public Account Customer { get; set; }       
    }
}