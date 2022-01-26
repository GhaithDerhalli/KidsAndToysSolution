﻿using System;
using System.Collections.Generic;

namespace KidsAndToys.Models.Entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Epost { get; set; } = null!;
        public int PhoneNumber { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
    }
}
