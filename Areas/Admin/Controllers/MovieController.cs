using Cinema_APP.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Cinema_APP.Areas.Admin.Controllers
{
    [Area(SD.Admin_Area)]
    public class MovieController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index(string? name, int page = 1)
        {
            var Movies = _context.Movies
                .Include(m => m.Category)
                .Include(c =>c.Cinema)
                .AsNoTracking()
                .AsQueryable();

            if (name is not null)
            {
                Movies = Movies.Where(c => c.Name.Contains(name));
            }

            if (page < 1)
            {
                page = 1;
            }

            int CurrentPage = page;
            double Totalpages = Math.Ceiling(Movies.Count() / 5.0);

            Movies = Movies.Skip((page - 1) * 5).Take(5);

            return View(new MoviesVM
            {
                Movies = Movies.ToList(),
                TotalPages = Totalpages,
                CurrentPage = CurrentPage
            });
        }
    }
}
