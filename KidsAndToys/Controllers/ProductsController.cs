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
            return Content("new ads");
            //return View();
        }

        [Route("createuser")]
        [HttpGet]
        public IActionResult CreateUser()
        {
            return Content("new user");
            //return View();
        }
        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return Content("login");
            //return View();
        }

        [Route("myads")]
        [HttpGet]
        public IActionResult MyAds()
        {
            return Content("Mina annonser");
            //return View();
        }


        [Route("listofads")]
        [HttpGet]
        public IActionResult ListOfAds()
        {
            return Content("lista av annonser");
            //return View();
        }

        [Route("details")]
        [HttpGet]
        public IActionResult Details()
        {
            return Content("details");
            //return View();
        }


    }
}
