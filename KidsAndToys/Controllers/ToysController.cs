using Microsoft.AspNetCore.Mvc;

namespace KidsAndToys.Controllers
{
    public class ToysController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
