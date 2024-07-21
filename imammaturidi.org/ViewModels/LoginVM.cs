using System.ComponentModel.DataAnnotations;

namespace imammaturidi.org.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "e mail cannot be empty")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
        
    }
}