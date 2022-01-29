using KidsAndToys.Models.Entities;

namespace KidsAndToys.Views.Products
{
    public class SearchVM
    {
        public Category category { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public City city { get; set; }
        public Age age { get; set; }
        public Product[] Product { get; set; }
        public Condition Condition { get; set; }
    }
}
