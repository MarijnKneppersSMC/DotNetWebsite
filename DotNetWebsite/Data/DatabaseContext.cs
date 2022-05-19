using DotNetWebsite.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebsite.Data
{
    public class DatabaseContext : DbContext
    {

        //disabled warning because everything is defined in OnModelCreating
#pragma warning disable CS8618
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
#pragma warning restore CS8618

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("Movies");
        }
    }
}