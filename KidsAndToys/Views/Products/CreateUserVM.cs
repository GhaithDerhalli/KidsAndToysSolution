using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace KidsAndToys.Views.Products
{
    public class CreateUserVM
    {
        [Required(ErrorMessage = "Vänligen ange ett namn")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vänligen ange en email adress")]
        [EmailAddress(ErrorMessage = "Enter a valid EmailAdress")]
        public string Epost { get; set; }

        [Required(ErrorMessage = "Vänligen ange ett telefonnummer")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Vänligen ange ett postnummer")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Vänligen ange en adress")]
        public string Address { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vänligen ange en stad")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Repetera lösenord")]
        [Compare(nameof(Password))]
        public string PasswordRepeat { get; set; }


        [Display(Name = "Profil Bild")]
        public IFormFile? ProfilePic { get; set; }
    }
}
