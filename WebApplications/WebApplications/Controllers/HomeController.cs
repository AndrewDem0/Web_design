using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplications.Data;
using WebApplications.Models;

namespace WebApplications.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var user = HttpContext.User.Identity.Name;
            //отримуємо з БД всі об'єкти Boоk
            IEnumerable<Book> books = _dbContext.Books;
            //передаємо всі об'єкти в динамічну властивість Books y ViewBag
            ViewBag.Books = books;
            //повертаємо відображення
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Create(Book book)
        {
            if (book != null)
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}