using KidsAndToys.Models.Entities;

namespace KidsAndToys.Views.Products
{
    public class DetailsVM
    {
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public Age Age { get; set; }
        public City City { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public User UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AdsPic { get; set; }
    }
}
