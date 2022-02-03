using KidsAndToys.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace KidsAndToys.Views.Products
{
    public class ListOfAdsVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public Condition Condition { get; set; }
        public City City { get; set; }
        public string AdsPic { get; set; }
    }
}