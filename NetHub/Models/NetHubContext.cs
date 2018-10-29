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
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieActor> MoviesActors { get; set; }
        public DbSet<MovieDirector> MoviesDirectors { get; set; }
        public DbSet<MovieGenre> MoviesGenres { get; set; }
        public DbSet<MovieHistory> MovieHistories { get; set; }
        public DbSet<MovieLanguage> MoviesLanguages { get; set; }
        public DbSet<MovieProdcompany> MoviesProdcompanies { get; set; }
        public DbSet<ProdCompany> ProdCompanies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.NamesToSnakeCase();

            modelBuilder.Entity<MovieGenre>()
                .HasKey(g => new { g.MovieID, g.GenreID });

            modelBuilder.Entity<MovieActor>()
                .HasKey(a => new { a.MovieID, a.ActorID });

            modelBuilder.Entity<MovieDirector>()
                .HasKey(d => new { d.MovieID, d.DirectorID });

            modelBuilder.Entity<MovieLanguage>()
                .HasKey(l => new { l.MovieID, l.LanguageID });

            modelBuilder.Entity<MovieProdcompany>()
                .HasKey(p => new { p.MovieID, p.ProdCompanyID });
        }
    }

}