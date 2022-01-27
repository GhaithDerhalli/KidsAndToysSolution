using System;
using System.Collections.Generic;

namespace KidsAndToys.Models.Entities
{
    public partial class User
    {
        public User()
        {
            Products = new HashSet<Product>();
        }

        public string Id { get; set; } = null!;
        public int ZipCode { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;

        public virtual AspNetUser IdNavigation { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
