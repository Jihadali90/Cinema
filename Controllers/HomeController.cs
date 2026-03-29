using Cinema_APP.Models;
using Cinema_APP.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Linq;


namespace Cinema_APP.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? CategoryId)
        {
            var Movies = _context.Movies
                .Include(e=>e.Category)
                .Skip(0)
                .Take(8);

            var Categories = _context.Categories.Include (e => e.Movies).AsQueryable();

            if (CategoryId is not null)
            {
                Movies = Movies.Where(e => e.CategoryId == CategoryId);
            }

           

            return View(new MoviesWithCategoriesVM
            {
                Categories = Categories.ToList(),
                Movies = Movies.ToList()

            });



        }

        public IActionResult MovieDetails(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(NotfoundPage));
            }

            var movie = _context.Movies
                        .SingleOrDefault(e => e.Id == id);

            if (movie == null)
            {
                return RedirectToAction(nameof(NotfoundPage));
            }

            return View(movie);
        }
        public IActionResult NotfoundPage()
        {
            return View();
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
