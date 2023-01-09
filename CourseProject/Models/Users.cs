using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models
{
    public class Users
    {
        public string Id { get; set; }

        [Required, MinLength(2, ErrorMessage = "Minimum Length is 2")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum Length is 4")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
