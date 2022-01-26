using System;
using System.Collections.Generic;

namespace KidsAndToys.Models.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Age { get; set; }
        public string Category { get; set; } = null!;
        public string Condition { get; set; } = null!;
        public string? ConditionDescription { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string City { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
