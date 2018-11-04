using System;
using System.Text;
using System.Collections.Generic;

namespace NetHub.Models.ViewModels
{
    public class SeriesVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string LanguageString { get; set; }
        public int Year { get; set; } //get from latest season
        public string ImgPath { get; set; }
        public List<Actor> Actors { get; set; }
        public string ActorString { get; set; }
        public List<Director> Directors { get; set; }
        public string DirectorString { get; set; }
        public Boolean Complete { get; set; }
        public string Runtime { get; set; }
        public List<History> History { get; set; }
        public SeriesVM(Movie movie)
        {
            Title = movie.Medium.Title;
            Year = movie.Year;
            Description = movie.Medium.Description;
            ImgPath = movie.ImgPath;
            Runtime = getRuntime(movie);
            Genre = getGenreString(movie);
            Rating = movie.Rating.Name;
            Actors = new List<Actor>();
            Directors = new List<Director>();
            History = getHistory(movie);
            getActors(movie);
            getDirectors(movie);
            LanguageString = getLanguageString(movie);
        }

        private string getGenreString(Movie movie)
        {
            var genreList = new List<string>();
            StringBuilder genres = new StringBuilder();
            string prefix = "";
            if (movie.SeriesGenres != null) {
                foreach (var g in movie.SeriesGenres) {
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

        private string getLanguageString(Movie movie)
        {
            var languageList = new List<string>();
            StringBuilder languages = new StringBuilder();
            string prefix = "";
            if (movie.SeriesLanguages != null) {
                foreach (var l in movie.SeriesLanguages) {
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

        private void getActors(Movie m)
        {
            var actorList = new List<string>();
            StringBuilder actors = new StringBuilder();
            string prefix = "";
            if (m.SeriesActors != null) {
                foreach (var a in m.SeriesActors) {
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

        private void getDirectors(Movie m)
        {
            var directorList = new List<string>();
            StringBuilder directors = new StringBuilder();
            string prefix = "";
            if (m.Medium.MediaDirectors != null) {
                foreach (var d in m.Medium.MediaDirectors) {
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

        private List<History> getHistory(Movie m)
        {
            if (m.Medium.History != null)
            {
                var History = new List<History>();
                foreach (var h in m.Medium.History)
                {
                    History.Add(h);
                }
                return History;
            }
            return null;
        }

        private string getRuntime(Movie movie)
        {
          return "" + movie.Medium.Runtime/60 + "h " + movie.Medium.Runtime%60 + "min";
        }
    }
}