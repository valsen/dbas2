using System;
using System.Text;
using System.Collections.Generic;

namespace NetHub.Models
{
    public class MovieHistory
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int MovieID { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public Movie Movie { get; set; }        
    }
}