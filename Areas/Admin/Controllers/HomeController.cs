using Cinema_APP.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Cinema_APP.Areas.Admin.Controllers
{
    [Area(SD.Admin_Area)]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
