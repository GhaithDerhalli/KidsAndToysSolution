using Microsoft.AspNetCore.Mvc;

namespace KidsAndToys.Controllers
{
    public class ProductsController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }

        [Route("newads")]
        [HttpGet]
        public IActionResult NewAds()
        {
            return Content("test");
            //return View();
        }

    }
}
