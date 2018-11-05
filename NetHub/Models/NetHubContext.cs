using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Extensions;
using NetHub.CustomExtensions;

namespace NetHub.Models
{
    public class NetHubContext : DbContext
    {
        public NetHubContext(DbContextOptions<NetHubContext> options) 
            : base(options) 
        { 
        } 

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<History> History { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<MediaDirector> MediaDirectors { get; set; }
        public DbSet<Medium> Media { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }
        public DbSet<MovieCaptioning> MoviesCaptions { get; set; }
        public DbSet<MovieGenre> MoviesGenres { get; set; }
        public DbSet<MovieLanguage> MoviesLanguages { get; set; }
        public DbSet<MovieProdcompany> MoviesProdcompanies { get; set; }
        public DbSet<ProdCompany> ProdCompanies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<SeriesActor> SeriesActors { get; set; }
        public DbSet<SeriesCaptioning> SeriesCaptions { get; set; }
        public DbSet<SeriesGenre> SeriesGenres { get; set; }
        public DbSet<SeriesLanguage> SeriesLanguages { get; set; }
        public DbSet<SeriesProdcompany> SeriesProdcompanies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.NamesToSnakeCase();

            modelBuilder.Entity<MovieGenre>()
                .HasKey(g => new { g.MovieID, g.GenreID });

            modelBuilder.Entity<SeriesGenre>()
                .HasKey(g => new { g.SeriesID, g.GenreID });

            modelBuilder.Entity<MovieActor>()
                .HasKey(a => new { a.MovieID, a.ActorID });

            modelBuilder.Entity<SeriesActor>()
                .HasKey(a => new { a.SeriesID, a.ActorID });

            modelBuilder.Entity<MediaDirector>()
                .HasKey(d => new { d.MediumID, d.DirectorID });

            modelBuilder.Entity<MovieLanguage>()
                .HasKey(l => new { l.MovieID, l.LanguageID });

            modelBuilder.Entity<SeriesLanguage>()
                .HasKey(l => new { l.SeriesID, l.LanguageID });

            modelBuilder.Entity<MovieCaptioning>()
                .HasKey(c => new { c.MovieID, c.LanguageID });

            modelBuilder.Entity<SeriesCaptioning>()
                .HasKey(c => new { c.SeriesID, c.LanguageID });

            modelBuilder.Entity<MovieProdcompany>()
                .HasKey(p => new { p.MovieID, p.ProdCompanyID });

            modelBuilder.Entity<SeriesProdcompany>()
                .HasKey(p => new { p.SeriesID, p.ProdCompanyID });
        }
    }

}