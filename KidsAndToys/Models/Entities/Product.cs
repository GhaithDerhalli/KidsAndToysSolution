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
        public int CategoryId { get; set; }
        public int ConditionId { get; set; }
        public string? ConditionDescription { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int CityId { get; set; }

        public virtual Age Age { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
