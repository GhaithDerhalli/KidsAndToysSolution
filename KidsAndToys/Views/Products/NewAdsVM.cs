using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KidsAndToys.Views.Products
{
    public class NewAdsVM
    {
        public string ProductName { get; set; }

        [Display(Name = "Ålder")]
        public SelectListItem[]? Age { get; set; }
        [Range(1, 17)]
        public int AgeValue { get; set; }



        [Display(Name = "Kategori")]
        public SelectListItem[]? Category { get; set; }
        [Range(1, 5)]
        public int CategoryValue { get; set; }

        [Display(Name = "Skick")]
        public SelectListItem[]? Condition { get; set; }
        [Range(1,3)]
        public int ConditionValue { get; set; }

        public string ConditionDescription { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        [Display(Name = "Stad")]
        public SelectListItem[]? City { get; set; }
        [Range(1,4)]
        public string CityValue { get; set; }
    }
}
