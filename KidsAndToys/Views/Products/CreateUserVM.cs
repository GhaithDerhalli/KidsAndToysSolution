using System.ComponentModel.DataAnnotations;

namespace KidsAndToys.Views.Products
{
    public class CreateUserVM
    {
        public string Username { get; set; }
        public string Epost { get; set; }
        public int PhoneNumber { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string PasswordRepeat { get; set; }
        [Display(Name = "Profil Bild")]
        public IFormFile ProfilePic { get; set; }
    }
}
