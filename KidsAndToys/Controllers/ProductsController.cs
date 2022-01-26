﻿using KidsAndToys.Models;
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
            this.productsService =  productsService;
            this.usersService =  usersService;
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
        [Authorize]
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
