using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Extensions;

namespace NetHub.Models
{
    public class NetHubContext : DbContext
    {
        public NetHubContext(DbContextOptions<NetHubContext> options) 
            : base(options) 
        { 
        } 

        public DbSet<Actor> Actors { get; set; }
        public DbSet<ActsIn> ActsIn { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<DirectorOf> DirectorOf { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreOf> GenreOf { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ProdCompany> ProdCompanies { get; set; }
        public DbSet<ProdCompanyFor> ProdCompanyFor { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreOf>()
                .HasKey(g => new { g.MovieID, g.GenreID });

            modelBuilder.Entity<ActsIn>()
                .HasKey(a => new { a.MovieID, a.ActorID });

            modelBuilder.Entity<DirectorOf>()
                .HasKey(d => new { d.MovieID, d.DirectorID });

            modelBuilder.Entity<MovieLanguage>()
                .HasKey(l => new { l.MovieID, l.LanguageID });

            modelBuilder.Entity<ProdCompanyFor>()
                .HasKey(p => new { p.MovieID, p.ProdCompanyID });
        }
    }

}