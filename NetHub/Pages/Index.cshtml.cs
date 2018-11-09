using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

using Microsoft.EntityFrameworkCore;


using NetHub.Models;
using NetHub.Models.ViewModels;

namespace NetHub.Pages
{
    public class IndexModel : PageModel
    {
        private readonly NetHubContext _context;

        public IList<dynamic> Entries { get; set; }
        public IList<MoviesVM> Movies { get; set; }
        public IList<SeriesVM> Series { get; set; }
        public IList<Account> Users { get; set; }
        public List<SelectListItem> SelectView { get; set; }
        public SelectList Genres { get; set; }
        public SelectList Years { get; set; }
        public Account CurrentUser { get; set; }
        public int UserId { get; set; }
        public bool History { get; set; }
        public string SearchTitle { get; set; }
        public string SelectedGenre { get; set; }
        public string SearchActor { get; set; }
        public int SelectedYear { get; set; }
        public int SelectedUser { get; set; }
        public int NewRating { get; set; }
        public int AgeLimit { get; set; }

        // Konstruktor
        public IndexModel(NetHubContext context)
        {
            _context = context;
            History = false;
        }
        public async Task OnGetAsync(string searchTitle, string selectedGenre, string searchActor, int selectedYear, int userId, bool history)
        {
            var movies = _context.Movies
                .Include(x => x.Medium)
                    .ThenInclude(x => x.MediaDirectors)
                        .ThenInclude(x => x.Director)
                .Include(x => x.Medium)
                    .ThenInclude(x => x.History)
                        .ThenInclude(x => x.Customer)
                .Include(x => x.MoviesActors)
                    .ThenInclude(x => x.Actor)
                .Include(x => x.MoviesGenres)
                    .ThenInclude(x => x.Genre)
                .Include(x => x.MoviesLanguages)
                    .ThenInclude(x => x.Language)
                .Include(x => x.MoviesCaptionings)
                    .ThenInclude(x => x.Language)
                .Include(x => x.MoviesProdCompanies)
                    .ThenInclude(x => x.ProdCompany)
                .Include(x => x.Rating)
                
                .AsQueryable();

            var series = _context.Series
                .Include(x => x.Seasons)
                    .ThenInclude(x => x.Episodes)
                        .ThenInclude(x => x.Medium)
                            .ThenInclude(x => x.History)
                .Include(x => x.Seasons)
                    .ThenInclude(x => x.Episodes)
                        .ThenInclude(x => x.Medium)
                            .ThenInclude(x => x.MediaDirectors)
                                .ThenInclude(x => x.Director)
                .Include(x => x.Seasons)
                    .ThenInclude(x => x.Episodes)
                        .ThenInclude(x => x.Medium)
                            .ThenInclude(x => x.History)
                                .ThenInclude(x => x.Customer)    
                .Include(x => x.Rating)
                .Include(x => x.SeriesGenres)
                    .ThenInclude(x => x.Genre)
                .Include(x => x.SeriesLanguages)
                    .ThenInclude(x => x.Language)
                .AsQueryable();

            if (userId != 0)
            {
                var filter = _context.AgeFilters.FirstOrDefault(x => x.ID == userId);
                if (filter != null)
                {
                    int ageLimit = filter.AgeLimit;
                    movies = movies.Where(x => x.Rating.AgeLimit <= ageLimit);
                    series = series.Where(x => x.Rating.AgeLimit <= ageLimit);
                }

                if (history)
                {
                    movies = movies.Where(m => m.Medium.History.Any(x => x.Customer.ID == userId));
                    series = series.Where(x => x.Seasons.Any(s => s.Episodes.Any(e => e.Medium.History.Any(h => h.Customer.ID == userId))));
                }
                else
                {
                    movies = movies.Where(m => !m.Medium.History.Any(x => x.Customer.ID == userId));
                    series = series.Where(x => x.Seasons.Any(s => s.Episodes.Any(e => !e.Medium.History.Any(h => h.AccountID == userId))));
                }
            }

            if (!String.IsNullOrEmpty(selectedGenre))
            {
                movies = movies.Where(m => m.MoviesGenres.Any(x => x.Genre.Name == selectedGenre));
                series = series.Where(m => m.SeriesGenres.Any(x => x.Genre.Name == selectedGenre));
                    
                // More like normal SQL
                // movies = 
                //     from movie in movies
                //     join moviegenre in _context.MoviesGenres on movie.ID equals moviegenre.MovieID
                //     join genre in _context.Genres
                //         .Where(x => x.Name.ToLower() == selectGenre.ToLower())
                //     on moviegenre.GenreID equals genre.ID
                //     select movie;
            }
            if (!String.IsNullOrEmpty(searchTitle))
            {
                movies = movies.Where(x => x.Medium.Title.ToLower().Contains(searchTitle.ToLower()));
                series = series.Where(x => x.Title.ToLower().Contains(searchTitle.ToLower()));
            }
            if (!String.IsNullOrEmpty(searchActor))
            {
                movies = movies
                    .Where(m => m.MoviesActors.Any(x => searchActor.ToLower().Contains(x.Actor.FirstName.ToLower()) 
                                                    || searchActor.ToLower().Contains(x.Actor.LastName.ToLower())));
                series = series
                    .Where(m => m.SeriesActors.Any(x => searchActor.ToLower().Contains(x.Actor.FirstName.ToLower()) 
                                                    || searchActor.ToLower().Contains(x.Actor.LastName.ToLower())));

                // More like normal SQL
                // movies =
                //     from movie in movies
                //     join movieactor in _context.MoviesActors on movie.ID equals movieactor.MovieID
                //     join actor in _context.Actors
                //         .Where(x => searchActor.ToLower().Contains(x.FirstName.ToLower()) 
                //                 || searchActor.ToLower().Contains(x.LastName.ToLower()))
                //     on movieactor.ActorID equals actor.ID
                //     select movie;
            }
            if (selectedYear > 0)
            {
                movies = movies.Where(x => x.Year == selectedYear);
                series = series.Where(x => x.Seasons.Any(s => s.Year == selectedYear));
            }

            var genres = _context.Genres
                .OrderBy(g => g.Name)
                .Select(g => g.Name);

            

            int[] years = Enumerable
                .Range(System.DateTime.Now.Year-100, 101)
                .ToArray();
            Array.Reverse(years);

            var viewOptions = new List<SelectListItem>
            {
                new SelectListItem{Text="New",Value="false"},
                new SelectListItem{Text="Watched",Value="true"}
            };

            var users = _context.Accounts;

            UserId = userId;
            Users = await users.ToListAsync();
            CurrentUser = users.FirstOrDefault(x => x.ID == userId);

            Movies = await movies.Select(x => new MoviesVM(x)).ToListAsync();
            Series = await series.Select(x => new SeriesVM(x)).ToListAsync();

            var entries = new List<dynamic>();
            foreach (var m in Movies)
            {
                entries.Add(m);
            }
            foreach (var s in Series)
            {
                entries.Add(s);
            }
            Entries = entries.OrderBy(x => x.Title).ToList();

            Genres = new SelectList(await genres.ToListAsync());
            Years = new SelectList(years);
            SelectView = viewOptions;

            SearchTitle = searchTitle;
            SelectedGenre = selectedGenre;
            SearchActor = searchActor;
            SelectedYear = selectedYear;
            History = history;
            SelectedUser = userId;
        }

        public async Task OnPostRateAsync(int userId, int mediumId, int newRating)
        {
            var history = _context.History.First(x => x.AccountID == userId && x.MediumID == mediumId);
            history.Rating = newRating;
            _context.Update(history);
            NewRating = newRating;
            await _context.SaveChangesAsync();

            UserId = userId;

            await OnGetAsync(SearchTitle, SelectedGenre, SearchActor, SelectedYear, UserId, true);
        }
    }
}
