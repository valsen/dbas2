using System;
using System.Collections.Generic;

namespace NetHub.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string CustName { get; set; }
        public int Age { get; set; }
        public DateTime JoinDate { get; set; }
        public PayStatus PayStatus { get; set; }
        public DateTime ExpireDate { get; set; }

        public ICollection<MovieHistory> MovieHistory { get; set; }
    }

    public enum PayStatus
    {
        Paid, Pending, Due, Overdue
    }
}