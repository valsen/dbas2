using System;
using System.Text;
using System.Collections.Generic;

namespace NetHub.Models.ViewModels
{
    public class MovieHistoryVM
    {
        public int ID { get; set; }
        public int AccountID { get; set; }
        public int MovieID { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
        public Movie Movie { get; set; }

        public MovieHistoryVM(Movie movie, int accountID, DateTime date, int rating)
        {
            AccountID = accountID;
            MovieID = movie.ID;
            Date = date;
            Rating = rating;
        }

        
    }
}