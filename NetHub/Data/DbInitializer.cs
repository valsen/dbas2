using System;
using System.Linq;
using NetHub.Models;

namespace NetHub.Models
{
    public static class DbInitializer
    {
        public static void Initialize(NetHubContext context)
        {
            context.Database.EnsureCreated();

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
                new Genre{Name="Sci-Fi"},
                new Genre{Name="Adventure"},
                new Genre{Name="Family"},
                new Genre{Name="Biography"},
                new Genre{Name="History"},
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
            foreach (GenreOf g in genreOf)
            {
                context.GenreOf.Add(g);
            }
            context.SaveChanges();

            var prodCompanies = new ProdCompany[]
            {
                new ProdCompany{Name="Warner Bros."},
                new ProdCompany{Name="Regency Enterprises"},
                new ProdCompany{Name="River Road Entertainment"}
            };
            foreach (ProdCompany p in prodCompanies)
            {
                context.ProdCompanies.Add(p);
            }
            context.SaveChanges();

            var prodCompFor = new ProdCompanyFor[]
            {
                new ProdCompanyFor{ProdCompanyID=1,MovieID=1},
                new ProdCompanyFor{ProdCompanyID=1,MovieID=2},
                new ProdCompanyFor{ProdCompanyID=2,MovieID=3},
                new ProdCompanyFor{ProdCompanyID=3,MovieID=3},
            };
            foreach (ProdCompanyFor p in prodCompFor)
            {
                context.ProdCompanyFor.Add(p);
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
            foreach (ActsIn a in actsIn)
            {
                context.ActsIn.Add(a);
            }
            context.SaveChanges();

            var directors = new Director[]
            {
                new Director{FirstName="Lana",LastName="Wachowski",Birthdate=new DateTime(1965, 06, 21)},
                new Director{FirstName="Lilly",LastName="Wachowski",Birthdate=new DateTime(1967, 12, 29)},
                new Director{FirstName="Steve",LastName="McQueen",Birthdate=new DateTime(1969, 10, 09)},
                new Director{FirstName="Chris",LastName="Columbus",Birthdate=new DateTime(1958, 09, 10)},
            };
            foreach(var d in directors)
            {
                context.Add(d);
            }
            context.SaveChanges();

            var directorOf = new DirectorOf[]
            {
                new DirectorOf{DirectorID=1,MovieID=1},
                new DirectorOf{DirectorID=2,MovieID=1},
                new DirectorOf{DirectorID=3,MovieID=3},
                new DirectorOf{DirectorID=4,MovieID=2},
            };
            foreach (DirectorOf d in directorOf)
            {
                context.DirectorOf.Add(d);
            }
            context.SaveChanges();
        }
    }
}