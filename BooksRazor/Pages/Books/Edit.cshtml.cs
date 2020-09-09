using System.Threading.Tasks;
using BooksRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksRazor.Pages.Books
{
    public class EditModel : PageModel
    {
        private AppDbContext db;

        public EditModel(AppDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task OnGet(int id)
        {
            Book = await db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var bookFromDb = await db.Book.FindAsync(Book.Id);

                bookFromDb.Name = Book.Name;
                bookFromDb.ISBN = Book.ISBN;
                bookFromDb.Author = Book.Author;

                await db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
