using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BooksRazor.Models;

namespace BooksRazor.Controllers
{
    // This class for animation and second table
    [Route("api/Books")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly AppDbContext db;

        public BookController(AppDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            db.Book.Remove(bookFromDb);
            await db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }
    }
}
