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
        public string SearchString { get; set; }
        public string SelectGenre { get; set; }
        public string SearchActor { get; set; }
        public int SelectYear { get; set; }

        public SearchModel(NetHubContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync(string searchString, string selectGenre, string searchActor, int selectYear)
        {
            var movies = await _context.Movies
                .Include(x => x.MoviesDirectors)
                .Include(x => x.MoviesActors)
                    .ThenInclude(x => x.Actor)
                .Include(x => x.MoviesGenres)
                    .ThenInclude(x => x.Genre)
                .OrderBy(x => x.Title)
                .Select(x => new MoviesVM(x))
                .ToListAsync();

            if (!String.IsNullOrEmpty(selectGenre))
            {
                movies.RemoveAll(m => !m.Genre.ToLower().Contains(selectGenre.ToLower()));
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                movies.RemoveAll(s => !s.Title.ToLower().Contains(searchString.ToLower()));
            }
            if (!String.IsNullOrEmpty(searchActor))
            {
                foreach(var movie in movies.ToList()){
                    Boolean match = false;
                    foreach(Actor actor in movie.Actors){
                        string fullName = String.Concat(actor.FirstName, " ", actor.LastName).ToLower();
                        if (fullName.Contains(searchActor.ToLower()))
                        {
                            match = true;
                        }
                    }
                    if (!match) movies.Remove(movie);
                }
            }
            if (selectYear > 0)
            {
                movies.RemoveAll(x => x.Year != selectYear);
            }

            var genres = _context.Genres
                .OrderBy(g => g.Name)
                .Select(g => g.Name);

            Movies = movies;
            Genres = new SelectList(await genres.ToListAsync());
            var list = new List<int>();
            int[] years = Enumerable
                .Range(System.DateTime.Now.Year-100, 101)
                .ToArray();
            Array.Reverse(years);
            Years = new SelectList(years);
            SearchString = searchString;
            SelectGenre = selectGenre;
            SearchActor = searchActor;
            SelectYear = selectYear;
        }

        
    }
}
