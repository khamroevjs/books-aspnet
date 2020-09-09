using System.Collections.Generic;
using System.Threading.Tasks;
using BooksRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BooksRazor.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext db;

        public IndexModel(AppDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int? id)
        {
            var book = await db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            db.Book.Remove(book);
            await db.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
