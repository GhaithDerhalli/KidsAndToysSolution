using System;
using System.Collections.Generic;

namespace KidsAndToys.Models.Entities
{
    public partial class Age
    {
        public int Id { get; set; }
        public string Age { get; set; } = null!;

        public virtual Product IdNavigation { get; set; } = null!;
    }
}
