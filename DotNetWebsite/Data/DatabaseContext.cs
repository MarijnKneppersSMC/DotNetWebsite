using DotNetWebsite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebsite.Data
{
    public class DatabaseContext : IdentityDbContext<IdentityUser>
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
			modelBuilder.Entity<Movie>().HasKey(m => m.Id);
            modelBuilder.Entity<Movie>().ToTable("movies");
        }
    }
}