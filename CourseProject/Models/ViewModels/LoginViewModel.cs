using System.ComponentModel.DataAnnotations;

namespace CourseProject.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required, MinLength(2, ErrorMessage = "Minimum Length is 2")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [DataType(DataType.Password), Required, MinLength(4, ErrorMessage = "Minimum Length is 4")]
        public string Password { get; set; }
    }
}
