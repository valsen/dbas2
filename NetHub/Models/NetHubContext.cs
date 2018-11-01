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
        public DbSet<Medium> Media { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<MediaActor> MoviesActors { get; set; }
        public DbSet<MediaDirector> MoviesDirectors { get; set; }
        public DbSet<MediaGenre> MoviesGenres { get; set; }
        public DbSet<MovieHistory> MovieHistories { get; set; }
        public DbSet<MediaLanguage> MoviesLanguages { get; set; }
        public DbSet<MediaCaptioning> MoviesCaptions { get; set; }
        public DbSet<MediaProdcompany> MoviesProdcompanies { get; set; }
        public DbSet<ProdCompany> ProdCompanies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.NamesToSnakeCase();

            modelBuilder.Entity<MediaGenre>()
                .HasKey(g => new { g.MediaID, g.GenreID });

            modelBuilder.Entity<MediaActor>()
                .HasKey(a => new { a.MediaID, a.ActorID });

            modelBuilder.Entity<MediaDirector>()
                .HasKey(d => new { d.MediaID, d.DirectorID });

            modelBuilder.Entity<MediaLanguage>()
                .HasKey(l => new { l.MediaID, l.LanguageID });

            modelBuilder.Entity<MediaCaptioning>()
                .HasKey(c => new { c.MediaID, c.LanguageID });

            modelBuilder.Entity<MediaProdcompany>()
                .HasKey(p => new { p.MediaID, p.ProdCompanyID });
        }
    }

}