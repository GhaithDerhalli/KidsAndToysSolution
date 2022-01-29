using KidsAndToys.Models.Entities;

namespace KidsAndToys.Views.Products
{
    public class SearchVM
    {
        public string SearchWord { get; set; }
        public NewAdsVM Ad { get; set; }
        public NewAdsVM[] Products { get; set; }
    }
}
