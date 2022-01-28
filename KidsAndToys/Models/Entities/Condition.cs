﻿using System;
using System.Collections.Generic;

namespace KidsAndToys.Models.Entities
{
    public partial class Condition
    {
        public Condition()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
