using KidsAndToys.Models;
using KidsAndToys.Views.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace KidsAndToys.Controllers
{
    public class ProductsController : Controller
    {
        UsersService usersService;
        ProductsService productsService;
        public ProductsController(ProductsService productsService, UsersService usersService)
        {
            this.productsService = productsService;
            this.usersService = usersService;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Home()
        {
            return View();
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
        [Authorize]
        [Route("newads")]
        [HttpGet]
        public IActionResult NewAds()
        {
            var viewModel = productsService.GetDropDownLists();
            return View(viewModel);
        }
        [Authorize]
        [Route("newads")]
        [HttpPost]
        public IActionResult NewAds(NewAdsVM viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = productsService.GetDropDownLists();
                return View(viewModel);
            }
            productsService.AddAd(viewModel);
            return RedirectToAction(nameof(Home));
        }

        [Route("createuser")]
        [HttpGet]
        public IActionResult CreateUser()
        {
            //return Content("new user");
            return View();
        }
        [Route("createuser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Try to register user
            var errorMessage = await usersService.TryRegisterAsync(viewModel);
            if (errorMessage != null)
            {
                // Show error
                ModelState.AddModelError(string.Empty, errorMessage);
                return View(viewModel);
            }

            // Redirect user
            return RedirectToAction(nameof(Login));
        }
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            //return Content("login");
            return View();
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(LogInVM viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Check if credentials is valid (and set auth cookie)
            var success = await usersService.TryLoginAsync(viewModel);
            if (!success)
            {
                // Show error
                ModelState.AddModelError(nameof(LogInVM.Username), "Login failed");
                return View(viewModel);
            }

            // Redirect user
            return RedirectToAction(nameof(Home));
        }

        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await usersService.LogOutAsync();
            return RedirectToAction(nameof(Login));

        }


        [Authorize]
        [Route("myads")]
        [HttpGet]
        public IActionResult MyAds()
        {
            var model = productsService.GetAllUserProducts();
            return View(model);
        }
        [Authorize]
        [Route("delete/{id}")]
        [HttpGet]
        public IActionResult Delete(MyAdsVM viewModel)
        {
            productsService.DeleteProduct(viewModel);
            return RedirectToAction(nameof(MyAds));
        }

        [Route("listofads")]
        [HttpGet]
        public IActionResult ListOfAds()
        {
            var model = productsService.GetAllProducts();
            return View(model);
        }
        //[Route("listofads")]
        //[HttpPost]
        //public IActionResult ListOfAds(SearchVM viewModel)
        //{
        //    var model = productsService.SearchProducts(viewModel);
        //    return View(model);
        //}

        [Route("details/{id}")]
        [HttpGet]
        public IActionResult Details(DetailsVM modelView)
        {
            var model = productsService.GetDetails(modelView);
            return View(model);
        }

        [Route("search")]
        [HttpGet]
        public IActionResult Search()
        {

            return View();
        }

        [Route("search")]
        [HttpPost]
        public IActionResult Search(SearchVM viewModel)
        {
            var model = productsService.SearchProducts(viewModel);
            return View(model);
        }
        //[Route("search/{id}")]
        //[HttpPost]
        //public IActionResult DetailSearch(SearchVM viewModel)
        //{
        //    var model = productsService.GetDetailsSearch(viewModel);
        //    return View(model);
        //}

        [Route("contact")]
        [HttpGet]
        public IActionResult Contact()
        {
            return View();
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