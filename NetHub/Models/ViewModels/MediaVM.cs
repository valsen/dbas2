using System;
using System.Text;
using System.Collections.Generic;

namespace NetHub.Models.ViewModels
{
    public class MediaVM
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        //public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string LanguageString { get; set; }
        public List<Actor> Actors { get; set; }
        public string ActorString { get; set; }
        public List<Director> Directors { get; set; }
        public string DirectorString { get; set; }
        //public List<MovieHistory> MovieHistories { get; set; }

        // Konstruktor
        public MediaVM(Medium medium)
        {
            Title = medium.Title;
            Year = medium.Year;
            Description = medium.Description;
            ImgPath = medium.ImgPath;
            Runtime = getRuntime(medium);
            Genre = getGenreString(medium);
            Rating = medium.Rating.Name;
            Actors = new List<Actor>();
            Directors = new List<Director>();
            MovieHistories = getMovieHistories(movie);
            getActors(medium);
            getDirectors(medium);
            LanguageString = getLanguageString(medium);
        }

        private string getGenreString(Medium medium)
        {
            var genreList = new List<string>();
            StringBuilder genres = new StringBuilder();
            string prefix = "";
            if (medium.MediaGenres != null) {
                foreach (var g in medium.MediaGenres) {
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

        private string getLanguageString(Medium medium)
        {
            var languageList = new List<string>();
            StringBuilder languages = new StringBuilder();
            string prefix = "";
            if (medium.MediaLanguages != null) {
                foreach (var l in medium.MediaLanguages) {
                    languageList.Add(l.Language.Name);
                }
                languageList.Sort();
                foreach (var language in languageList) {
                    languages.Append(prefix);
                    prefix = ", ";
                    languages.Append(language);
                }
            }
            return languages.ToString();
        }

        private void getActors(Medium m)
        {
            var actorList = new List<string>();
            StringBuilder actors = new StringBuilder();
            string prefix = "";
            if (m.MediaActors != null) {
                foreach (var a in m.MediaActors) {
                    Actors.Add(a.Actor);
                    actorList.Add(a.Actor.FirstName + " " + a.Actor.LastName);
                }
                actorList.Sort();
                foreach (var actor in actorList) {
                    actors.Append(prefix);
                    prefix = ", ";
                    actors.Append(actor);
                }
            }
            ActorString = actors.ToString();
        }

        private void getDirectors(Medium m)
        {
            var directorList = new List<string>();
            StringBuilder directors = new StringBuilder();
            string prefix = "";
            if (m.MediaDirectors != null) {
                foreach (var d in m.MediaDirectors) {
                    Directors.Add(d.Director);
                    directorList.Add(d.Director.FirstName + " " + d.Director.LastName);
                }
                directorList.Sort();
                foreach (var director in directorList) {
                    directors.Append(prefix);
                    prefix = ", ";
                    directors.Append(director);
                }
            }
            DirectorString = directors.ToString();
        }

        private List<MovieHistory> getMovieHistories(Movie m)
        {
            if (m.MovieHistories != null)
            {
                var movieHistories = new List<MovieHistory>();
                foreach (var h in m.MovieHistories)
                {
                    movieHistories.Add(h);
                }
                return movieHistories;
            }
            return null;
        }

        private string getRuntime(Movie movie)
        {
          return "" + movie.Runtime/60 + "h " + movie.Runtime%60 + "min";
        }
    }
}