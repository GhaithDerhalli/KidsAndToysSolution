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
        string[] clothes = { "Stövlar", "Strumpor", "Tröja", "Tshirt", "Jackor", "Kjol", "Klänning", "Byxor", "Body" };
        string[] games = { "Bredspel", "Dataspel", "Leksaker" };
        string[] shoes = {"Babyskor", "Idrottsskor", "Sneakers", "Stövlar"};
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
                    Picture = o.AdsPic
                })
                .ToArray();
        }

        public ListOfAdsVM[] GetAllProducts()
        {

            return kidsAndToysDBContext.Products
                .Select(o => new ListOfAdsVM
                {
                    
                    Id = o.Id,
                    ProductName = o.ProductName,
                    Price = o.Price,
                    Condition = o.Condition,
                    City = o.City,
                    AdsPic = o.AdsPic
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
                });
            kidsAndToysDBContext.SaveChanges();
        }

        internal SearchVM SearchProducts(SearchVM viewModel)
        {
            
            SearchVM searchVM = new SearchVM();
            var query = kidsAndToysDBContext.Products
                .Where(p => viewModel.SearchWord == p.ProductName || viewModel.SearchWord == p.Category.Title || viewModel.SearchWord == p.Age.Title || viewModel.SearchWord == p.City.Title)
                .Select(p => new AddsInDataBase
                {
                    ProductName = p.ProductName,
                    AdsString = p.AdsPic
                })
                .ToArray();
            searchVM.Products = query;
            return searchVM;

        }

        public DetailsVM GetDetails(DetailsVM modelView)
        {
         
            return kidsAndToysDBContext.Products
                .Select(o => new DetailsVM
                {
                    Id = o.Id,
                    ProductName = o.ProductName,
                    Age = o.Age,
                    Description = o.Description,
                    ConditionDescription = o.ConditionDescription,
                    Condition = o.Condition,
                    Price = o.Price,
                    City = o.City,
                    UserName = o.User.UserName,
                    Email = o.User.Email,
                    AdsPic = o.AdsPic
                   
                }).Single(x => x.Id == modelView.Id);


        }

    }


}

