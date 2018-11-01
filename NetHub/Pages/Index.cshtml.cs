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

        //public IList<MoviesVM> Movies { get; set; }
        public IList<MediaVM> Media { get; set; }
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
            var media = _context.Media
                .Include(x => x.Rating)
                .Include(x => x.MediaDirectors)
                    .ThenInclude(x => x.Director)
                .Include(x => x.MediaActors)
                    .ThenInclude(x => x.Actor)
                .Include(x => x.MediaGenres)
                    .ThenInclude(x => x.Genre)
                .Include(x => x.MediaLanguages)
                    .ThenInclude(x => x.Language)
                .Include(x => x.MovieHistories)
                    .ThenInclude(x => x.Customer)
                .OrderBy(x => x.Title)
                .AsQueryable();

            if (userId != 0)
            {
                var user = _context.Accounts.FirstOrDefault(x => x.ID == userId);
                media = media.Where(x => x.Rating.AgeLimit <= user.Age);
                
                if (history)
                {
                    media = media.Where(m => m.MovieHistories.Any(x => x.Customer.ID == userId));
                }
                else
                {
                    media = media.Where(m => !m.MovieHistories.Any(x => x.Customer.ID == userId));
                }
            }

            if (!String.IsNullOrEmpty(selectedGenre))
            {
                media = media.Where(m => m.MediaGenres.Any(x => x.Genre.Name == selectedGenre));
                    
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
                media = media.Where(x => x.Title.ToLower().Contains(searchTitle.ToLower()));
            }
            if (!String.IsNullOrEmpty(searchActor))
            {
                media = media
                    .Where(m => m.MediaActors.Any(x => searchActor.ToLower().Contains(x.Actor.FirstName.ToLower()) 
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
                media = media.Where(x => x.Year == selectedYear);
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
            //Movies = await media.Select(x => new MoviesVM(x)).ToListAsync();
            Media = await media.Select(x => new MediaVM(x)).ToListAsync();
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
