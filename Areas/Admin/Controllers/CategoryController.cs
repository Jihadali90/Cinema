using Cinema_APP.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Cinema_APP.Areas.Admin.Controllers
{
    [Area(SD.Admin_Area)]
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index(string? name, int page = 1)
        {
            var Categories = _context.Categories.AsNoTracking().AsQueryable();

            // adding Filter by name 
            if (name is not null)
            {
                Categories = Categories.Where(c => c.Name.Contains(name));
            }
            //pagination 
            if (page < 1)
            {
                page = 1;
            }
            int CurrentPage = page;
            double Totalpages = Math.Ceiling(Categories.Count() / 5.0);
            Categories = Categories.Skip((page - 1) * 5).Take(5);


            return View(new CategoriesVM
            {
                Categories = Categories.ToList(),
                TotalPages = Totalpages,
                CurrentPage = CurrentPage
            });

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {


            _context.Categories.Add(category);
            _context.SaveChanges();



            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {

            var category = _context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
