using KidsAndToys.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidsAndToys.Controllers
{
    public class SidePagesController : Controller
    {
        UsersService usersService;
        ProductsService productsService;
        public SidePagesController(ProductsService productsService, UsersService usersService)
        {
            this.productsService = productsService;
            this.usersService = usersService;
        }

        [Route("policy")]
        [HttpGet]
        public IActionResult Policy()
        {
            return View();
        }

        [Route("about")]
        [HttpGet]
        public IActionResult About()
        {
            return View();
        }
    }
}
