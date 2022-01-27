using System;
using System.Collections.Generic;

namespace KidsAndToys.Models.Entities
{
    public partial class Condition
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
    }
}
