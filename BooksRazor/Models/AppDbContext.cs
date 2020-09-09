using Microsoft.EntityFrameworkCore;

namespace BooksRazor.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
    }
}
