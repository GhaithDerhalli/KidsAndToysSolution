using KidsAndToys.Models;
using Microsoft.AspNetCore.Mvc;

namespace KidsAndToys.Controllers
{
    public class CategoriesController : Controller
    {
        UsersService usersService;
        ProductsService productsService;
        public CategoriesController(ProductsService productsService, UsersService usersService)
        {
            this.productsService = productsService;
            this.usersService = usersService;
        }
        [Route("clothes")]
        [HttpGet]
        public IActionResult ClothesCategory()
        {
            var viewModel = productsService.ShowClothesCategory();
            return View(viewModel);
        }
        [Route("shoes")]
        [HttpGet]
        public IActionResult ShoesCategory()
        {
            var viewModel = productsService.ShowShoesCategory();
            return View(viewModel);
        }
        [Route("toys")]
        [HttpGet]
        public IActionResult ToysCategory()
        {
            var viewModel = productsService.ShowToysCategory();
            return View(viewModel);
        }
        [Route("accessories")]
        [HttpGet]
        public IActionResult AccessoriesCategory()
        {
            var viewModel = productsService.ShowAccessoriesCategory();
            return View(viewModel);
        }
        [Route("others")]
        [HttpGet]
        public IActionResult OtherCategory()
        {
            var viewModel = productsService.ShowOtherCategory();
            return View(viewModel);
        }
    }
}
