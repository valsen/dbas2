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
                new Movie
                {
                    Title="The Matrix",
                    Year=1999,
                    Description="A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    ImgPath="images/thematrix.jpg",
                    Language="English",
                    Runtime=136
                },
                new Movie
                {
                    Title="Harry Potter and the Chamber of Secrets",
                    Year=2002,
                    Description="An ancient prophecy seems to be coming true when a mysterious presence begins stalking the corridors of a school of magic and leaving its victims paralyzed.",
                    ImgPath="images/harrypotterandthechamberofsecrets.jpg",
                    Language="English",
                    Runtime=161
                },
                new Movie
                {
                    Title="12 Years a Slave",
                    Year=2013,
                    Description="In the antebellum United States, Solomon Northup, a free black man from upstate New York, is abducted and sold into slavery.",
                    ImgPath="images/12yearsaslave.jpg",
                    Language="English",
                    Runtime=134
                }
            };
            foreach (Movie m in movies)
            {
                context.Movies.Add(m);
            }
            context.SaveChanges();

            var genreOf = new GenreOf[]
            {
                new GenreOf{GenreID=1,MovieID=1},
                new GenreOf{GenreID=7,MovieID=1},
                new GenreOf{GenreID=2,MovieID=2},
                new GenreOf{GenreID=8,MovieID=2},
                new GenreOf{GenreID=9,MovieID=2},
                new GenreOf{GenreID=4,MovieID=3},
                new GenreOf{GenreID=10,MovieID=3},
                new GenreOf{GenreID=11,MovieID=3},
            };

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
                new Actor{FirstName="Rupert",LastName="Grint",Birthdate=new DateTime(1988, 08, 24)},
                new Actor{FirstName="Emma",LastName="Watson",Birthdate=new DateTime(1990, 04, 15)},
                new Actor{FirstName="Chiwetel",LastName="Ejiofor",Birthdate=new DateTime(1977, 07, 10)},
                new Actor{FirstName="Michael",LastName="Fassbender",Birthdate=new DateTime(1977, 04, 02)},
            };
            foreach(Actor a in actors)
            {
                context.Actors.Add(a);
            }
            context.SaveChanges();

            var actsIn = new ActsIn[]
            {
                new ActsIn{ActorID=1,MovieID=1},
                new ActsIn{ActorID=2,MovieID=2},
                new ActsIn{ActorID=3,MovieID=2},
                new ActsIn{ActorID=4,MovieID=2},
                new ActsIn{ActorID=5,MovieID=3},
                new ActsIn{ActorID=6,MovieID=3},
            };
        }
    }
}