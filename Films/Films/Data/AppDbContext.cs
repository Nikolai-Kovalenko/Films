using Films.Models;
using Microsoft.EntityFrameworkCore;

namespace Films.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Film> Films { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FilmCategory> FilmCategories { get; set; }
    }
}
