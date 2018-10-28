using System;
using System.Linq;
using NetHub.Models;

namespace NetHub.Models
{
    public static class DbInitializer
    {
        public static void Initialize(NetHubContext context)
        {
            //context.Database.EnsureCreated();

            // Check for any existing data
            if (context.Movies.Any())
            {
                return; //DB already seeded
            }

            var genres = new Genre[]
            {
                new Genre{Name="Action"},
                new Genre{Name="Fantasy"},
                new Genre{Name="Comedy"},
                new Genre{Name="Drama"},
                new Genre{Name="Horror"},
                new Genre{Name="Thriller"},
                new Genre{Name="Science Fiction"}
            };
            foreach (Genre g in genres)
            {
                context.Genres.Add(g);
            }
            context.SaveChanges();

            var movies = new Movie[]
            {
                new Movie{Title="The Matrix",Year=1999,Language="English",Runtime=136},
                new Movie{Title="Harry Potter and the Chamber of Secrets",Year=2002,Language="English",Runtime=161}
            };
            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();

            var prodCompanies = new ProdCompany[]
            {
                new ProdCompany{Name="Warner Bros."}
            };
            foreach (ProdCompany p in prodCompanies)
            {
                context.ProdCompanies.Add(p);
            }
            context.SaveChanges();

            var actors = new Actor[]
            {
                new Actor{FirstName="Keanu",LastName="Reeves",Birthdate=new DateTime(1964, 09, 02)},
                new Actor{FirstName="Daniel",LastName="Radcliffe",Birthdate=new DateTime(1989, 07, 23)},
            };
            foreach(Actor a in actors)
            {
                context.Actors.Add(a);
            }
            context.SaveChanges();
        }
    }
}