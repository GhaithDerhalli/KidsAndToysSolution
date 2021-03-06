using KidsAndToys.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KidsAndToys.Views.Products
{
    public class AddsInDataBase
    {
        public string AdsString { get; set; }

        public string ProductName { get; set; }

        [Display(Name = "Ålder")]
        public SelectListItem[]? Age { get; set; }
        [Range(1, 17)]
        public int AgeValue { get; set; }



        [Display(Name = "Kategori")]
        public SelectListItem[]? Category { get; set; } = null!;
        [Range(1, 20)]
        public int CategoryValue { get; set; }

        [Display(Name = "Skick")]
        public string Condition { get; set; }
        [Range(1, 3)]

        public string ConditionDescription { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        [Display(Name = "Stad")]
        public string City { get; set; }
        [Range(1, 159)]
        [Display(Name = "Bild på varan")]
        [Required(ErrorMessage = "Vänligen bifoga en bild")]
        public IFormFile AdsPic { get; set; }
        public int Id { get; set; }
        public Product Product { get; set; }

    }
}
