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
                //Category = new SelectListItem[]
                //{
                //    new SelectListItem { Value = "1", Text = "Kläder" },
                //    new SelectListItem { Value = "2", Text = "skor" },
                //    new SelectListItem { Value = "3", Text = "Leksaker" },
                //    new SelectListItem { Value = "4", Text = "Accesoir" },
                //    new SelectListItem { Value = "5", Text = "TV-Spel" }
                //},

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

                //Age = new SelectListItem[]
                //{
                //    new SelectListItem{Value = "1", Text = "0-3 Mån"},
                //    new SelectListItem{Value = "2", Text = "3-6 Mån"},
                //    new SelectListItem{Value = "3", Text = "6-9 Mån"},
                //    new SelectListItem{Value = "4", Text = "9-12 Mån"},
                //    new SelectListItem{Value = "5", Text = "1 år"},
                //    new SelectListItem{Value = "6", Text = "2 år"},
                //    new SelectListItem{Value = "7", Text = "3 år"},
                //    new SelectListItem{Value = "8", Text = "4 år"},
                //    new SelectListItem{Value = "9", Text = "5 år"},
                //    new SelectListItem{Value = "10", Text = "6 år"},
                //    new SelectListItem{Value = "11", Text = "7 år"},
                //    new SelectListItem{Value = "12", Text = "8 år"},
                //    new SelectListItem{Value = "13", Text = "9 år"},
                //    new SelectListItem{Value = "14", Text = "10 år"},
                //    new SelectListItem{Value = "15", Text = "11 år"},
                //    new SelectListItem{Value = "16", Text = "12 år"},
                //    new SelectListItem{Value = "17", Text = "13 år"}
                //},
                Condition = kidsAndToysDBContext.Conditions
                .OrderBy(x => x.Id)
                .Select(x => new SelectListItem(
                    x.Title, x.Id.ToString()))
                .ToArray(),
                //Condition = new SelectListItem[]
                //{
                //    new SelectListItem{Value = "1", Text = "Oanvänt"},
                //    new SelectListItem{Value = "2", Text = "Sparsamt använt"},
                //    new SelectListItem{Value = "3", Text = "använt"}
                //},
                City = kidsAndToysDBContext.Cities
                .OrderBy(x => x.Id)
                .Select(x => new SelectListItem(
                    x.Title, x.Id.ToString()))
                .ToArray(),

                //City = new SelectListItem[]
                //{
                //    new SelectListItem{Value = "1", Text = "Stockholm"},
                //    new SelectListItem{Value = "2", Text = "Malmö"},
                //    new SelectListItem{Value = "3", Text = "Västerås"},
                //    new SelectListItem{Value = "4", Text = "Södertälje"}
                //}
            };

        }
        internal void AddAd(NewAdsVM viewModel)
        {
            var query = kidsAndToysDBContext.Products
                .Add(new Product
                {
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

