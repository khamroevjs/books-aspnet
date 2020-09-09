using Microsoft.EntityFrameworkCore;

namespace BooksMVC.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
    }
}
