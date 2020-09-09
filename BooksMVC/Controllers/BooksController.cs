using System.Collections.Generic;
using System.Threading.Tasks;
using BooksMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksMVC.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext db;
        public BooksController(AppDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = db.Book;
            return View(books);
        }

        #region Create

        //GET - Create
        public IActionResult Create()
        {
            return View();
        }

        // POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book obj)
        {
            if (ModelState.IsValid)
            {
                await db.Book.AddAsync(obj);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        #endregion

        #region Edit

        // GET - Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = await db.Book.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Book obj)
        {
            if (ModelState.IsValid)
            {
                db.Book.Update(obj);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        #endregion

        #region Delete

        // POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            var book = await db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            db.Book.Remove(book);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        #endregion
    }
}
