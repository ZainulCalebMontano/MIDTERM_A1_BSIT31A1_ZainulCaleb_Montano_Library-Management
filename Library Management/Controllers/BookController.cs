using Library_Management.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            var books = BookService.Instance.GetBooks();
            return View(books);
        }

        public IActionResult Add()
        {
            return View();
        }

        // Modal GET for Add Book
        public IActionResult AddModal()
        {
            return PartialView("_AddBookPartial", new AddBookViewModel());
        }

        [HttpPost]
        public IActionResult Add(AddBookViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BookService.Instance.AddBook(vm);
            return Ok();
        }

        public IActionResult EditModal(Guid id)
        {
            var editBookViewModel = BookService.Instance.GetBookById(id);
            if (editBookViewModel == null) return NotFound();
            return PartialView("_EditBookPartial", editBookViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EditBookViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BookService.Instance.UpdateBook(vm);
            return Ok();
        }

        public IActionResult Details(Guid id)
        {
            var book = BookService.Instance.GetBooks().First(b => b.BookId == id);
            return View(book);
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            BookService.Instance.DeleteBook(id);
            return Ok();
        }

        // Add BookCopy modal GET
        public IActionResult AddCopyModal(Guid bookId)
        {
            var vm = new AddBookCopyViewModel { BookId = bookId };
            return PartialView("_AddBookCopyPartial", vm);
        }

        // Add BookCopy modal POST
        [HttpPost]
        public IActionResult AddCopy(AddBookCopyViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            BookService.Instance.AddBookCopy(vm);
            return Ok();
        }
    }
}
