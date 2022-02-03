using KidsAndToys.Models.Entities;

namespace KidsAndToys.Views.Products
{
    public class SearchVM
    {
        public string SearchWord { get; set; }
        public AddsInDataBase Ad { get; set; }
        public AddsInDataBase[] Products { get; set; }
    }
}
