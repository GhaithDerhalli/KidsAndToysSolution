using Microsoft.AspNetCore.Mvc;

namespace KidsAndToys.Controllers
{
    public class ProductsController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Home()
        {
            return Content("Home");
        }
    }
}
