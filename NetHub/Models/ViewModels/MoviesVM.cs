using System;
using System.Text;
using System.Collections.Generic;

namespace NetHub.Models.ViewModels
{
    public class MoviesVM
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public List<Actor> Actors { get; set; }

        public MoviesVM(Movie movie)
        {
            Title = movie.Title;
            Year = movie.Year;
            Description = movie.Description;
            ImgPath = movie.ImgPath;
            Runtime = getRuntime(movie);
            Genre = getGenres(movie);
            Actors = getActors(movie);
        }

        private string getGenres(Movie movie)
        {
            var genreList = new List<string>();
            StringBuilder genres = new StringBuilder();
            string prefix = "";
            if (movie.MoviesGenres != null) {
                foreach (var g in movie.MoviesGenres) {
                    genreList.Add(g.Genre.Name);
                }
                genreList.Sort();
                foreach (var genre in genreList) {
                    genres.Append(prefix);
                    prefix = ", ";
                    genres.Append(genre);
                }
            }
            return genres.ToString();
        } 

        private List<Actor> getActors(Movie m)
        {
            var actors = new List<Actor>();
            foreach (var entry in m.MoviesActors)
            {
                actors.Add(entry.Actor);
            }
            return actors;
        }

        private string getRuntime(Movie movie)
        {
          return "" + movie.Runtime/60 + "h " + movie.Runtime%60 + "min";
        }
    }
}