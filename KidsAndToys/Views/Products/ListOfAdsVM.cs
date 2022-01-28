using KidsAndToys.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace KidsAndToys.Views.Products
{
    public class ListOfAdsVM
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Condition Condition { get; set; }
        public City City { get; set; }
        [Display(Name = "Bild på varan")]
        [Required(ErrorMessage = "Attach a Picture")]
        public IFormFile AdsPic { get; set; }
    }
}