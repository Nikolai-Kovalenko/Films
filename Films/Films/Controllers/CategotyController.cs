using Microsoft.AspNetCore.Mvc;

namespace Films.Controllers
{
    public class CategotyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
