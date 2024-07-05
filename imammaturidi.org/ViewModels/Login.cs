using System.ComponentModel.DataAnnotations;

namespace imammaturidi.org.ViewModels
{
    public class Login
    {
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }
    }
}
