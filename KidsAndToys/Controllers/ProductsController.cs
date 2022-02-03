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
            if (!String.IsNullOrEmpty(HttpContext.Request.Query["SearchWord"]))
            {
                var model = productsService.SearchProducts(HttpContext.Request.Query["SearchWord"]);
                return View(model);
            }
            else
            return View();
        }

        [Route("search/{searchedWord}")]
        [HttpGet]
        public IActionResult Search(string searchedWord)
        {
            var model = productsService.SearchProducts(searchedWord);
            if (model == null)
            {
                return View();
            }
            return View(model);
        }
        



    }
}