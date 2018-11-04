using System;
using System.Linq;
using NetHub.Models;

namespace NetHub.Models
{
    public static class DbInitializer
    {
        public static void Initialize(NetHubContext context)
        {
            context.Database.EnsureDeleted();
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


            var ratings = new Rating[]
            {
                new Rating{Name="G",AgeLimit=0},
                new Rating{Name="PG",AgeLimit=0},
                new Rating{Name="PG-13",AgeLimit=0},
                new Rating{Name="R",AgeLimit=17},
                new Rating{Name="NC-17",AgeLimit=17},
                new Rating{Name="UNRATED",AgeLimit=0},
                new Rating{Name="NOT RATED",AgeLimit=0},
                new Rating{Name="7",AgeLimit=7},
                new Rating{Name="11",AgeLimit=11},
                new Rating{Name="15",AgeLimit=15}
            };
            foreach (Rating r in ratings)
            {
                context.Add(r);
            }
            context.SaveChanges();

            var media = new Medium[]
            {
                new Medium
                {
                    Title="The Matrix",
                    Year=1999,
                    Description="A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                    ImgPath="images/thematrix.jpg",
                    //Runtime=136,
                    RatingID=4        
                },
                new Medium
                {
                    Title="Harry Potter and the Chamber of Secrets",
                    Year=2002,
                    Description="An ancient prophecy seems to be coming true when a mysterious presence begins stalking the corridors of a school of magic and leaving its victims paralyzed.",
                    ImgPath="images/harrypotterandthechamberofsecrets.jpg",
                    //Runtime=161,
                    RatingID=2
                },
                new Medium
                {
                    Title="12 Years a Slave",
                    Year=2013,
                    Description="In the antebellum United States, Solomon Northup, a free black man from upstate New York, is abducted and sold into slavery.",
                    ImgPath="images/12yearsaslave.jpg",
                    //Runtime=134,
                    RatingID=4
                }
            };
            foreach (Medium m in media)
            {
                context.Media.Add(m);
            }
            context.SaveChanges();

            // var movies = new Movie[]
            // {
            //     new Movie
            //     {
            //         Title="The Matrix",
            //         Year=1999,
            //         Description="A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
            //         ImgPath="images/thematrix.jpg",
            //         Runtime=136,
            //         RatingID=4
            //     },
            //     new Movie
            //     {
            //         Title="Harry Potter and the Chamber of Secrets",
            //         Year=2002,
            //         Description="An ancient prophecy seems to be coming true when a mysterious presence begins stalking the corridors of a school of magic and leaving its victims paralyzed.",
            //         ImgPath="images/harrypotterandthechamberofsecrets.jpg",
            //         Runtime=161,
            //         RatingID=2
            //     },
            //     new Movie
            //     {
            //         Title="12 Years a Slave",
            //         Year=2013,
            //         Description="In the antebellum United States, Solomon Northup, a free black man from upstate New York, is abducted and sold into slavery.",
            //         ImgPath="images/12yearsaslave.jpg",
            //         Runtime=134,
            //         RatingID=4
            //     }
            // };
            // foreach (Movie m in movies)
            // {
            //     context.Movies.Add(m);
            // }
            // context.SaveChanges();

            var moviesGenres = new MediaGenre[]
            {
                new MediaGenre{GenreID=1,MediaID=1},
                new MediaGenre{GenreID=7,MediaID=1},
                new MediaGenre{GenreID=2,MediaID=2},
                new MediaGenre{GenreID=8,MediaID=2},
                new MediaGenre{GenreID=9,MediaID=2},
                new MediaGenre{GenreID=4,MediaID=3},
                new MediaGenre{GenreID=10,MediaID=3},
                new MediaGenre{GenreID=11,MediaID=3},
            };
            foreach (MediaGenre g in moviesGenres)
            {
                context.MediaGenres.Add(g);
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

            var moviesProdcompanies = new MediaProdcompany[]
            {
                new MediaProdcompany{ProdCompanyID=1,MediaID=1},
                new MediaProdcompany{ProdCompanyID=1,MediaID=2},
                new MediaProdcompany{ProdCompanyID=2,MediaID=3},
                new MediaProdcompany{ProdCompanyID=3,MediaID=3},
            };
            foreach (MediaProdcompany p in moviesProdcompanies)
            {
                context.MoviesProdcompanies.Add(p);
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

            var moviesActors = new MediaActor[]
            {
                new MediaActor{ActorID=1,MediaID=1},
                new MediaActor{ActorID=2,MediaID=2},
                new MediaActor{ActorID=3,MediaID=2},
                new MediaActor{ActorID=4,MediaID=2},
                new MediaActor{ActorID=5,MediaID=3},
                new MediaActor{ActorID=6,MediaID=3},
            };
            foreach (MediaActor a in moviesActors)
            {
                context.MoviesActors.Add(a);
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

            var moviesDirectors = new MediaDirector[]
            {
                new MediaDirector{DirectorID=1,MediaID=1},
                new MediaDirector{DirectorID=2,MediaID=1},
                new MediaDirector{DirectorID=3,MediaID=3},
                new MediaDirector{DirectorID=4,MediaID=2},
            };
            foreach (MediaDirector d in moviesDirectors)
            {
                context.MediaDirectors.Add(d);
            }
            context.SaveChanges();

            var languages = new Language[]
            {
                new Language{Name="English"},
                new Language{Name="Swedish"},
                new Language{Name="Spanish"},
                new Language{Name="French"},
                new Language{Name="Italian"},
                new Language{Name="German"},
                new Language{Name="Japanese"}
            };
            foreach (Language l in languages)
            {
                context.Languages.Add(l);
            }
            context.SaveChanges();

            var moviesLanguages = new MediaLanguage[]
            {
                new MediaLanguage{MediaID=1,LanguageID=1},
                new MediaLanguage{MediaID=2,LanguageID=1},
                new MediaLanguage{MediaID=3,LanguageID=1},
            };
            foreach (MediaLanguage ml in moviesLanguages)
            {
                context.MoviesLanguages.Add(ml);
            }
            context.SaveChanges();

            var moviesCaptions = new MediaCaptioning[]
            {
                new MediaCaptioning{MediaID=1,LanguageID=1},
                new MediaCaptioning{MediaID=2,LanguageID=1},
                new MediaCaptioning{MediaID=3,LanguageID=1}
            };
            foreach (MediaCaptioning m in moviesCaptions)
            {
                context.MoviesCaptions.Add(m);
            }
            context.SaveChanges();

            var customers = new Account[]
            {
                new Account{CustName="Victor Josephson",Age=28,JoinDate=DateTime.Now.Date,PayStatus=PayStatus.Paid,ExpireDate=new DateTime(2018-12-31)},
                new Account{CustName="Child",Age=14,JoinDate=DateTime.Now.Date,PayStatus=PayStatus.Paid,ExpireDate=new DateTime(2018-12-31)}
            };
            foreach (Account a in customers)
            {
                context.Accounts.Add(a);
            }
            context.SaveChanges();

            var movieHistories = new History[]
            {
                new History{AccountID=1,MediumID=1,Date=DateTime.Now.Date,Rating=4},
                new History{AccountID=1,MediumID=3,Date=DateTime.Now.Date,Rating=5},
                new History{AccountID=2,MediumID=2,Date=DateTime.Now.Date,Rating=4},
            };
            foreach (History mh in movieHistories)
            {
                context.MovieHistories.Add(mh);
            }
            context.SaveChanges();
        }
    }
}