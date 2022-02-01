using System;
using System.Collections.Generic;

namespace KidsAndToys.Models.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public int AgeId { get; set; }
        public int GenderId { get; set; }
        public int MainCategoryId { get; set; }
        public int CategoryId { get; set; }
        public int ConditionId { get; set; }
        public string? ConditionDescription { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int CityId { get; set; }
        public string AdsPic1 { get; set; } = null!;
        public string? AdsPic2 { get; set; }
        public string? AdsPic3 { get; set; }
        public string? AdsPic4 { get; set; }

        public virtual Age Age { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
        public virtual City City { get; set; } = null!;
        public virtual Condition Condition { get; set; } = null!;
        public virtual Gender Gender { get; set; } = null!;
        public virtual MainCategory MainCategory { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
