using System;
using System.Collections.Generic;

namespace KidsAndToys.Models.Entities
{
    public partial class Age
    {
        public int Id { get; set; }
        public string _03Mån { get; set; } = null!;
        public string _36Mån { get; set; } = null!;
        public string _69Mån { get; set; } = null!;
        public string _912Mån { get; set; } = null!;

        public virtual Product IdNavigation { get; set; } = null!;
    }
}
