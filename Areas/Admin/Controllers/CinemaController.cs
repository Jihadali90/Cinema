using Cinema_APP.Models;
using Cinema_APP.Utilities;
using Cinema_APP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.IO;


namespace Cinema_APP.Areas.Admin.Controllers
{
    [Area(SD.Admin_Area)]
    public class CinemaController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index(string? name, int page = 1)
        {
            var cinema = _context.Cinemas.AsNoTracking().AsQueryable();

            if (name is not null)
            {
                cinema = cinema.Where(c => c.Name.Contains(name));


            }
            if (page < 1)
            {
                page = 1;
            }
            int CurrentPage = page;
            double Totalpages = Math.Ceiling(cinema.Count() / 5.0);
            cinema = cinema.Skip((page - 1) * 5).Take(5);

            return View(new CinemaVM
            {
                cinemas = cinema.ToList(),
                TotalPages = Totalpages,
                CurrentPage = page
            });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cinema cinema, IFormFile main_Img)
        {
            if (main_Img is not null && main_Img.Length > 0)
            {
                var newFilename = $"{Guid.NewGuid()}{Path.GetExtension(main_Img.FileName)}_{DateTime.Now.ToString("yyyyMMddHHmmss")}";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\CinemaImg", newFilename);
                using (var stream = System.IO.File.Create(filePath))
                {
                    main_Img.CopyTo(stream);
                }
                cinema.Main_Img = newFilename;
            }

            _context.Cinemas.Add(cinema);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Cinema = _context.Cinemas.Find(id);

            if (Cinema is null)
            {
                return NotFound();
            }

            return View(Cinema);
        }
        [HttpPost]
        [HttpPost]
        public IActionResult Edit(Cinema cinema, IFormFile? main_img)
        {
           Cinema cinemaDB = _context.Cinemas.AsNoTracking().FirstOrDefault(e => e.Id == cinema.Id);

            if (cinemaDB is null) return NotFound();

            if (main_img != null && main_img.Length > 0)
            {
                var newImgName = $"{Guid.NewGuid()}{Path.GetExtension(main_img.FileName)}";

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CinemaImg", newImgName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    main_img.CopyTo(stream);

                }
                //Delete oldpic
                var OldImgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CinemaImg", cinemaDB.Main_Img);

                if (System.IO.File.Exists(OldImgPath))
                {
                    System.IO.File.Delete(OldImgPath);
                }

                cinema.Main_Img = newImgName;
            }
            else
            {
                cinema.Main_Img = cinemaDB.Main_Img;
            }
                _context.Cinemas.Update(cinema);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
       
        public IActionResult Delete(int id)
        {
            var Cinema = _context.Cinemas.Find(id);
            if (Cinema is null)
            {
                return NotFound();
            }
            var OldImgPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CinemaImg", Cinema.Main_Img);

            if (System.IO.File.Exists(OldImgPath))
            {
                System.IO.File.Delete(OldImgPath);
            }

            _context.Cinemas.Remove(Cinema);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
