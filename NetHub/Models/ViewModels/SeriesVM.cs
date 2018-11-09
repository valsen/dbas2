using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

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
        public string DirectorString { get; set; }
        public Boolean Complete { get; set; }
        public List<History> History { get; set; }
        public List<Episode> Episodes { get; set; }
        
        public SeriesVM(Series series)
        {
            Title = series.Title;
            Year = getYear(series);
            Description = series.Description;
            ImgPath = series.ImgPath;
            Genre = getGenreString(series);
            Rating = series.Rating.Name;
            Actors = new List<Actor>();
            getActors(series);
            Episodes = getEpisodes(series);
            History = getHistory(series);
            LanguageString = getLanguageString(series);
            foreach(var ep in Episodes)
            {
                Console.WriteLine(ep.Medium.Title);
            }
        }

        private string getGenreString(Series series)
        {
            var genreList = new List<string>();
            StringBuilder genres = new StringBuilder();
            string prefix = "";
            if (series.SeriesGenres != null) {
                foreach (var g in series.SeriesGenres) {
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

        private string getLanguageString(Series series)
        {
            var languageList = new List<string>();
            StringBuilder languages = new StringBuilder();
            string prefix = "";
            if (series.SeriesLanguages != null) {
                foreach (var l in series.SeriesLanguages) {
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

        private void getActors(Series s)
        {
            var actorList = new List<string>();
            StringBuilder actors = new StringBuilder();
            string prefix = "";
            if (s.SeriesActors != null) {
                foreach (var a in s.SeriesActors) {
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

        private int getYear(Series s)
        {
            return s.Seasons.Min(x => x.Year);
        }

        private List<History> getHistory(Series s)
        {
            var History = new List<History>();
            if (s.Seasons != null)
            {
                foreach (var season in s.Seasons)
                {
                    if (season.Episodes != null)
                    {
                        foreach (var episode in season.Episodes)
                        {
                            if (episode.Medium.History != null)
                            {
                                foreach (var h in episode.Medium.History)
                                {
                                    History.Add(h);
                                }
                                return History;
                            }
                        }
                    }
                }
            }
            return null;
        }

        private List<Episode> getEpisodes(Series s)
        {
            var episodes = new List<Episode>();
            if (s.Seasons != null)
            {
                foreach (var season in s.Seasons)
                {
                    if (season.Episodes != null)
                    {
                        foreach (var episode in season.Episodes)
                        {
                            episodes.Add(episode);
                        }
                    }
                }
            }
            return episodes;
        }
    }
}