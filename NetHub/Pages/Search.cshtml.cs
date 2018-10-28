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
        public string SearchString { get; set; }
        public string SelectGenre { get; set; }
        public string SearchActor { get; set; }

        public SearchModel(NetHubContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync(string searchString, string selectGenre, string searchActor)
        {
            var movies = await _context.Movies
                .Include(x => x.DirectorOf)
                .Include(x => x.ActsIns)
                    .ThenInclude(x => x.Actor)
                .Include(x => x.GenreOf)
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

            var genres = _context.Genres
                .OrderBy(g => g.Name)
                .Select(g => g.Name);

            Movies = movies;
            Genres = new SelectList(await genres.ToListAsync());
            SearchString = searchString;
            SelectGenre = selectGenre;
            SearchActor = searchActor;
        }

        
    }
}
