using Microsoft.AspNetCore.Mvc;

namespace Films.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
