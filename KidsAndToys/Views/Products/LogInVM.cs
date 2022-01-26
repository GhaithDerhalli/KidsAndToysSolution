using System.ComponentModel.DataAnnotations;

namespace KidsAndToys.Views.Products
{
    public class LogInVM
    {
        [Required(ErrorMessage = "Enter a Username")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
