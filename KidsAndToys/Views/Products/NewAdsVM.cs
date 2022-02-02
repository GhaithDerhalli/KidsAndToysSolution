using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KidsAndToys.Views.Products
{
    public class NewAdsVM
    {
        public int Id { get;}

        public string ProductName { get; set; }

        [Display(Name = "Ålder")]
        public SelectListItem[]? Age { get; set; }
        [Range(1, 17)]
        public int AgeValue { get; set; }

        [Display(Name = "Kön")]
        public SelectListItem[]? Gender { get; set; }
        [Range(1, 3)]
        public int GenderValue { get; set; }

        [Display(Name = "Huvud Kategori")]
        public SelectListItem[]? MainCategory { get; set; } = null!;
        [Range(1, 5)]
        public int MainCategoryValue { get; set; }


        [Display(Name = "Under Kategori")]
        public SelectListItem[]? Category { get; set; } = null!;
        [Range(1, 20)]
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
        [Range(1,159)]
        public int CityValue { get; set; }

        [Display(Name = "Bild på varan")]
        [Required(ErrorMessage = "Vänligen bifoga bild")]
        public IFormFile AdsPic1 { get; set; }

        [Display(Name = "Bild 2")]
        public IFormFile? AdsPic2 { get; set; }

        [Display(Name = "Bild 3")]
        public IFormFile? AdsPic3 { get; set; }

        [Display(Name = "Bild 4")]
        public IFormFile? AdsPic4 { get; set; }

    }
}
