using KidsAndToys.Models.Entities;
using KidsAndToys.Views.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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
        internal ListOfAdsVM[] ShowOtherCategory()
        {
            return kidsAndToysDBContext.Products
                .Where(o => o.MainCategory.Title == "övrigt")
               .Select(o => new ListOfAdsVM
               {
                   Id = o.Id,
                   ProductName = o.ProductName,
                   Price = o.Price,
                   Condition = o.Condition,
                   City = o.City,
                   AdsPic = o.AdsPic1
               })
               .ToArray();
        }
        internal ListOfAdsVM[] ShowAccessoriesCategory()
        {
            return kidsAndToysDBContext.Products
                .Where(o => o.MainCategory.Title == "accessoarer")
               .Select(o => new ListOfAdsVM
               {
                   Id = o.Id,
                   ProductName = o.ProductName,
                   Price = o.Price,
                   Condition = o.Condition,
                   City = o.City,
                   AdsPic = o.AdsPic1
               })
               .ToArray();
        }
        internal ListOfAdsVM[] ShowToysCategory()
        {
            return kidsAndToysDBContext.Products
                .Where(o => o.MainCategory.Title == "leksaker")
               .Select(o => new ListOfAdsVM
               {
                   Id = o.Id,
                   ProductName = o.ProductName,
                   Price = o.Price,
                   Condition = o.Condition,
                   City = o.City,
                   AdsPic = o.AdsPic1
               })
               .ToArray();
        }

        internal ListOfAdsVM[] ShowShoesCategory()
        {
            return kidsAndToysDBContext.Products
                .Where(o => o.MainCategory.Title == "skor")
               .Select(o => new ListOfAdsVM
               {
                   Id = o.Id,
                   ProductName = o.ProductName,
                   Price = o.Price,
                   Condition = o.Condition,
                   City = o.City,
                   AdsPic = o.AdsPic1
               })
               .ToArray();
        }

        internal ListOfAdsVM[] ShowClothesCategory()
        {
            return kidsAndToysDBContext.Products
                .Where(o => o.MainCategory.Title == "kläder")
               .Select(o => new ListOfAdsVM
               {
                   Id = o.Id,
                   ProductName = o.ProductName,
                   Price = o.Price,
                   Condition = o.Condition,
                   City = o.City,
                   AdsPic = o.AdsPic1
               })
               .ToArray();
        }

        public MyAdsVM[] GetAllUserProducts()
        {
            string userId = userManager.GetUserId(accessor.HttpContext.User);

            return kidsAndToysDBContext.Products
                .Where(o => o.UserId == userId)
                .Select(o => new MyAdsVM
                {
                    Id=o.Id,
                    ProductName = o.ProductName,
                    Price = o.Price,
                    Picture = o.AdsPic1
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
                    AdsPic = o.AdsPic1
                })
                .ToArray();
        }

        internal void DeleteProduct(MyAdsVM viewModel)
        {

            var query = kidsAndToysDBContext.Products
                .Where(x => x.Id == viewModel.Id)
                .Single();
            kidsAndToysDBContext.Products.Remove(query);
            kidsAndToysDBContext.SaveChanges();
        }

        public NewAdsVM GetDropDownLists()
        {
            return new NewAdsVM
            {
                MainCategory = kidsAndToysDBContext.MainCategories
                .OrderBy(x => x.Id)
                .Select(x => new SelectListItem(
                    x.Title, x.Id.ToString()))
                .ToArray(),

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
           
                var filePath = Path.Combine(webHostEnv.WebRootPath, "Uploads", viewModel.AdsPic1.FileName);
           
            
            // Save the file to disk
            using var fileStream = new FileStream(filePath, FileMode.Create);
            viewModel.AdsPic1.CopyTo(fileStream);
            

            string userId = userManager.GetUserId(accessor.HttpContext.User);

            var query = kidsAndToysDBContext.Products
                .Add(new Product
                {
                    UserId = userId,
                    ProductName = viewModel.ProductName,
                    MainCategoryId = viewModel.MainCategoryValue,
                    CategoryId = viewModel.CategoryValue,
                    AgeId = viewModel.AgeValue,
                    ConditionId = viewModel.ConditionValue,
                    ConditionDescription = viewModel.ConditionDescription,
                    Price = viewModel.Price,
                    Description = viewModel.Description,
                    CityId = viewModel.CityValue,
                    AdsPic1 = viewModel.AdsPic1.FileName,
                    AdsPic2 = viewModel.AdsPic2?.FileName,
                    AdsPic3 = viewModel.AdsPic3?.FileName,
                    AdsPic4 = viewModel.AdsPic4?.FileName
                });
            kidsAndToysDBContext.SaveChanges();
        }

        internal SearchVM SearchProducts(SearchVM viewModel)
        {
            
                SearchVM searchVM = new SearchVM();
                var query = kidsAndToysDBContext.Products
                    .Where(p => viewModel.SearchWord == p.ProductName || viewModel.SearchWord == p.Category.Title || viewModel.SearchWord == p.Age.Title || viewModel.SearchWord == p.City.Title || viewModel.SearchWord == p.MainCategory.Title)
                    .Select(p => new AddsInDataBase
                    {
                        ProductName = p.ProductName,
                        AdsString = p.AdsPic1,
                        Id = p.Id
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
                    AdsPic1 = o.AdsPic1,
                    AdsPic2 = o.AdsPic2,
                    AdsPic3 = o.AdsPic3,
                    AdsPic4 = o.AdsPic4,
                   
                }).Single(x => x.Id == modelView.Id);


        }

    }


}

