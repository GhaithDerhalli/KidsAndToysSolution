using KidsAndToys.Models.Entities;
using KidsAndToys.Views.Products;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidsAndToys.Models
{
    public class ProductsService
    {
        KidsAndToysDBContext kidsAndToysDBContext;
        public ProductsService(KidsAndToysDBContext kidsAndToysDBContext)
        {
            this.kidsAndToysDBContext = kidsAndToysDBContext;
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
            var query = kidsAndToysDBContext.Products
                .Add(new Product
                {
                    UserId = viewModel.
                    ProductName = viewModel.ProductName,
                    CategoryId = viewModel.CategoryValue,
                    AgeId = viewModel.AgeValue,
                    ConditionId = viewModel.ConditionValue,
                    ConditionDescription = viewModel.ConditionDescription,
                    Price = viewModel.Price,
                    Description = viewModel.Description,
                    CityId = viewModel.CityValue

                });
            kidsAndToysDBContext.SaveChanges();
        }
    }



}

