using KidsAndToys.Models.Entities;

namespace KidsAndToys.Views.Products
{
    public class ListOfAdsVM
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Condition Condition { get; set; }
        public City City { get; set; }
    }
}