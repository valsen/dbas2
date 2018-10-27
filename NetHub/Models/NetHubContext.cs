using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
    }
}