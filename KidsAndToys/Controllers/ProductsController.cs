using Microsoft.AspNetCore.Mvc;

namespace KidsAndToys.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
