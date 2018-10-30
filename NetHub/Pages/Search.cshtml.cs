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
    public class SearchModel : PageModel
    {
        private readonly NetHubContext _context;

        public IList<MoviesVM> Movies { get; set; }
        public SelectList Genres { get; set; }
        public SelectList Years { get; set; }
        public string SearchTitle { get; set; }
        public string SelectGenre { get; set; }
        public string SearchActor { get; set; }
        public int SelectYear { get; set; }

        public SearchModel(NetHubContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync(string searchTitle, string selectGenre, string searchActor, int selectYear)
        {
            var movies = _context.Movies
                .Include(x => x.MoviesDirectors)
                    .ThenInclude(x => x.Director)
                .Include(x => x.MoviesActors)
                    .ThenInclude(x => x.Actor)
                .Include(x => x.MoviesGenres)
                    .ThenInclude(x => x.Genre)
                .Include(x => x.MoviesLanguages)
                    .ThenInclude(x => x.Language)
                .OrderBy(x => x.Title)
                .AsQueryable();
                
            if (!String.IsNullOrEmpty(selectGenre))
            {
                movies = movies.Where(m => m.MoviesGenres.Any(x => x.Genre.Name == selectGenre));
                    
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
                movies = movies.Where(x => x.Title.ToLower().Contains(searchTitle.ToLower()));
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
            if (selectYear > 0)
            {
                movies = movies.Where(x => x.Year == selectYear);
            }

            var genres = _context.Genres
                .OrderBy(g => g.Name)
                .Select(g => g.Name);

            int[] years = Enumerable
                .Range(System.DateTime.Now.Year-100, 101)
                .ToArray();
            Array.Reverse(years);

            Movies = await movies.Select(x => new MoviesVM(x)).ToListAsync();
            Genres = new SelectList(await genres.ToListAsync());
            Years = new SelectList(years);
            SearchTitle = searchTitle;
            SelectGenre = selectGenre;
            SearchActor = searchActor;
            SelectYear = selectYear;
        }
    }
}
