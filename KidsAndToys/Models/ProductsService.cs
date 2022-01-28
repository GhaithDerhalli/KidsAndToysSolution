using KidsAndToys.Models.Entities;
using KidsAndToys.Views.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidsAndToys.Models
{
    public class ProductsService
    {
        KidsAndToysDBContext kidsAndToysDBContext;
        IHttpContextAccessor accessor;
        UserManager<IdentityUser> userManager;

        public ProductsService(KidsAndToysDBContext kidsAndToysDBContext, IHttpContextAccessor accessor, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.kidsAndToysDBContext = kidsAndToysDBContext;
            this.accessor = accessor;
        }

        public MyAdsVM[] GetAllUserProducts()
        {
            string userId = userManager.GetUserId(accessor.HttpContext.User);

            return kidsAndToysDBContext.Products
                .Where(o => o.UserId == userId) 
                .Select(o => new MyAdsVM
                {
                    ProductName = o.ProductName,
                    Price = o.Price,
                })
                .ToArray();
        }

        public MyAdsVM[] GetAllProducts()
        {
            return kidsAndToysDBContext.Products
                .Select(o => new MyAdsVM
                {
                    ProductName = o.ProductName,
                    Price = o.Price,
                })
                .ToArray();
        }

        public NewAdsVM GetDropDownLists()
        {
            return new NewAdsVM
            {

                Category = kidsAndToysDBContext.Categories
                .OrderBy(x => x.Id)
                .Select(x => new SelectListItem(
                    x.Title, x.Id.ToString()))
                .ToArray(),

                Age = kidsAndToysDBContext.Ages
                .OrderBy(x => x.Id)
                .Select(x => new SelectListItem(
                    x.Title, x.Id.ToString()))
                .ToArray(),
                
                Condition = kidsAndToysDBContext.Conditions
                .OrderBy(x => x.Id)
                .Select(x => new SelectListItem(
                    x.Title, x.Id.ToString()))
                .ToArray(),

                City = kidsAndToysDBContext.Cities
                .OrderBy(x => x.Id)
                .Select(x => new SelectListItem(
                    x.Title, x.Id.ToString()))
                .ToArray(),

            };

        }
        internal void AddAd(NewAdsVM viewModel)
        { 

            string userId = userManager.GetUserId(accessor.HttpContext.User);

            var query = kidsAndToysDBContext.Products
                .Add(new Product
                {
                    UserId = userId,
                    ProductName = viewModel.ProductName,
                    CategoryId = viewModel.CategoryValue,
                    AgeId = viewModel.AgeValue,
                    ConditionId = viewModel.ConditionValue,
                    ConditionDescription = viewModel.ConditionDescription,
                    Price = viewModel.Price,
                    Description = viewModel.Description,
                    CityId = viewModel.CityValue

                }) ;
            kidsAndToysDBContext.SaveChanges();
        }
    }



}

