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
        public DbSet<Film_сategory> Film_categories { get; set; }
    }
}
