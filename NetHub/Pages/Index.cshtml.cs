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
        public int UserId { get; set; }
        public bool History { get; set; }
        public string SearchTitle { get; set; }
        public string SelectedGenre { get; set; }
        public string SearchActor { get; set; }
        public int SelectedYear { get; set; }
        public int SelectedUser { get; set; }

        // Konstruktor
        public IndexModel(NetHubContext context)
        {
            _context = context;
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
                
                .OrderBy(x => x.Medium.Title)
                .AsQueryable();

            var series = _context.Series
                .Include(x => x.Seasons)
                    .ThenInclude(x => x.Episodes)
                .OrderBy(x => x.Title)
                .AsQueryable();

            if (userId != 0)
            {
                var user = _context.Accounts.FirstOrDefault(x => x.ID == userId);
                movies = movies.Where(x => x.Rating.AgeLimit <= user.Age);
                
                if (history)
                {
                    movies = movies.Where(m => m.Medium.History.Any(x => x.Customer.ID == userId));
                }
                else
                {
                    movies = movies.Where(m => !m.Medium.History.Any(x => x.Customer.ID == userId));
                }
            }

            if (!String.IsNullOrEmpty(selectedGenre))
            {
                movies = movies.Where(m => m.MoviesGenres.Any(x => x.Genre.Name == selectedGenre));
                    
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
            }
            if (!String.IsNullOrEmpty(searchActor))
            {
                movies = movies
                    .Where(m => m.MoviesActors.Any(x => searchActor.ToLower().Contains(x.Actor.FirstName.ToLower()) 
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
            }

            var genres = _context.Genres
                .OrderBy(g => g.Name)
                .Select(g => g.Name);

            var users = _context.Accounts
                .Select(u => u.CustName);
            

            int[] years = Enumerable
                .Range(System.DateTime.Now.Year-100, 101)
                .ToArray();
            Array.Reverse(years);

            var viewOptions = new List<SelectListItem>
            {
                new SelectListItem{Text="New",Value="false"},
                new SelectListItem{Text="Watched",Value="true"}
            };


            UserId = userId;
            Users = await _context.Accounts.ToListAsync();

            Movies = await movies.Select(x => new MoviesVM(x)).ToListAsync();
            Series = await series.Select(x => new SeriesVM(x)).ToListAsync();

            Entries = new List<object>();
            foreach (var m in Movies)
            {
                Entries.Add(m);
            }
            foreach (var s in Series)
            {
                Entries.Add(s);
            }
            Entries.OrderBy(x => x.Title);

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
    }
}
