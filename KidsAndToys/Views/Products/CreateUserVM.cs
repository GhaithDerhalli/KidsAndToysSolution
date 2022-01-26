using System.ComponentModel.DataAnnotations;

namespace KidsAndToys.Views.Products
{
    public class CreateUserVM
    {
        [Required(ErrorMessage = "Enter a Name")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter a Email Adress")]
        [EmailAddress(ErrorMessage = "Enter a valid EmailAdress")]
        public string Epost { get; set; }

        [Required(ErrorMessage = "Enter a PhoneNumber")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter your ZipCode ")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Enter a Adress")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter a City")]
        public string City { get; set; }


        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat password")]
        public string PasswordRepeat { get; set; }


        [Display(Name = "Profil Bild")]
        [Required(ErrorMessage = "Attach a Picture")]
        public IFormFile ProfilePic { get; set; }
    }
}
