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
        IWebHostEnvironment webHostEnv;

        public ProductsService(KidsAndToysDBContext kidsAndToysDBContext, IHttpContextAccessor accessor, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnv)
        {
            this.userManager = userManager;
            this.kidsAndToysDBContext = kidsAndToysDBContext;
            this.accessor = accessor;
            this.webHostEnv = webHostEnv;
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

        public ListOfAdsVM[] GetAllProducts()
        {
           
            return kidsAndToysDBContext.Products
                .Select(o => new ListOfAdsVM
                {
                    ProductName = o.ProductName,
                    Price = o.Price,
                    Condition = o.Condition,
                    City = o.City,
                    //AdsPic = o.AdsPic
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
            var filePath = Path.Combine(webHostEnv.WebRootPath, "Uploads", viewModel.AdsPic.FileName);
            // Save the file to disk
            using var fileStream = new FileStream(filePath, FileMode.Create);
            viewModel.AdsPic.CopyTo(fileStream);

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
                    CityId = viewModel.CityValue,
                    AdsPic = viewModel.AdsPic.FileName
                }) ;
            kidsAndToysDBContext.SaveChanges();
        }

        internal SearchVM[] SearchProducts(string viewModel)
        {
            var query = kidsAndToysDBContext.Products
                .Where(p => viewModel == p.ProductName)//viewModel == p.Category.ToString() ||  || viewModel == p.Age.ToString() || viewModel == p.City.ToString()
                .Select(p => new SearchVM
                {
                    ProductName = p.ProductName
                })
                .ToArray();
            return query;
                
        }
    }



}

