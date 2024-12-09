using Microsoft.AspNetCore.Mvc;
using EcoMvc.Models;

namespace EcoMvc.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Baguette", Price = 1.20m },
            new Product { Id = 2, Name = "Leclerc", Price = 4.50m }
        };
        public IActionResult Product()
        {
            return View(products);
        }

        public IActionResult ProductDetail(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Book A", TomeNumber = 1 },
            new Book { Id = 2, Title = "Book B", TomeNumber = 2 }
        };

        public IActionResult BookList()
        {
            return View(books);
        }

        public IActionResult BookDetail(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }

            return RedirectToAction("BookList");
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBook(Book newBook)
        {
            if (ModelState.IsValid)
            {
                newBook.Id = books.Count > 0 ? books.Max(b => b.Id) + 1 : 1;
                books.Add(newBook);
                return RedirectToAction("BookList");
            }

            return View(newBook);
        }
    }
}