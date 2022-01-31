using KidsAndToys.Models.Entities;

namespace KidsAndToys.Views.Products
{
    public class DetailsVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public Age Age { get; set; }
        public City City { get; set; }
        public Condition Condition { get; set; }
        public string ConditionDescription { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AdsPic1 { get; set; }
        public string AdsPic2 { get; set; }
        public string AdsPic3 { get; set; }
        public string AdsPic4 { get; set; }
    }
}
