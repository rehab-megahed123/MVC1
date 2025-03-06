using System.ComponentModel.DataAnnotations;

namespace MVcProject.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="*")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
