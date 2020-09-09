using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BooksRazor.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext db;

        public CreateModel(AppDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await db.Book.AddAsync(Book);
                await db.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
